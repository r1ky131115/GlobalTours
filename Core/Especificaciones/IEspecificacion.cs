using System.Linq.Expressions;

namespace Core.Especificaciones
{
    public interface IEspecificacion<T>
    {
        Expression<Func<T, bool>> Filtro { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}