namespace PlataformaCurso.Models
{
    public class Aula
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public int CursoId { get; set; }

        public string TipoConteudo { get; set; } = string.Empty;

        public int DuracaoEmSegundos { get; set; }

        public string Professor { get; set; } = string.Empty;

        public Curso Curso { get; set; } = null!;


    }
}
