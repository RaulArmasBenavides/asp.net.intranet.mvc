using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class SedeController : Controller
    {
        private static int _nextId = 4;
        private static readonly List<Campus> _sedes = new List<Campus>
        {
            new Campus { Idsede = 1, Nombre = "Sede Ciudad Universitaria", Direccion = "Av. Universitaria s/n, Lima" },
            new Campus { Idsede = 2, Nombre = "Sede Los Olivos",           Direccion = "Av. Los Olivos 1234, Lima Norte" },
            new Campus { Idsede = 3, Nombre = "Sede Villa El Salvador",    Direccion = "Av. Revolución 567, VES" },
        };

        public ActionResult Index() => View();

        // ── JSON endpoints para Generic.js ───────────────────────────────────

        public JsonResult ListarSedes()
        {
            return Json(_sedes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SedeBuscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Json(_sedes, JsonRequestBehavior.AllowGet);

            var resultado = _sedes
                .Where(s => ContainsIgnoreCase(s.Nombre, nombre) || ContainsIgnoreCase(s.Direccion, nombre))
                .ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SedeObtener(int IdSede)
        {
            var sede = _sedes.FirstOrDefault(s => s.Idsede == IdSede);
            return Json(sede, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Campus sede)
        {
            if (sede.Idsede == 0)
            {
                sede.Idsede = _nextId++;
                _sedes.Add(sede);
            }
            else
            {
                var existente = _sedes.FirstOrDefault(s => s.Idsede == sede.Idsede);
                if (existente != null)
                {
                    existente.Nombre    = sede.Nombre;
                    existente.Direccion = sede.Direccion;
                }
            }
            return Content("1");
        }

        public ActionResult Delete(int IdSede)
        {
            var sede = _sedes.FirstOrDefault(s => s.Idsede == IdSede);
            if (sede == null) return Content("0");
            _sedes.Remove(sede);
            return Content("1");
        }

        private static bool ContainsIgnoreCase(string source, string value)
            => source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
