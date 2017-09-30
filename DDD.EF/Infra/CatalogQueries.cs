using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DDD.EF.Infra
{
    public static class CatalogQueries
    {
        public static dynamic GetProductGroups()
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\ProjectsV13;Database=DDDCatalog;Trusted_Connection=True"))
            {
                connection.Open();

                var result = connection.Query<dynamic>(
                   @"select pg.ProductGroupId, pg.Name from catalog.ProductGroup as pg");

                return result;
            }
        }
    }
}
