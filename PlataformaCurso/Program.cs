using Microsoft.EntityFrameworkCore;
using PlataformaCurso.Data;
using PlataformaCurso.Repositories;
using PlataformaCurso.Services;


namespace PlataformaCurso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // EF Core com SQLite, usando a connection string do appsettings.json
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Injeção de dependência: Scoped = uma instância por requisição (como o AppDbContext)
            builder.Services.AddScoped<ICursoRepository, CursoRepositoryEf>();
            builder.Services.AddScoped<IAulaRepository, AulaRepositoryEf>();
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<IAulaService, AulaService>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
