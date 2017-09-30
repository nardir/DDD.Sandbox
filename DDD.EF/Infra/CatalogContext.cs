using DDD.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.EF.Infra
{
    public class CatalogContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "catalog";

        public CatalogContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            //string sConnString = @"Server=(localdb)\ProjectsV13;Database=DDDCatalog;Trusted_Connection=True";
            //optionbuilder.UseSqlServer(sConnString);
        }

        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("ProductGroupId", DEFAULT_SCHEMA)
                  .IncrementsBy(5);

            modelBuilder.HasSequence<int>("ProductId", DEFAULT_SCHEMA)
                .IncrementsBy(5);

            modelBuilder.HasSequence<int>("ProductCategoryId", DEFAULT_SCHEMA)
                .IncrementsBy(5);

            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        }
    }

    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory", CatalogContext.DEFAULT_SCHEMA);

            builder.Property(c => c.Identity)
                .HasColumnName("ProductCategoryId")
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("ProductCategoryId", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(c => c.Identity);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            //Add unique index to name
            builder.HasAlternateKey(c => c.Name);
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", CatalogContext.DEFAULT_SCHEMA);

            // .HasColumnName("ProductId")
            builder.Property(p => p.Id)
                .HasColumnName("ProductId")
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("ProductId", CatalogContext.DEFAULT_SCHEMA);

            //builder.HasKey("ProductId");
            builder.HasKey(p => p.Id);

            builder.Ignore(p => p.ProductId);

            //.HasMaxLength(255)
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            //Add unique index to name
            builder.HasAlternateKey(p => p.Name);

            builder.Property(p => p.ListPrice)
                .IsRequired(false)
                .HasColumnType("decimal(5,2)");

            builder.Property<int>("ProductGroupId")
                .IsRequired();

            //builder.Ignore(p => p.ProductGroup);
            builder.HasOne(p => p.ProductGroup)
                .WithMany()
                .HasForeignKey("ProductGroupId");

            //builder.Property(p => p.DateCreated)
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getdate()");
            builder.Property(p => p.DateCreated)
                .HasColumnType("datetime");

            //builder.Property(p => p.Description)
            //    .HasColumnType("nvarchar(max)")
            //    .IsRequired(true)
            //    .HasDefaultValue("");
            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(max)");
        }
    }

    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroup", CatalogContext.DEFAULT_SCHEMA);

            //Shadow property for Primary Key. ProductGroup is a Value Object
            builder.Property<int>("ProductGroupId")
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("ProductGroupId", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey("ProductGroupId");

            //.HasMaxLength(100)
            builder.Property(pg => pg.Name)               
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            //Add unique index to name
            builder.HasAlternateKey(pg => pg.Name);
        }
    }
}
