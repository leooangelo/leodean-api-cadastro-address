using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Address.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Infra.DataAccess.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.AddressID);

            builder.Property(x => x.AddressID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("VARCHAR(10)");

            builder.Property(x => x.Neighborhood)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("VARCHAR(10)");

            builder.Property(x => x.Complement)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Favorite)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.IsActive).IsRequired();


            builder.Property(x => x.CustomerID)
                  .HasMaxLength(100)
                 .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.EstablishmentID)
                  .HasMaxLength(100)
                 .HasColumnType("VARCHAR(100)");

        }
    }
}
