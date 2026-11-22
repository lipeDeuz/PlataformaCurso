namespace PlataformaCurso.Services
{
    /// <summary>
    /// Lançada quando uma regra de negócio é quebrada.
    /// A mensagem é escrita para quem usa a API.
    /// </summary>
    public class RegraDeNegocioException : Exception
    {
        public RegraDeNegocioException(string mensagem) : base(mensagem)
        {
        }
    }
}
