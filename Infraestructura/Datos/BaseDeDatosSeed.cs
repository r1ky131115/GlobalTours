using System.Text.Json;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Datos
{
    public class BaseDeDatosSeed
    {
        public static async Task SeedAsymc(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                // Agrega datos de prueba si no existen
                if (!context.Pais.Any())
                {
                    var paisData = File.ReadAllText("../Infraestructura/Datos/SeedData/paises.json");
                    var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);  // Deserializa el archivo de .json

                    foreach (var pais in paises)
                    {
                        await context.Pais.AddAsync(pais);
                    }
                    await context.SaveChangesAsync(); // Guarda los cambios
                }

                if (!context.Categoria.Any())
                {
                    var categoriaData = File.ReadAllText("../Infraestructura/Datos/SeedData/categorias.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach (var categoria in categorias)
                    {
                        await context.Categoria.AddAsync(categoria);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Lugar.Any())
                {
                    var lugaresData = File.ReadAllText("../Infraestructura/Datos/SeedData/lugares.json");
                    var lugares = JsonSerializer.Deserialize<List<Lugar>>(lugaresData);

                    foreach (var lugar in lugares)
                    {
                        await context.Lugar.AddAsync(lugar);
                    }
                    await context.SaveChangesAsync(); 
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BaseDeDatosSeed>();
                logger.LogError(ex, "Error al inicializar la base de datos.");
            }
        }
    }
}