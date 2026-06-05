using intranetMVC.Models.Academico;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class MatriculaController : Controller
    {
        private static readonly List<CursoDisponible> _oferta = new List<CursoDisponible>
        {
            new CursoDisponible { Id=1,  Codigo="MAT301", Nombre="Cálculo III",                 Creditos=4, Ciclo=5, Dia="Lun/Mié",  Horario="08:00 - 10:00", Docente="Dr. Huanca Flores",   Aula="A-201", VacantesDisponibles=12 },
            new CursoDisponible { Id=2,  Codigo="PRO301", Nombre="Algoritmos y Complejidad",    Creditos=3, Ciclo=5, Dia="Mar/Jue",  Horario="10:00 - 11:30", Docente="Mg. Quispe Ríos",    Aula="B-102", VacantesDisponibles=8  },
            new CursoDisponible { Id=3,  Codigo="SIS201", Nombre="Base de Datos I",             Creditos=4, Ciclo=5, Dia="Lun/Vie",  Horario="11:00 - 13:00", Docente="Dr. Torres Medina",  Aula="Lab-01",VacantesDisponibles=20 },
            new CursoDisponible { Id=4,  Codigo="RED101", Nombre="Redes de Computadoras",       Creditos=3, Ciclo=5, Dia="Mié/Vie",  Horario="14:00 - 15:30", Docente="Ing. Salinas Cruz",   Aula="B-301", VacantesDisponibles=5  },
            new CursoDisponible { Id=5,  Codigo="ING201", Nombre="Inglés Técnico II",           Creditos=2, Ciclo=5, Dia="Sáb",      Horario="08:00 - 10:00", Docente="Lic. Vega Luna",      Aula="A-101", VacantesDisponibles=25 },
            new CursoDisponible { Id=6,  Codigo="EST201", Nombre="Estadística para Ing.",       Creditos=3, Ciclo=5, Dia="Mar/Jue",  Horario="16:00 - 17:30", Docente="Mg. Paredes Soto",   Aula="A-305", VacantesDisponibles=15 },
            new CursoDisponible { Id=7,  Codigo="SIS202", Nombre="Ingeniería de Software I",   Creditos=4, Ciclo=5, Dia="Lun/Mié",  Horario="14:00 - 16:00", Docente="Dr. Campos Vera",     Aula="B-201", VacantesDisponibles=10 },
            new CursoDisponible { Id=8,  Codigo="MAT302", Nombre="Probabilidad y Estadística", Creditos=3, Ciclo=5, Dia="Mar/Vie",  Horario="08:00 - 09:30", Docente="Mg. Llanos Díaz",     Aula="A-202", VacantesDisponibles=18 },
        };

        private List<int> GetMatricula() =>
            Session["IdsMatriculados"] as List<int> ?? new List<int>();

        private void SetMatricula(List<int> ids) =>
            Session["IdsMatriculados"] = ids;

        public ActionResult Index()
        {
            var ids          = GetMatricula();
            var matriculados = _oferta.Where(c => ids.Contains(c.Id)).ToList();

            var vm = new MatriculaViewModel
            {
                Periodo              = "2024 - I",
                MaxCreditos          = 22,
                CreditosMatriculados = matriculados.Sum(c => c.Creditos),
                CursosDisponibles    = _oferta.Where(c => !ids.Contains(c.Id)).ToList(),
                CursosMatriculados   = matriculados
            };
            return View(vm);
        }

        [HttpPost]
        public JsonResult Agregar(int id)
        {
            var ids   = GetMatricula();
            var curso = _oferta.FirstOrDefault(c => c.Id == id);
            if (curso == null)
                return Json(new { ok = false, mensaje = "Curso no encontrado" });

            var matriculados = _oferta.Where(c => ids.Contains(c.Id)).ToList();
            int totalCreditos = matriculados.Sum(c => c.Creditos) + curso.Creditos;

            if (totalCreditos > 22)
                return Json(new { ok = false, mensaje = "Supera el límite de 22 créditos" });

            if (curso.VacantesDisponibles == 0)
                return Json(new { ok = false, mensaje = "No hay vacantes disponibles" });

            if (!ids.Contains(id))
            {
                ids.Add(id);
                SetMatricula(ids);
                curso.VacantesDisponibles--;
            }

            return Json(new { ok = true, creditos = totalCreditos });
        }

        [HttpPost]
        public JsonResult Retirar(int id)
        {
            var ids   = GetMatricula();
            var curso = _oferta.FirstOrDefault(c => c.Id == id);
            if (ids.Remove(id))
            {
                SetMatricula(ids);
                if (curso != null) curso.VacantesDisponibles++;
            }
            var restantes = _oferta.Where(c => ids.Contains(c.Id)).Sum(c => c.Creditos);
            return Json(new { ok = true, creditos = restantes });
        }

        [HttpPost]
        public ActionResult Confirmar()
        {
            var ids = GetMatricula();
            if (!ids.Any())
                return Json(new { ok = false, mensaje = "No tiene cursos en su matrícula" });

            // Aquí iría la llamada al WCF para confirmar
            return Json(new { ok = true, mensaje = "Matrícula confirmada correctamente" });
        }
    }
}
