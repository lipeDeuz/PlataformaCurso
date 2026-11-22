using Microsoft.AspNetCore.Mvc;
using PlataformaCurso.Models;
using PlataformaCurso.Services;

namespace PlataformaCurso.Controllers
{
    /// <summary>
    /// Recebe a requisição, chama o serviço e escolhe a resposta HTTP.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly IAulaService _servico;

        public AulasController(IAulaService servico)
        {
            _servico = servico;
        }

        // GET: api/Aulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAulas()
        {
            return Ok(await _servico.ListarAsync());
        }

        // GET: api/Aulas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> GetAula(int id)
        {
            var aula = await _servico.ObterAsync(id);

            if (aula is null)
            {
                return NotFound();
            }

            return Ok(aula);
        }

        // POST: api/Aulas (o corpo informa o CursoId ao qual a aula pertence)
        [HttpPost]
        public async Task<ActionResult<Aula>> PostAula(Aula aula)
        {
            try
            {
                var criada = await _servico.CriarAsync(aula);
                return CreatedAtAction(nameof(GetAula), new { id = criada.Id }, criada);
            }
            catch (RegraDeNegocioException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Aulas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAula(int id, Aula aulaAtualizada)
        {
            try
            {
                var atualizada = await _servico.AtualizarAsync(id, aulaAtualizada);

                if (!atualizada)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (RegraDeNegocioException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Aulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAula(int id)
        {
            var removida = await _servico.RemoverAsync(id);

            if (!removida)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
