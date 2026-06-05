using intranetMVC.Models.Academico;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult Index() => View();

        // ── Notas / Evaluaciones ─────────────────────────────────────────────

        public ActionResult Notas()
        {
            var cursos = new List<NotasCurso>
            {
                Crear("MAT301","Cálculo III",          "Dr. Huanca Flores",  4,
                    E("Práctica",.10m,15m), E("Trabajo",.20m,14m), E("E.Parcial",.30m,13m), E("E.Final",.40m,16m)),
                Crear("PRO301","Algoritmos",            "Mg. Quispe Ríos",   3,
                    E("Práctica",.10m,18m), E("Trabajo",.20m,17m), E("E.Parcial",.30m,16m), E("E.Final",.40m,19m)),
                Crear("SIS201","Base de Datos I",       "Dr. Torres Medina",  4,
                    E("Práctica",.10m,14m), E("Trabajo",.20m,16m), E("E.Parcial",.30m,15m), E("E.Final",.40m,17m)),
                Crear("RED101","Redes de Computadoras", "Ing. Salinas Cruz",  3,
                    E("Práctica",.10m,12m), E("Trabajo",.20m,13m), E("E.Parcial",.30m,11m), E("E.Final",.40m,14m)),
                Crear("EST201","Estadística p/ Ing.",   "Mg. Paredes Soto",   3,
                    E("Práctica",.10m, 9m), E("Trabajo",.20m,10m), E("E.Parcial",.30m, 8m), E("E.Final",.40m,11m)),
            };
            var vm = new ReporteNotasViewModel
            {
                Periodo           = "2024 - I",
                Cursos            = cursos,
                PromedioSemestral = cursos.Sum(c => c.NotaFinal * c.Creditos) / cursos.Sum(c => c.Creditos)
            };
            return View(vm);
        }

        // Crea una EvaluacionDetalle con sintaxis compacta
        private static EvaluacionDetalle E(string tipo, decimal peso, decimal nota)
        {
            return new EvaluacionDetalle { Tipo = tipo, Peso = peso * 100, Nota = nota };
        }

        // Construye un NotasCurso a partir de sus evaluaciones
        private static NotasCurso Crear(string cod, string nom, string doc, int cred,
            params EvaluacionDetalle[] evals)
        {
            decimal final = evals.Sum(e => (e.Peso / 100m) * e.Nota);
            return new NotasCurso
            {
                Codigo       = cod,
                Nombre       = nom,
                Docente      = doc,
                Creditos     = cred,
                Evaluaciones = new List<EvaluacionDetalle>(evals),
                NotaFinal    = final,
                Estado       = final >= 10.5m ? "Aprobado" : "Desaprobado"
            };
        }

        // ── Reporte de Matrícula ─────────────────────────────────────────────

        public ActionResult Matricula()
        {
            var vm = new ReporteMatriculaViewModel
            {
                Periodo       = "2024 - I",
                NombreAlumno  = "García Pérez, Juan Carlos",
                CodigoAlumno  = "19200045",
                Facultad      = "Facultad de Ingeniería de Sistemas e Informática",
                Carrera       = "Ingeniería de Sistemas",
                Ciclo         = "4°",
                TotalCreditos = 17,
                Cursos = new List<CursoMatriculaItem>
                {
                    new CursoMatriculaItem { Codigo="MAT301", Nombre="Cálculo III",          Creditos=4, Dia="Lun/Mié", Horario="08:00-10:00", Docente="Dr. Huanca Flores",  Aula="A-201"  },
                    new CursoMatriculaItem { Codigo="PRO301", Nombre="Algoritmos",            Creditos=3, Dia="Mar/Jue", Horario="10:00-11:30", Docente="Mg. Quispe Ríos",   Aula="B-102"  },
                    new CursoMatriculaItem { Codigo="SIS201", Nombre="Base de Datos I",       Creditos=4, Dia="Lun/Vie", Horario="11:00-13:00", Docente="Dr. Torres Medina", Aula="Lab-01" },
                    new CursoMatriculaItem { Codigo="RED101", Nombre="Redes de Computadoras", Creditos=3, Dia="Mié/Vie", Horario="14:00-15:30", Docente="Ing. Salinas Cruz", Aula="B-301"  },
                    new CursoMatriculaItem { Codigo="EST201", Nombre="Estadística p/ Ing.",   Creditos=3, Dia="Mar/Jue", Horario="16:00-17:30", Docente="Mg. Paredes Soto",  Aula="A-305"  },
                }
            };
            return View(vm);
        }

        // ── Deudas ───────────────────────────────────────────────────────────

        public ActionResult Deudas()
        {
            var deudas = new List<DeudaItem>
            {
                new DeudaItem { Concepto="Matrícula 2024-I",           Monto=250.00m, FechaVencimiento="15/03/2024", Estado="Pagado"    },
                new DeudaItem { Concepto="Seguro Estudiantil 2024",     Monto= 45.00m, FechaVencimiento="30/03/2024", Estado="Pagado"    },
                new DeudaItem { Concepto="Carné Universitario",         Monto= 25.00m, FechaVencimiento="30/04/2024", Estado="Pendiente" },
                new DeudaItem { Concepto="Certificado de Estudios",     Monto= 30.00m, FechaVencimiento="15/05/2024", Estado="Pendiente" },
                new DeudaItem { Concepto="Biblioteca 2023-II (multa)",  Monto=  8.50m, FechaVencimiento="31/12/2023", Estado="Vencido"   },
            };
            var vm = new ReporteDeudasViewModel
            {
                NombreAlumno   = "García Pérez, Juan Carlos",
                CodigoAlumno   = "19200045",
                TotalPendiente = deudas.Where(d => d.Estado != "Pagado").Sum(d => d.Monto),
                Deudas         = deudas
            };
            return View(vm);
        }

        // ── Pre-Matrícula ────────────────────────────────────────────────────

        public ActionResult PreMatricula()
        {
            var vm = new ReportePreMatriculaViewModel
            {
                Periodo        = "2024 - II",
                NombreAlumno   = "García Pérez, Juan Carlos",
                CodigoAlumno   = "19200045",
                CicloActual    = 4,
                CicloSiguiente = 5,
                Cursos = new List<CursoPreMatricula>
                {
                    new CursoPreMatricula { Codigo="MAT401", Nombre="Cálculo IV",                       Creditos=4, Prerequisito="MAT301", HabilitadoPrereq=true,  CicloSugerido=5 },
                    new CursoPreMatricula { Codigo="SIS301", Nombre="Base de Datos II",                 Creditos=3, Prerequisito="SIS201", HabilitadoPrereq=true,  CicloSugerido=5 },
                    new CursoPreMatricula { Codigo="PRO401", Nombre="Programación Orientada a Objetos", Creditos=3, Prerequisito="PRO301", HabilitadoPrereq=true,  CicloSugerido=5 },
                    new CursoPreMatricula { Codigo="SIS302", Nombre="Ingeniería de Software II",        Creditos=4, Prerequisito="SIS202", HabilitadoPrereq=false, CicloSugerido=5 },
                    new CursoPreMatricula { Codigo="RED201", Nombre="Seguridad en Redes",               Creditos=3, Prerequisito="RED101", HabilitadoPrereq=true,  CicloSugerido=5 },
                    new CursoPreMatricula { Codigo="HUM301", Nombre="Gestión Empresarial",              Creditos=2, Prerequisito="—",       HabilitadoPrereq=true,  CicloSugerido=5 },
                }
            };
            return View(vm);
        }
    }
}
