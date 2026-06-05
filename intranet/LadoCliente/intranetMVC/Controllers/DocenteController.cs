using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class DocenteController : Controller
    {
        private static int _nextId = 6;
        private static readonly List<Docente> _docentes = new List<Docente>
        {
            new Docente { IdDocente=1, Apellidos="Huanca Flores",  Nombres="Roberto Carlos", DNI="12345678", Especialidad="Matemáticas",  Departamento="Ciencias",    Email="rhuanca@unmsm.edu.pe",  Categoria="Principal", Dedicacion="TC" },
            new Docente { IdDocente=2, Apellidos="Quispe Ríos",    Nombres="María Elena",    DNI="23456789", Especialidad="Algoritmos",    Departamento="Informática", Email="mquispe@unmsm.edu.pe",  Categoria="Asociado",  Dedicacion="TC" },
            new Docente { IdDocente=3, Apellidos="Torres Medina",  Nombres="Jorge Luis",     DNI="34567890", Especialidad="Base de Datos", Departamento="Informática", Email="jtorres@unmsm.edu.pe",  Categoria="Principal", Dedicacion="TC" },
            new Docente { IdDocente=4, Apellidos="Salinas Cruz",   Nombres="Ana Patricia",   DNI="45678901", Especialidad="Redes",         Departamento="Informática", Email="asalinas@unmsm.edu.pe", Categoria="Asociado",  Dedicacion="TP" },
            new Docente { IdDocente=5, Apellidos="Paredes Soto",   Nombres="Carlos Alberto", DNI="56789012", Especialidad="Estadística",   Departamento="Ciencias",    Email="cparedes@unmsm.edu.pe", Categoria="Auxiliar",  Dedicacion="TC" },
        };

        public ActionResult Index() => View();

        public JsonResult ListarDocentes()
            => Json(_docentes, JsonRequestBehavior.AllowGet);

        public JsonResult DocenteBuscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Json(_docentes, JsonRequestBehavior.AllowGet);

            var r = _docentes.Where(d =>
                CI(d.Apellidos, nombre) || CI(d.Nombres, nombre) ||
                CI(d.Especialidad, nombre) || CI(d.DNI, nombre)).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DocenteObtener(int IdDocente)
            => Json(_docentes.FirstOrDefault(d => d.IdDocente == IdDocente), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public ActionResult Create(Docente doc)
        {
            if (doc.IdDocente == 0) { doc.IdDocente = _nextId++; _docentes.Add(doc); }
            else
            {
                var e = _docentes.FirstOrDefault(d => d.IdDocente == doc.IdDocente);
                if (e != null) { e.Apellidos=doc.Apellidos; e.Nombres=doc.Nombres; e.DNI=doc.DNI;
                    e.Especialidad=doc.Especialidad; e.Departamento=doc.Departamento;
                    e.Email=doc.Email; e.Categoria=doc.Categoria; e.Dedicacion=doc.Dedicacion; }
            }
            return Content("1");
        }

        public ActionResult Delete(int IdDocente)
        {
            var d = _docentes.FirstOrDefault(x => x.IdDocente == IdDocente);
            if (d == null) return Content("0");
            _docentes.Remove(d);
            return Content("1");
        }

        private static bool CI(string s, string v)
            => s != null && s.IndexOf(v, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
