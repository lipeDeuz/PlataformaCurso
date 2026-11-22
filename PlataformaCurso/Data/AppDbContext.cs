using Microsoft.EntityFrameworkCore;
using PlataformaCurso.Models;

namespace PlataformaCurso.Data
{
    /// <summary>
    /// A "porta" da API para o banco de dados.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Cada DbSet vira uma tabela no banco.
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Aula> Aulas => Set<Aula>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento 1 para Muitos: um Curso tem várias Aulas,
            // e cada Aula pertence a um único Curso (chave estrangeira CursoId).
            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Aulas)
                .HasForeignKey(a => a.CursoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
