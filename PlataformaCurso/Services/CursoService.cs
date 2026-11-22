using PlataformaCurso.Models;
using PlataformaCurso.Repositories;

namespace PlataformaCurso.Services
{
    /// <summary>
    /// Conhece as regras de negócio do curso. Não sabe nada de HTTP nem de Entity Framework.
    /// </summary>
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repositorio;

        public CursoService(ICursoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Curso>> ListarAsync()
        {
            return await _repositorio.ListarAsync();
        }

        // Devolve null quando o curso não existe
        public async Task<Curso?> ObterAsync(int id)
        {
            return await _repositorio.ObterAsync(id);
        }

        public async Task<Curso> CriarAsync(Curso curso)
        {
            await ValidarRegrasAsync(curso, idIgnorado: null);

            curso.Id = 0;
            curso.Aulas = new List<Aula>(); // aulas são criadas pelo endpoint de aulas
            _repositorio.Adicionar(curso);
            await _repositorio.SalvarAsync();

            return curso;
        }

        // Devolve false quando o curso não existe
        public async Task<bool> AtualizarAsync(int id, Curso cursoAtualizado)
        {
            var curso = await _repositorio.ObterAsync(id);

            if (curso is null)
            {
                return false;
            }

            await ValidarRegrasAsync(cursoAtualizado, idIgnorado: id);

            curso.Nome = cursoAtualizado.Nome;
            curso.Descricao = cursoAtualizado.Descricao;
            curso.Status = cursoAtualizado.Status;
            curso.Preco = cursoAtualizado.Preco;
            curso.CargaHoraria = cursoAtualizado.CargaHoraria;
            curso.Grau = cursoAtualizado.Grau;

            await _repositorio.SalvarAsync();

            return true;
        }

        // Devolve false quando o curso não existe.
        // As aulas do curso são removidas junto (cascade configurado no AppDbContext).
        public async Task<bool> RemoverAsync(int id)
        {
            var curso = await _repositorio.ObterAsync(id);

            if (curso is null)
            {
                return false;
            }

            _repositorio.Remover(curso);
            await _repositorio.SalvarAsync();

            return true;
        }

        private async Task ValidarRegrasAsync(Curso curso, int? idIgnorado)
        {
            if (string.IsNullOrWhiteSpace(curso.Nome))
            {
                throw new RegraDeNegocioException("O nome do curso é obrigatório.");
            }

            if (await _repositorio.ExisteAsync(curso.Nome, idIgnorado))
            {
                throw new RegraDeNegocioException("Já existe um curso com esse nome.");
            }

            if (curso.Preco < 0)
            {
                throw new RegraDeNegocioException("O preço não pode ser negativo.");
            }

            if (curso.CargaHoraria <= 0)
            {
                throw new RegraDeNegocioException("A carga horária deve ser maior que zero.");
            }
        }
    }
}
