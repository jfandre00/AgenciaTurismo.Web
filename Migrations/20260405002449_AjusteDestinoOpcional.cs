using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaTurismo.Web.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDestinoOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.AlterColumn<int>(
                name: "PacoteTuristicoId",
                table: "Destinos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.AlterColumn<int>(
                name: "PacoteTuristicoId",
                table: "Destinos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
