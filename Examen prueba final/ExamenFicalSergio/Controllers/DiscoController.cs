using ExamenFicalSergio.Context;
using Microsoft.AspNetCore.Mvc;
using ExamenFicalSergio.Models;


namespace ExamenFicalSergio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscoController : Controller
    {

        public readonly AplicacionContext aplicacionContext;
        public DiscoController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarDiscos")]
        public async Task<IActionResult> MostrarDiscos()
        {
            List<Disco> discos = aplicacionContext.Disco.OrderByDescending(discos => discos.idDisco).ToList();
            return StatusCode(StatusCodes.Status200OK, discos);

        }
        [HttpPost]
        [Route("CrearDisco")]
        public async Task<IActionResult> CrearDisco([FromBody] Disco disco)
        {
            aplicacionContext.Disco.Add(disco);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarDisco")]
        public async Task<IActionResult> EditarDisco([FromBody] Disco Disco)
        {
            aplicacionContext.Disco.Update(Disco);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarDisco/")]
        public async Task<IActionResult> EliminarDisco(int id)
        {
            Disco disco = aplicacionContext.Disco.Find(id);
            aplicacionContext.Disco.Remove(disco);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
