using intranetMVC.Models.Academico;
using System.Collections.Generic;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class AsistenciaController : Controller
    {
        public ActionResult Index()
        {
            var vm = new AsistenciaViewModel
            {
                Periodo = "2024 - I",
                Cursos  = new List<CursoAsistencia>
                {
                    Curso("MAT301","Cálculo III",         "Dr. Huanca Flores",  24, 22, 1, 1),
                    Curso("PRO301","Algoritmos",           "Mg. Quispe Ríos",   20, 18, 0, 2),
                    Curso("SIS201","Base de Datos I",      "Dr. Torres Medina",  22, 20, 2, 0),
                    Curso("RED101","Redes de Computadoras","Ing. Salinas Cruz",  18, 12, 1, 5),
                    Curso("EST201","Estadística p/ Ing.",  "Mg. Paredes Soto",   16,  9, 0, 7),
                }
            };
            return View(vm);
        }

        private static CursoAsistencia Curso(string cod, string nom, string doc,
            int total, int asis, int tard, int falt)
        {
            var pct    = total > 0 ? (decimal)(asis + tard * 0.5m) / total * 100 : 0;
            var estado = pct >= 75 ? "success" : pct >= 60 ? "warning" : "danger";
            return new CursoAsistencia
            {
                Codigo     = cod, Nombre     = nom, Docente    = doc,
                TotalClases = total, Asistencias = asis,
                Tardanzas   = tard, Faltas      = falt,
                Porcentaje  = pct, EstadoBadge = estado,
                Detalle     = GenerarDetalle(total, asis, tard, falt)
            };
        }

        private static List<DetalleAsistencia> GenerarDetalle(int total, int asis, int tard, int falt)
        {
            var lista = new List<DetalleAsistencia>();
            var fecha = new System.DateTime(2024, 4, 1);
            int a = asis, t = tard, f = falt;
            for (int i = 0; i < total; i++, fecha = fecha.AddDays(7))
            {
                string est;
                if      (f > 0) { est = "F"; f--; }
                else if (t > 0) { est = "T"; t--; }
                else            { est = "A"; a--; }
                lista.Add(new DetalleAsistencia { Fecha = fecha.ToString("dd/MM/yyyy"), Estado = est });
            }
            return lista;
        }
    }
}
