using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class LugarRepositorio : ILugarRepositorio
    {

        private readonly ApplicationDbContext _contexto;
        
        public LugarRepositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await _contexto.Lugar.FindAsync(id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _contexto.Lugar.ToListAsync();
        }
    }
}