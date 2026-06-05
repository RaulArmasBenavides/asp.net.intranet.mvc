using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class CursoController : Controller
    {
        private static int _nextId = 7;
        private static readonly List<Course> _cursos = new List<Course>
        {
            new Course { CourseId = 1, Code = "MAT101", Name = "Cálculo I",              Credits = 4, WeeklyHours = 6, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 1, DateCreated = DateTime.Today },
            new Course { CourseId = 2, Code = "MAT102", Name = "Cálculo II",             Credits = 4, WeeklyHours = 6, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 1, DateCreated = DateTime.Today },
            new Course { CourseId = 3, Code = "FIS101", Name = "Física General",         Credits = 3, WeeklyHours = 5, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 2, DateCreated = DateTime.Today },
            new Course { CourseId = 4, Code = "PRO101", Name = "Programación I",         Credits = 3, WeeklyHours = 4, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 3, DateCreated = DateTime.Today },
            new Course { CourseId = 5, Code = "PRO201", Name = "Estructura de Datos",    Credits = 3, WeeklyHours = 4, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 3, DateCreated = DateTime.Today },
            new Course { CourseId = 6, Code = "BAS101", Name = "Lenguaje y Comunicación",Credits = 2, WeeklyHours = 3, EducationLevel = "Pregrado", IsActive = true, DepartmentId = 4, DateCreated = DateTime.Today },
        };

        public ActionResult Index() => View();

        // ── JSON endpoints para Generic.js ───────────────────────────────────

        public JsonResult ListarCursos()
        {
            return Json(_cursos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CursoBuscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Json(_cursos, JsonRequestBehavior.AllowGet);

            var resultado = _cursos
                .Where(c => ContainsIgnoreCase(c.Name, nombre) || ContainsIgnoreCase(c.Code, nombre))
                .ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CursoObtener(int CourseId)
        {
            var curso = _cursos.FirstOrDefault(c => c.CourseId == CourseId);
            return Json(curso, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Course curso)
        {
            if (curso.CourseId == 0)
            {
                curso.CourseId   = _nextId++;
                curso.IsActive   = true;
                curso.DateCreated = DateTime.Today;
                _cursos.Add(curso);
            }
            else
            {
                var existente = _cursos.FirstOrDefault(c => c.CourseId == curso.CourseId);
                if (existente != null)
                {
                    existente.Code           = curso.Code;
                    existente.Name           = curso.Name;
                    existente.Credits        = curso.Credits;
                    existente.WeeklyHours    = curso.WeeklyHours;
                    existente.EducationLevel = curso.EducationLevel;
                    existente.Description    = curso.Description;
                }
            }
            return Content("1");
        }

        public ActionResult Delete(int CourseId)
        {
            var curso = _cursos.FirstOrDefault(c => c.CourseId == CourseId);
            if (curso == null) return Content("0");
            _cursos.Remove(curso);
            return Content("1");
        }

        private static bool ContainsIgnoreCase(string source, string value)
            => source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
