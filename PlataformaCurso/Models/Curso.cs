namespace PlataformaCurso.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public bool Status { get; set; }

        public int Preco { get; set; }

        public int CargaHoraria { get; set; }

        public string Grau { get; set; } = string.Empty;

        public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
    }
}
