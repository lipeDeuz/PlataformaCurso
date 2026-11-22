using PlataformaCurso.Models;

namespace PlataformaCurso.Repositories
{
    /// <summary>
    /// Contrato de acesso às aulas. Nada aqui fala de banco, SQL ou Entity Framework.
    /// </summary>
    public interface IAulaRepository
    {
        Task<List<Aula>> ListarAsync();
        Task<Aula?> ObterAsync(int id);

        // Lado "muitos" do relacionamento: todas as aulas de um curso
        Task<List<Aula>> ListarPorCursoAsync(int cursoId);

        void Adicionar(Aula aula);
        void Remover(Aula aula);

        Task SalvarAsync();
    }
}
