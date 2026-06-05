using intranetMVC.Models;
using intranetMVC.Models.Academico;
using intranetMVC.Proxy;
using intranetMVC.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly WCFCustomIntranetClient client = new WCFCustomIntranetClient();

        public ActionResult Index() => View();

        public ActionResult Search() => View();

        public ActionResult Horario()
        {
            var vm = new HorarioViewModel
            {
                Periodo = "2024 - I",
                Dias    = new[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" },
                Clases  = HorarioHelper.ObtenerClases()
            };
            return View(vm);
        }

        public ActionResult Perfil()
        {
            var modelo = new PerfilViewModel
            {
                NombreCompleto    = "García Pérez, Juan Carlos",
                CodigoAlumno     = "19200045",
                DNI              = "75312489",
                FechaNacimiento  = "15/03/2001",
                Sexo             = "Masculino",
                Email            = "jgarcia@unmsm.edu.pe",
                Telefono         = "987654321",
                Direccion        = "Jr. Los Pinos 234",
                Distrito         = "San Martín de Porres",
                Provincia        = "Lima",
                Departamento     = "Lima",
                Facultad         = "Facultad de Ingeniería de Sistemas e Informática",
                Carrera          = "Ingeniería de Sistemas",
                Modalidad        = "Presencial",
                Turno            = "Mañana",
                Estado           = "Regular",
                CicloActual      = 4,
                Promedio         = 14.75m,
                CreditosAprobados = 58,
                AnioIngreso      = "2019",
                Tutor            = "Dr. Quispe Mendoza, Roberto"
            };
            return View(modelo);
        }

        public ActionResult DatosPersonales()
        {
            var modelo = new PerfilViewModel
            {
                NombreCompleto    = "García Pérez, Juan Carlos",
                CodigoAlumno     = "19200045",
                DNI              = "75312489",
                FechaNacimiento  = "15/03/2001",
                Sexo             = "Masculino",
                Email            = "jgarcia@unmsm.edu.pe",
                Telefono         = "987654321",
                Direccion        = "Jr. Los Pinos 234",
                Distrito         = "San Martín de Porres",
                Provincia        = "Lima",
                Departamento     = "Lima",
                Facultad         = "Facultad de Ingeniería de Sistemas e Informática",
                Carrera          = "Ingeniería de Sistemas",
                Modalidad        = "Presencial",
                Turno            = "Mañana",
                Estado           = "Regular",
                CicloActual      = 4,
                Promedio         = 14.75m,
                CreditosAprobados = 58,
                AnioIngreso      = "2019",
                Tutor            = "Dr. Quispe Mendoza, Roberto"
            };
            return View(modelo);
        }

        public ActionResult Historial()
        {
            var modelo = new HistorialViewModel
            {
                NombreCompleto    = "García Pérez, Juan Carlos",
                CodigoAlumno     = "19200045",
                Facultad         = "Facultad de Ingeniería de Sistemas e Informática",
                Carrera          = "Ingeniería de Sistemas",
                Modalidad        = "Presencial",
                CicloActual      = 4,
                PromedioGeneral  = 14.75m,
                CreditosAprobados = 58,
                Cursos = new List<CursoHistorial>
                {
                    // 2024 - I
                    new CursoHistorial { Anio=2024, Semestre="I", Codigo="MAT201", NombreCurso="Cálculo II",              Creditos=4, Nota=15.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2024, Semestre="I", Codigo="FIS101", NombreCurso="Física General",          Creditos=3, Nota=13.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2024, Semestre="I", Codigo="PRO201", NombreCurso="Estructura de Datos",     Creditos=3, Nota=16.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2024, Semestre="I", Codigo="ALG101", NombreCurso="Álgebra Lineal",          Creditos=3, Nota=12.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2024, Semestre="I", Codigo="HUM201", NombreCurso="Ética Profesional",       Creditos=2, Nota=17.00m, Estado="Aprobado"    },
                    // 2023 - II
                    new CursoHistorial { Anio=2023, Semestre="II", Codigo="MAT101", NombreCurso="Cálculo I",             Creditos=4, Nota=14.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2023, Semestre="II", Codigo="PRO101", NombreCurso="Programación I",        Creditos=3, Nota=18.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2023, Semestre="II", Codigo="BAS101", NombreCurso="Lenguaje y Comunicación",Creditos=2, Nota=15.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2023, Semestre="II", Codigo="QUI001", NombreCurso="Química General",       Creditos=3, Nota=10.00m, Estado="Aprobado"    },
                    // 2023 - I
                    new CursoHistorial { Anio=2023, Semestre="I", Codigo="INT001", NombreCurso="Introducción a la Ing.", Creditos=3, Nota=17.00m, Estado="Aprobado"    },
                    new CursoHistorial { Anio=2023, Semestre="I", Codigo="MAT000", NombreCurso="Pre-Cálculo",           Creditos=4, Nota=08.00m, Estado="Desaprobado"  },
                    new CursoHistorial { Anio=2023, Semestre="I", Codigo="HUM001", NombreCurso="Realidad Nacional",      Creditos=2, Nota=16.00m, Estado="Aprobado"    },
                }
            };
            return View(modelo);
        }

        // ── JSON endpoints para Generic.js ───────────────────────────────────

        public JsonResult getClientes()
        {
            var lista = client.AlumnoListar3() ?? new List<Student>();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AlumnoBuscar(string nombre)
        {
            var todos = client.AlumnoListar3() ?? new List<Student>();
            if (string.IsNullOrWhiteSpace(nombre))
                return Json(todos, JsonRequestBehavior.AllowGet);

            var filtrados = todos.Where(a =>
                ContainsIgnoreCase(a.NomAlumno,    nombre) ||
                ContainsIgnoreCase(a.ApePatAlumno, nombre) ||
                ContainsIgnoreCase(a.ApeMatAlumno, nombre) ||
                ContainsIgnoreCase(a.DNI,          nombre)
            ).ToList();

            return Json(filtrados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AlumnoObtener(string IdAlumno)
        {
            var alumno = client.find(IdAlumno);
            return Json(alumno, JsonRequestBehavior.AllowGet);
        }

        // ── CRUD ─────────────────────────────────────────────────────────────

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create([Bind(Include = "IdAlumno,ApePatAlumno,ApeMatAlumno,NomAlumno,DirAlumno,TelAlumno,EmailAlumno,DNI,Sexo")] Student alumno)
        {
            bool ok = client.createStudent(alumno);
            return Content(ok ? "1" : "0");
        }

        public ActionResult Edit(string id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlumno,ApePatAlumno,ApeMatAlumno,NomAlumno,DirAlumno,TelAlumno,EmailAlumno,DNI,Sexo")] Student alumno)
        {
            if (ModelState.IsValid)
            {
                client.edit(alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        public async Task<ActionResult> Delete(string IdAlumno)
        {
            if (string.IsNullOrEmpty(IdAlumno))
                return Content("0");
            try
            {
                bool ok = await client.delete(IdAlumno);
                return Content(ok ? "1" : "0");
            }
            catch
            {
                return Content("0");
            }
        }

        public void Excel()
        {
            StudentExcel excel = new StudentExcel();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Students.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.End();
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static bool ContainsIgnoreCase(string source, string value)
        {
            return source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
