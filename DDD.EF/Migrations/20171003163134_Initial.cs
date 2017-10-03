using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDD.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateSequence<int>(
                name: "ProductCategoryId",
                schema: "catalog",
                incrementBy: 5);

            migrationBuilder.CreateSequence<int>(
                name: "ProductGroupId",
                schema: "catalog",
                incrementBy: 5);

            migrationBuilder.CreateSequence<int>(
                name: "ProductId",
                schema: "catalog",
                incrementBy: 5);

            migrationBuilder.CreateSequence<int>(
                name: "SupplierId",
                schema: "catalog",
                incrementBy: 10);

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

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "catalog",
                columns: table => new
                {
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ProductGroupId);
                    table.UniqueConstraint("AK_ProductGroup_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "catalog",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.UniqueConstraint("AK_Supplier_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.UniqueConstraint("AK_Product_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "catalog",
                        principalTable: "ProductGroup",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                schema: "catalog",
                table: "Product",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "ProductCategoryId",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "ProductGroupId",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "ProductId",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "SupplierId",
                schema: "catalog");
        }
    }
}
