using Core.Entidades;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ILugarRepositorio _repo;
        public LugaresController(ILugarRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> GetLugares()
        {
            var lugares = await _repo.GetLugaresAsync();
        
            return Ok(lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            var lugar = await _repo.GetLugarAsync(id);

            return Ok(lugar);
        }
    }
}