using HyperGistDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistPersistence.Configurations
{
    public class BaseEntityConfigurations<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id)
                      .HasName($"PK_{typeof(TBase)}Id")
                      .IsClustered(false);
            modelBuilder.Property(x => x.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Property(x => x.Created)
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("Getdate()");
            modelBuilder.Property(x => x.Modified)
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("Getdate()");
            modelBuilder.Property(x => x.Active)
                        .IsRequired()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);
            modelBuilder.Property(x => x.Deleted)
                        .IsRequired()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);
            modelBuilder.Property(x => x.Description)
                        .IsRequired(false)
                        .HasColumnType("nvarchar(max)");
        }
    }
}
