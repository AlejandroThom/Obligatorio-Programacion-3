
using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaAplicacion.CasosUso.CUPedido.Implementacion;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Implementacion;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaAplicacion.CasosUso.CUUsuario.Implementacion;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarios>();
            builder.Services.AddScoped<ICUInicioDeSesion,CUInicioDeSesion>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



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
