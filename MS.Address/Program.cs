using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using MS.Address.Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MS.Address.Infra;
using MS.Address.Domain.Middlewares;
using MS.Address.Config;
using MS.Address.Helpers;
using MS.Address.API.Token;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(j =>
    {
        j.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        j.SerializerSettings.Formatting = Formatting.Indented;
        j.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AddressContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("AddressContext")),
    ServiceLifetime.Transient);

builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

builder.Services.AddAsymmetricAuthentication(configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Services.AddFluentEmail("no_reply@develine.com.br")
//       .AddRazorRenderer()
//       .AddSmtpSender("smtp.gmail.com", 587, "@develine.com.br", "D3!*(>)f0");



//builder.Services.AddMongoDb(applicationSettings.Mongo);

DependencyInjector.RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();