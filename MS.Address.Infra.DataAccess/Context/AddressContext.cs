using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using MS.Address.Domain.Base;
using MS.Address.Domain.Entities;
using MS.Address.Domain.Exceptions;
using MS.Address.Infra.DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Address.Infra.DataAccess.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            optionsBuilder.EnableSensitiveDataLogging();

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine,
                new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
                LogLevel.Information,
                DbContextLoggerOptions.LocalTime);

            optionsBuilder.EnableDetailedErrors();
#endif
        }

        public virtual DbSet<AddressEntity> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMap());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity)entityEntry.Entity).SetCreatedAt(DateTime.Now);
                    }
                    else
                    {
                        entityEntry.Property("CreatedAt").IsModified = false;
                        ((BaseEntity)entityEntry.Entity).SetUpdatedAt(DateTime.Now);
                    }
                }

                return await base.SaveChangesAsync(true, cancellationToken);
            }
            catch (DbUpdateException dbUpdateEx)
            {
                throw new DatabaseException(dbUpdateEx.Message, dbUpdateEx);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }
    }
}
