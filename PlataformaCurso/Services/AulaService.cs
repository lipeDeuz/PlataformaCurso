using PlataformaCurso.Models;
using PlataformaCurso.Repositories;

namespace PlataformaCurso.Services
{
    /// <summary>
    /// Conhece as regras de negócio da aula. Não sabe nada de HTTP nem de Entity Framework.
    /// </summary>
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _repositorio;
        private readonly ICursoRepository _cursoRepositorio;

        public AulaService(IAulaRepository repositorio, ICursoRepository cursoRepositorio)
        {
            _repositorio = repositorio;
            _cursoRepositorio = cursoRepositorio;
        }

        public async Task<List<Aula>> ListarAsync()
        {
            return await _repositorio.ListarAsync();
        }

        // Devolve null quando a aula não existe
        public async Task<Aula?> ObterAsync(int id)
        {
            return await _repositorio.ObterAsync(id);
        }

        // Devolve null quando o curso não existe
        public async Task<List<Aula>?> ListarPorCursoAsync(int cursoId)
        {
            if (await _cursoRepositorio.ObterAsync(cursoId) is null)
            {
                return null;
            }

            return await _repositorio.ListarPorCursoAsync(cursoId);
        }

        public async Task<Aula> CriarAsync(Aula aula)
        {
            await ValidarRegrasAsync(aula);

            aula.Id = 0;
            _repositorio.Adicionar(aula);
            await _repositorio.SalvarAsync();

            return aula;
        }

        // Devolve false quando a aula não existe
        public async Task<bool> AtualizarAsync(int id, Aula aulaAtualizado)
        {
            var aula = await _repositorio.ObterAsync(id);

            if (aula is null)
            {
                return false;
            }

            await ValidarRegrasAsync(aulaAtualizado);

            aula.Titulo = aulaAtualizado.Titulo;
            aula.Descricao = aulaAtualizado.Descricao;
            aula.CursoId = aulaAtualizado.CursoId;
            aula.TipoConteudo = aulaAtualizado.TipoConteudo;
            aula.DuracaoEmSegundos = aulaAtualizado.DuracaoEmSegundos;
            aula.Professor = aulaAtualizado.Professor;

            await _repositorio.SalvarAsync();

            return true;
        }

        // Devolve false quando a aula não existe
        public async Task<bool> RemoverAsync(int id)
        {
            var aula = await _repositorio.ObterAsync(id);

            if (aula is null)
            {
                return false;
            }

            _repositorio.Remover(aula);
            await _repositorio.SalvarAsync();

            return true;
        }

        private async Task ValidarRegrasAsync(Aula aula)
        {
            if (string.IsNullOrWhiteSpace(aula.Titulo))
            {
                throw new RegraDeNegocioException("O título da aula é obrigatório.");
            }

            // Regra do relacionamento 1:N: toda aula precisa pertencer a um curso existente
            if (await _cursoRepositorio.ObterAsync(aula.CursoId) is null)
            {
                throw new RegraDeNegocioException("O curso informado não existe.");
            }

            if (aula.DuracaoEmSegundos <= 0)
            {
                throw new RegraDeNegocioException("A duração da aula deve ser maior que zero.");
            }
        }
    }
}
