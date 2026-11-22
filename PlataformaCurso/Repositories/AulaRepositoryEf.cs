using Microsoft.EntityFrameworkCore;
using PlataformaCurso.Data;
using PlataformaCurso.Models;

namespace PlataformaCurso.Repositories
{
    /// <summary>
    /// Implementação do contrato usando Entity Framework Core.
    /// </summary>
    public class AulaRepositoryEf : IAulaRepository
    {
        private readonly AppDbContext _context;

        public AulaRepositoryEf(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aula>> ListarAsync()
        {
            return await _context.Aulas.ToListAsync();
        }

        public async Task<Aula?> ObterAsync(int id)
        {
            return await _context.Aulas.FindAsync(id);
        }

        public async Task<List<Aula>> ListarPorCursoAsync(int cursoId)
        {
            return await _context.Aulas
                .Where(a => a.CursoId == cursoId)
                .ToListAsync();
        }

        public void Adicionar(Aula aula)
        {
            _context.Aulas.Add(aula);
        }

        public void Remover(Aula aula)
        {
            _context.Aulas.Remove(aula);
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
