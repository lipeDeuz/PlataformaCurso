using PlataformaCurso.Models;

namespace PlataformaCurso.Services
{
    public interface IAulaService
    {
        Task<List<Aula>> ListarAsync ();
        Task<Aula?> ObterAsync (int id);
        Task<Aula> CriarAsync (Aula aula);
        Task<bool> AtualizarAsync (int id, Aula aulaAtualizado);
        Task<bool> RemoverAsync (int id);
        Task<Aula?> ObterPorCursoId (int id);
    }
}
