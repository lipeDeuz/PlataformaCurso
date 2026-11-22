using System.Text.Json.Serialization;

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

        // Navegação para o lado "1". Fica fora do JSON para evitar ciclo
        // (Curso -> Aulas -> Curso) e para o cliente enviar só o CursoId.
        [JsonIgnore]
        public Curso? Curso { get; set; }
    }
}
