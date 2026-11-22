using PlataformaCurso.Models;

namespace PlataformaCurso.Repositories
{
    /// <summary>
    /// Contrato de acesso aos cursos. Nada aqui fala de banco, SQL ou Entity Framework.
    /// </summary>
    public interface ICursoRepository
    {
        Task<List<Curso>> ListarAsync();
        Task<Curso?> ObterAsync(int id);

        // "Existe um curso com este nome?" (idIgnorado serve para a atualização)
        Task<bool> ExisteAsync(string nome, int? idIgnorado);

        void Adicionar(Curso curso);
        void Remover(Curso curso);

        // Grava de uma vez tudo o que foi adicionado, alterado ou removido
        Task SalvarAsync();
    }
}
