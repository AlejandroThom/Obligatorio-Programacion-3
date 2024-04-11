using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Addherencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "TipoPedido",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pedidos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RUT",
                table: "Clientes",
                column: "RUT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos",
                column: "CodigoArticulo_Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_RUT",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "TipoPedido",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos",
                column: "CodigoArticulo_Codigo");
        }
    }
}
