using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectProductClient.Migrations
{
    /// <inheritdoc />
    public partial class migrationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "ClientId", "Description", "NameProduct", "Price" },
                values: new object[] { new Guid("402e72ff-f975-4222-9695-309541f5ec4f"), new Guid("402e72ff-f975-4222-9695-309541f5ec10"), null, "Pesa Rusa", 120000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("402e72ff-f975-4222-9695-309541f5ec4f"));
        }
    }
}
