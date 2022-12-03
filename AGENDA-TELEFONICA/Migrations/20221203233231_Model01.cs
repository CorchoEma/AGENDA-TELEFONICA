using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDATELEFONICA.Migrations
{
    /// <inheritdoc />
    public partial class Model01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<int>(type: "int", nullable: false),
                    FechaCreacionContacto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");
        }
    }
}
