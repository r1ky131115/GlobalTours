using Core.Especificaciones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repositorio (ApplicationDbContext context)
        {
            _context = context;
        }

        public  async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        
        public async Task<T> ObtenerEspecificacion(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosEspecificacion(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificacion<T>.GetQuery(_context.Set<T>().AsQueryable(), espec);
        }
    }   
}