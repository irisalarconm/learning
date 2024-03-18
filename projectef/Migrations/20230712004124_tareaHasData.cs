using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class tareaHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc10"), new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc2d"), null, new DateTime(2023, 7, 11, 19, 41, 24, 472, DateTimeKind.Local).AddTicks(9493), 1, "Pago de servicios públicos" },
                    { new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc11"), new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc02"), null, new DateTime(2023, 7, 11, 19, 41, 24, 472, DateTimeKind.Local).AddTicks(9544), 0, "Terminar de ver el documental" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8277b440-2ce3-43d7-ab19-9e7bb732bc11"));
        }
    }
}
