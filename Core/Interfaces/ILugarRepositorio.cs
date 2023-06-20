using Core.Entidades;

namespace Core.Interfaces
{
    public interface ILugarRepositorio
    {
        // Firma de metodos
        Task<Lugar> GetLugarAsync(int id);
        Task<IReadOnlyList<Lugar>> GetLugaresAsync();
    }
}