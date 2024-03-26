using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Numero");

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Clientes",
                newName: "DireccionId");

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
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
    }
}
