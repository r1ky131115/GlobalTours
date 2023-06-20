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
            return await _contexto.Lugar
                .Include(p => p.Pais)
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _contexto.Lugar
                .Include(p => p.Pais)
                .Include(c => c.Categoria)
                .ToListAsync();
        }
    }
}