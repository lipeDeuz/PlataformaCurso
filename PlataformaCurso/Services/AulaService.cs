using PlataformaCurso.Models;

namespace PlataformaCurso.Services
{
    public class AulaService : IAulaService
    {

        private readonly IAulaRepository _repositorio;

        public AulaService(IAulaRepository repositorio)
        {
            _repositorio = repositorio;
        }


        public async Task<bool> AtualizarAsync(int id, Aula aulaAtualizado)
        {
            throw new NotImplementedException();
        }

        public async Task<Aula> CriarAsync(Aula aula)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Aula>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Aula?> ObterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Aula?> ObterPorCursoId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
