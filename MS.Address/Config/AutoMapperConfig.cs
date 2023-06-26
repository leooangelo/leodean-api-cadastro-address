using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MS.Address.Domain.DTO;
using MS.Address.Domain.Entities;
using MS.Address.Domain.ViewModels;
using MS.Address.DTO.Address;
using System;

namespace MS.Address.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<AddressViewModel, AddressDTO>().ReverseMap();
                cfg.CreateMap<AddressDTO, AddressEntity>().ReverseMap();
                cfg.CreateMap<AddressEntity, ResponseAddressDTO>().ReverseMap();

                cfg.CreateMap<UpdateAddressViewModel, AddressUpdateDTO>().ReverseMap();
                cfg.CreateMap<AddressUpdateDTO, AddressEntity>().ReverseMap();


            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }
    }
}