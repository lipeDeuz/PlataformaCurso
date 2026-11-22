using PlataformaCurso.Models;

namespace PlataformaCurso.Services
{
    public class CursoService : ICursoService
    {

        private readonly ICursoRepository _repositorio;

        public CursoService(ICursoRepository repositorio)
        {
            _repositorio = repositorio;
        }


        public async Task<bool> AtualizarAsync(int id, Curso cursoAtualizado)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> CriarAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Curso>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Curso?> ObterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
