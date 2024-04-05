using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class FullNameAddedCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdArticulo",
                table: "Lineas",
                newName: "ArticuloId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnulado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_ArticuloId",
                table: "Lineas",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Articulos_ArticuloId",
                table: "Lineas",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Articulos_ArticuloId",
                table: "Lineas");

            migrationBuilder.DropIndex(
                name: "IX_Lineas_ArticuloId",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "IsAnulado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Lineas",
                newName: "IdArticulo");
        }
    }
}
