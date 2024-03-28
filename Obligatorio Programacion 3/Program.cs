using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;

namespace Obligatorio_Programacion_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PapeleriaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb"));
            });

            //Repositorio Articulos
            builder.Services.AddScoped<IRepositorio<Articulo>,RepositorioArticulo>();

            //CASO DE USO DE LOS ARTICULOS
            builder.Services.AddScoped<ICUAltaArticulo, CUAltaArticulo>();
            builder.Services.AddScoped<ICUBuscarArticulo, CUBuscarArticulo>();
            builder.Services.AddScoped<ICUEliminarArticulo, CUEliminarArticulo>();
            builder.Services.AddScoped<ICUModificarArticulo, CUModificarArticulo>();
            builder.Services.AddScoped<ICUObtenerArticulos, CUObtenerArticulos>();

            //Repositorio Clientes
            builder.Services.AddScoped<IRepositorio<Cliente>, RepositorioClientes>();

            //CASO DE USO DE LOS CLIENTES
            builder.Services.AddScoped<ICUAltaCliente, CUAltaCliente>();
            builder.Services.AddScoped<ICUBuscarCliente, CUBuscarCliente>();
            builder.Services.AddScoped<ICUEliminarCliente, CUEliminarCliente>();
            builder.Services.AddScoped<ICUModificarCliente, CUModificarCliente>();
            builder.Services.AddScoped<ICUObtenerCliente, CUObtenerCliente>();

            //Repositorio Pedidos
            builder.Services.AddScoped<IRepositorio<Pedido>, RepositorioPedidos>();

            //CASO DE USO DE LOS PEDIDOS
            builder.Services.AddScoped<ICUAltaPedido, CUAltaPedido>();
            builder.Services.AddScoped<ICUBuscarPedido, CUBuscarPedido>();
            builder.Services.AddScoped<ICUEliminarPedido, CUAEliminarPedido>();
            builder.Services.AddScoped<ICUModificarPedido, CUModificarPedido>();
            builder.Services.AddScoped<ICUObtenerPedido, CUObtenerPedido>();

            //Repositorio Usuarios
            builder.Services.AddScoped<IRepositorio<Usuario>, RepositorioUsuarios>();

            //CASO DE USO DE LOS USUARIOS
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBuscarUsuario, CUBuscarUsuario>();
            builder.Services.AddScoped<ICUEliminarUsuario, CUEliminarUsuario>();
            builder.Services.AddScoped<ICUModificarUsuario, CUModificarUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();





            // Add services to the container.
            builder.Services.AddControllersWithViews();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
