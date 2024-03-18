using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectProductClient.Migrations
{
    /// <inheritdoc />
    public partial class InsertClient2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "AdressClient", "DNIClient", "LastnameClient", "NameClient", "Phone", "status" },
                values: new object[] { new Guid("402e72ff-f975-4222-9695-309541f5ec10"), "Calle Falsa 123", 1030692511, "Hernandez", "Adrian", 151657489, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: new Guid("402e72ff-f975-4222-9695-309541f5ec10"));
        }
    }
}
