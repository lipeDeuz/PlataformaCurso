using PlataformaCurso.Models;

namespace PlataformaCurso.Services
{
    public interface ICursoService
    {
        Task<List<Curso>> ListarAsync();
        Task<Curso?> ObterAsync(int id);
        Task<Curso> CriarAsync(Curso curso);
        Task<bool> AtualizarAsync(int id, Curso cursoAtualizado);
        Task<bool> RemoverAsync(int id);
    }
}
