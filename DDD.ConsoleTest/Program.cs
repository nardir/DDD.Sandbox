﻿using DDD.EF.Infra;
using DDD.EF.Models;
using DDD.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DDD.ConsoleTest
{
    class Program
    {
        static IConfiguration Configuration;

        static void Main(string[] args)
        {
            try
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json");

                Configuration = configBuilder.Build();

                //var conn = Configuration["ConnectionStrings:DefaultConnection"];
                var conn = Configuration.GetConnectionString("DefaultConnection");

                TestDI();
            }
            catch (Exception ex)
            {

            }

        }

        private static void TestDI()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CatalogContext>(optionsBuilder =>
                {
                    //optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=DDDCatalog;Trusted_Connection=True");
                    optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
                }
                //, ServiceLifetime.Transient
                ).BuildServiceProvider();

            var context2 = serviceProvider.GetService<CatalogContext>();

            context2.Database.Migrate();

            var category = ProductCategory.Create("Cutflowers");
            context2.ProductCategories.Add(category);
            context2.SaveChanges();

            var product2 = context2.Products.Find(2);
            if (product2 != null)
            {
                context2.Entry(product2).Reference(p => p.ProductGroup).Load();
            }


            var context1 = serviceProvider.GetService<CatalogContext>();
            {
                var product1 = context1.Products.Find(1);
                if (product1 != null)
                {
                    context1.Entry(product1).Reference(p => p.ProductGroup).Load();
                }
            }

        }

        private static void TestEFProduct()
        {
            using (var context = new CatalogContext())
            {
                context.ProductGroups.Add(ProductGroup.Create("Rosa"));
                context.ProductGroups.Add(ProductGroup.Create("Gerbera"));
                context.ProductGroups.Add(ProductGroup.Create("Tulip"));

                context.SaveChanges();

                var rosa = context.ProductGroups.Where(pg => pg.Name == "Rosa").SingleOrDefault();
                var rosaId = context.Entry(rosa).Property("ProductGroupId").CurrentValue;

                var tulip = context.ProductGroups.Where(pg => Microsoft.EntityFrameworkCore.EF.Property<int>(pg, "ProductGroupId") == 3).SingleOrDefault();

                var redBerlin = Product.Create(rosa, "R GR Red Berlin", null, "R GR Red Berlin");
                var ajax = Product.Create(tulip, "TU EN AJAX", null, "TU EN AJAX");
                context.Products.Add(redBerlin);
                context.Products.Add(ajax);

                context.SaveChanges();
            }

            var productGroups = CatalogQueries.GetProductGroups();
        }

        private static void TestValueObjects()
        {
            TenantId2 hol = TenantId2.Create(5);
            TenantId2 hus = TenantId2.Create(6);
            TenantId2 hol2 = TenantId2.Create(5);

            bool t1 = (hol == hus);
            bool t2 = (hol == hol2);
            bool t3 = (hus == 6);

            AccountId2 rickH = AccountId2.Create(5);

            bool t4 = (hol == rickH);
        }
    }
}
