using Core.Especificaciones;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObtenerPorIdAsync(int id);
        Task<IReadOnlyList<T>> ObtenerTodosAsync();

        Task<T> ObtenerEspecificacion(IEspecificacion<T> espec);
        Task<IReadOnlyList<T>> ObtenerTodosEspecificacion(IEspecificacion<T> espec);
    }
}