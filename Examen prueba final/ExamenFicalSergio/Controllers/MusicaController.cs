using ExamenFicalSergio.Context;
using ExamenFicalSergio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFicalSergio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicaController : Controller
    {

        public readonly AplicacionContext aplicacionContext;
        public MusicaController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }
        [HttpGet]
        [Route("MostrarMusicas")]
        public async Task<IActionResult> MostrarMusicas()
        {
            List<Musica> musicas = aplicacionContext.Musica.OrderByDescending(musicas => musicas.idMusica).ToList();
            return StatusCode(StatusCodes.Status200OK, musicas);

        }
        [HttpPost]
        [Route("MusicasBotellas")]
        public async Task<IActionResult> CrearMusicas([FromBody] Musica musica)
        {
            aplicacionContext.Musica.Add(musica);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Creado Correctamente");

        }
        [HttpPut]
        [Route("EditarMusicas")]
        public async Task<IActionResult> EditarMusicas([FromBody] Musica musica)
        {
            aplicacionContext.Musica.Update(musica);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Editado Correctamente");

        }
        [HttpDelete]
        [Route("EliminarMusicas/")]
        public async Task<IActionResult> EliminarMusicas(int id)
        {
            Musica musica = aplicacionContext.Musica.Find(id);
            aplicacionContext.Musica.Remove(musica);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Eliminado Correctamente");
        }
    }
}
