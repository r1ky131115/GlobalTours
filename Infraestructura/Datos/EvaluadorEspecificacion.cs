using Core.Especificaciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class EvaluadorEspecificacion<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificacion<T> especificacion)
        {
            var query = inputQuery;

            if (especificacion.Filtro != null)
            {
                query = query.Where(especificacion.Filtro); // p => p.PaisId == 1
            }
            
            query = especificacion.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}