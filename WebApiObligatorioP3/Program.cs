
using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaAplicacion.CasosUso.CUPedido.Implementacion;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Implementacion;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiObligatorioP3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PapeleriaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb"));
            });

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();

            builder.Services.AddScoped<ICUObtenerArticulosOrdenados, CUObtenerArticulosOrdenados>();

            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidos>();

            builder.Services.AddScoped<ICUObtenerPedidosAnulados, CUObtenerPedidosAnulados>();

            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimiento>();

            builder.Services.AddScoped<ICUActualizarTipoMovimiento, CUActualizarTipoMovimiento>();
            builder.Services.AddScoped<ICUAltaTipoMovimiento, CUAltaTipoMovimiento>();
            builder.Services.AddScoped<ICUEliminarTipoMovimiento, CUEliminarTipoMovimiento>();
            builder.Services.AddScoped<ICUObtenerTiposDeMovimiento, CUObtenerTiposDeMovimiento>();
            builder.Services.AddScoped<ICUObtenerTipoMovimientoPorId, CUObtenerTipoMovimientoPorId>();





            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}
