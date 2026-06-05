using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class SalaController : Controller
    {
        private static int _nextId = 6;
        private static readonly List<Sala> _salas = new List<Sala>
        {
            new Sala { IdSala = 1, Nombre = "Aula 101",           Capacidad = 40,  TipoSala = "Teoría",       Ubicacion = "Pabellón A - Piso 1", Estado = "Disponible"       },
            new Sala { IdSala = 2, Nombre = "Aula 201",           Capacidad = 35,  TipoSala = "Teoría",       Ubicacion = "Pabellón A - Piso 2", Estado = "Disponible"       },
            new Sala { IdSala = 3, Nombre = "Lab. Cómputo 01",    Capacidad = 25,  TipoSala = "Laboratorio",  Ubicacion = "Pabellón B - Piso 1", Estado = "Disponible"       },
            new Sala { IdSala = 4, Nombre = "Lab. Cómputo 02",    Capacidad = 25,  TipoSala = "Laboratorio",  Ubicacion = "Pabellón B - Piso 2", Estado = "En Mantenimiento" },
            new Sala { IdSala = 5, Nombre = "Auditorio Principal", Capacidad = 200, TipoSala = "Auditorio",   Ubicacion = "Edificio Central",    Estado = "Disponible"       },
        };

        public ActionResult Index() => View();

        // ── JSON endpoints para Generic.js ───────────────────────────────────

        public JsonResult ListarSalas()
        {
            return Json(_salas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SalaBuscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Json(_salas, JsonRequestBehavior.AllowGet);

            var resultado = _salas
                .Where(s => ContainsIgnoreCase(s.Nombre, nombre)
                         || ContainsIgnoreCase(s.TipoSala, nombre)
                         || ContainsIgnoreCase(s.Ubicacion, nombre))
                .ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SalaObtener(int IdSala)
        {
            var sala = _salas.FirstOrDefault(s => s.IdSala == IdSala);
            return Json(sala, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Sala sala)
        {
            if (sala.IdSala == 0)
            {
                sala.IdSala = _nextId++;
                _salas.Add(sala);
            }
            else
            {
                var existente = _salas.FirstOrDefault(s => s.IdSala == sala.IdSala);
                if (existente != null)
                {
                    existente.Nombre    = sala.Nombre;
                    existente.Capacidad = sala.Capacidad;
                    existente.TipoSala  = sala.TipoSala;
                    existente.Ubicacion = sala.Ubicacion;
                    existente.Estado    = sala.Estado;
                }
            }
            return Content("1");
        }

        public ActionResult Delete(int IdSala)
        {
            var sala = _salas.FirstOrDefault(s => s.IdSala == IdSala);
            if (sala == null) return Content("0");
            _salas.Remove(sala);
            return Content("1");
        }

        private static bool ContainsIgnoreCase(string source, string value)
            => source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
