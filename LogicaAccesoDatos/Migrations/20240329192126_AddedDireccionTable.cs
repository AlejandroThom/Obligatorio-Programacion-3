using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddedDireccionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Direccion_Calle_Direccion_Numero_Direccion_Ciudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Calle",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Ciudad",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Direccion_Numero",
                table: "Clientes",
                newName: "DireccionId");

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DireccionId",
                table: "Clientes",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_Calle_Numero_Ciudad",
                table: "Direcciones",
                columns: new[] { "Calle", "Numero", "Ciudad" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Direcciones_DireccionId",
                table: "Clientes",
                column: "DireccionId",
                principalTable: "Direcciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Direcciones_DireccionId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_DireccionId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "DireccionId",
                table: "Clientes",
                newName: "Direccion_Numero");

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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Direccion_Calle_Direccion_Numero_Direccion_Ciudad",
                table: "Clientes",
                columns: new[] { "Direccion_Calle", "Direccion_Numero", "Direccion_Ciudad" },
                unique: true);
        }
    }
}
