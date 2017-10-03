using DDD.EF.Infra;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDD.EF.Migrations
{
    public partial class RemoveTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn("Test", "Supplier", CatalogContext.DEFAULT_SCHEMA);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
