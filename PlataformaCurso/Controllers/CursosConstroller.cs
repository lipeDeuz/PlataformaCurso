using Microsoft.AspNetCore.Mvc;

namespace PlataformaCurso.Controllers
{
    public class CursosConstroller : ControllerBase
    {

        private readonly ICursoService _servico;


        public CursoController(ICursoService servico)
        {
            _servico = servico;
        }



    }
}
