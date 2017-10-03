using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDD.EF.Migrations
{
    public partial class Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SupplierId",
                schema: "catalog",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "catalog",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.UniqueConstraint("AK_Supplier_Name", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "catalog");

            migrationBuilder.DropSequence(
                name: "SupplierId",
                schema: "catalog");
        }
    }
}
