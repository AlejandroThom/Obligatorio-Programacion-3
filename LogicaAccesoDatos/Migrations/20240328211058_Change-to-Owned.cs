using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ChangetoOwned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion_Calle",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion_Ciudad",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Direccion_Numero",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    CantArticulo = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Direccion_Calle_Direccion_Numero_Direccion_Ciudad",
                table: "Clientes",
                columns: new[] { "Direccion_Calle", "Direccion_Numero", "Direccion_Ciudad" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_PedidoId",
                table: "Lineas",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Direccion_Calle_Direccion_Numero_Direccion_Ciudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Calle",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Ciudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Numero",
                table: "Clientes");
        }
    }
}
