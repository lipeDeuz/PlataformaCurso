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
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _servico;
        private readonly IAulaService _aulaServico;

        public CursosController(ICursoService servico, IAulaService aulaServico)
        {
            _servico = servico;
            _aulaServico = aulaServico;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return Ok(await _servico.ListarAsync());
        }

        // GET: api/Cursos/5 (já traz as aulas do curso)
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _servico.ObterAsync(id);

            if (curso is null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // GET: api/Cursos/5/aulas
        [HttpGet("{id}/aulas")]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAulasDoCurso(int id)
        {
            var aulas = await _aulaServico.ListarPorCursoAsync(id);

            if (aulas is null)
            {
                return NotFound();
            }

            return Ok(aulas);
        }

        // POST: api/Cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            try
            {
                var criado = await _servico.CriarAsync(curso);
                return CreatedAtAction(nameof(GetCurso), new { id = criado.Id }, criado);
            }
            catch (RegraDeNegocioException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso cursoAtualizado)
        {
            try
            {
                var atualizado = await _servico.AtualizarAsync(id, cursoAtualizado);

                if (!atualizado)
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

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var removido = await _servico.RemoverAsync(id);

            if (!removido)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
