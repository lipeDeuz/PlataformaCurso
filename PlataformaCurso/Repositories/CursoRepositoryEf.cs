using Microsoft.EntityFrameworkCore;
using PlataformaCurso.Data;
using PlataformaCurso.Models;

namespace PlataformaCurso.Repositories
{
    /// <summary>
    /// Implementação do contrato usando Entity Framework Core.
    /// </summary>
    public class CursoRepositoryEf : ICursoRepository
    {
        private readonly AppDbContext _context;

        public CursoRepositoryEf(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Curso>> ListarAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso?> ObterAsync(int id)
        {
            // Include carrega as aulas do curso (lado "muitos") junto com ele
            return await _context.Cursos
                .Include(c => c.Aulas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExisteAsync(string nome, int? idIgnorado)
        {
            return await _context.Cursos.AnyAsync(c =>
                c.Nome == nome &&
                (idIgnorado == null || c.Id != idIgnorado));
        }

        public void Adicionar(Curso curso)
        {
            _context.Cursos.Add(curso);
        }

        public void Remover(Curso curso)
        {
            _context.Cursos.Remove(curso);
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
