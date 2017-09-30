using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDD.EF.Migrations
{
    public partial class ProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ProductCategoryId",
                schema: "catalog",
                incrementBy: 5);

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "catalog",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.UniqueConstraint("AK_ProductCategory_Name", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "ProductCategoryId",
                schema: "catalog");
        }
    }
}
