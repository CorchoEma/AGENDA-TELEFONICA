using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDATELEFONICA.Migrations
{
    public partial class Model02User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idUser",
                table: "Contacto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_idUser",
                table: "Contacto",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_AspNetUsers_idUser",
                table: "Contacto",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_AspNetUsers_idUser",
                table: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_idUser",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Contacto");
        }
    }
}
