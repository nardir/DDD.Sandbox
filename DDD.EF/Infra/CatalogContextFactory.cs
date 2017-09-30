using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Infra
{
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=DDDCatalog;Trusted_Connection=True")
                .Options;

            return new CatalogContext(options);
        }
    }
}
