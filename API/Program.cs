using API.Helpers;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Conexion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(
        conectionString, 
        ServerVersion.AutoDetect(conectionString)
        )
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILugarRepositorio, LugarRepositorio>();
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>)); // Para que se pueda usar el generic Repositorio<T>
builder.Services.AddAutoMapper(typeof(MappingProfiles)); // Para que se pueda usar el AutoMapper

var app = builder.Build();

// Aplicar las nuevas migraciones al ejecutar la aplicacion y alimenta la base de datos
using (var scope = app.Services.CreateScope())
{
    // Obtener el logger de la aplicacion
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        await BaseDeDatosSeed.SeedAsymc(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "A ocurrido un error al migrar la base de datos.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
