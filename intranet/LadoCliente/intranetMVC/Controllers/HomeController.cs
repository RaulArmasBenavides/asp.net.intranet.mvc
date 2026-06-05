using intranetMVC.Models.Academico;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hoy   = DateTime.Today.DayOfWeek;
            var diaEs = new[] { "Domingo","Lunes","Martes","Miércoles","Jueves","Viernes","Sábado" };

            var todasClases = HorarioHelper.ObtenerClases();
            var hoyClases   = todasClases.FindAll(c => c.Dia == diaEs[(int)hoy]);

            var vm = new DashboardViewModel
            {
                NombreAlumno       = "Juan Carlos",
                CodigoAlumno       = "19200045",
                Periodo            = "2024 - I",
                Promedio           = 14.75m,
                CreditosAprobados  = 58,
                CicloActual        = 4,
                CursosMatriculados = 5,
                Estado             = "Regular",
                HoyClases          = hoyClases,
                Anuncios = new List<Anuncio>
                {
                    new Anuncio { Tipo="danger",  Titulo="Examen Parcial — MAT301",    Descripcion="Aula A-201. Llevar calculadora.",        Fecha="20/06/2024" },
                    new Anuncio { Tipo="warning", Titulo="Entrega de proyecto — SIS201",Descripcion="Plazo máximo 23:59 hrs vía Aula Virtual.", Fecha="25/06/2024" },
                    new Anuncio { Tipo="info",    Titulo="Semana de Integración",       Descripcion="Actividades en el Estadio Universitario.", Fecha="28/06/2024" },
                    new Anuncio { Tipo="success", Titulo="Resultados — PRO301",         Descripcion="Notas del trabajo grupal publicadas.",      Fecha="18/06/2024" },
                }
            };
            return View(vm);
        }
    }
}
