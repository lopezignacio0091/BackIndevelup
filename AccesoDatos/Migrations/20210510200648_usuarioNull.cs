using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class usuarioNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
