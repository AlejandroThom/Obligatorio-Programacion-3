using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class addedVO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "PasswordUsuario_Password");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "NombreUsuario_Nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "EmailUsuario_Email");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "ApellidoUsuario_Apellido");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Articulos",
                newName: "NombreArticulo_Nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Articulos",
                newName: "DescripcionArticulo_Descripcion");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Articulos",
                newName: "CodigoArticulo_Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_Nombre",
                table: "Articulos",
                newName: "IX_Articulos_NombreArticulo_Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordUsuario_Password",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario_Nombre",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailUsuario_Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoUsuario_Apellido",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionArticulo_Descripcion",
                table: "Articulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ApellidoUsuario_Apellido",
                table: "Usuarios",
                column: "ApellidoUsuario_Apellido");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmailUsuario_Email",
                table: "Usuarios",
                column: "EmailUsuario_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario_Nombre",
                table: "Usuarios",
                column: "NombreUsuario_Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PasswordUsuario_Password",
                table: "Usuarios",
                column: "PasswordUsuario_Password");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos",
                column: "CodigoArticulo_Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_DescripcionArticulo_Descripcion",
                table: "Articulos",
                column: "DescripcionArticulo_Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ApellidoUsuario_Apellido",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EmailUsuario_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_NombreUsuario_Nombre",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PasswordUsuario_Password",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_CodigoArticulo_Codigo",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_DescripcionArticulo_Descripcion",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "PasswordUsuario_Password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NombreUsuario_Nombre",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "EmailUsuario_Email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ApellidoUsuario_Apellido",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "NombreArticulo_Nombre",
                table: "Articulos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "DescripcionArticulo_Descripcion",
                table: "Articulos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "CodigoArticulo_Codigo",
                table: "Articulos",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_NombreArticulo_Nombre",
                table: "Articulos",
                newName: "IX_Articulos_Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
