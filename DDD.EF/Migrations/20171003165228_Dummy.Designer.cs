﻿// <auto-generated />
using DDD.EF.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DDD.EF.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20171003165228_Dummy")]
    partial class Dummy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("Relational:Sequence:catalog.ProductCategoryId", "'ProductCategoryId', 'catalog', '1', '5', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:catalog.ProductGroupId", "'ProductGroupId', 'catalog', '1', '5', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:catalog.ProductId", "'ProductId', 'catalog', '1', '5', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:catalog.SupplierId", "'SupplierId', 'catalog', '1', '10', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDD.EF.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductId")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "ProductId")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "catalog")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ListPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProductGroupId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Product","catalog");
                });

            modelBuilder.Entity("DDD.EF.Models.ProductCategory", b =>
                {
                    b.Property<int>("Identity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductCategoryId")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "ProductCategoryId")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "catalog")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Identity");

                    b.HasAlternateKey("Name");

                    b.ToTable("ProductCategory","catalog");
                });

            modelBuilder.Entity("DDD.EF.Models.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "ProductGroupId")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "catalog")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductGroupId");

                    b.HasAlternateKey("Name");

                    b.ToTable("ProductGroup","catalog");
                });

            modelBuilder.Entity("DDD.EF.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplierId")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SupplierId")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "catalog")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Supplier","catalog");
                });

            modelBuilder.Entity("DDD.EF.Models.Product", b =>
                {
                    b.HasOne("DDD.EF.Models.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
