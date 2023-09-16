using Alquiler_Autos.Controlador;
using Microsoft.EntityFrameworkCore;

namespace Alquiler_Autos.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IFormaDePagoServices, FormaDePagoServices>();
            builder.Services.AddScoped<ITipoDeCombustibleServices, TipoDeCombustibleServices>();
            builder.Services.AddScoped<IVehiculoServices, VehiculoServices>();
            builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
            builder.Services.AddScoped<IReservaServices, ReservaServices>();
            builder.Services.AddScoped<IPagoServices, PagoServices>();
            //-----------------------------------------------
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("NuevaPolitica");   
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}