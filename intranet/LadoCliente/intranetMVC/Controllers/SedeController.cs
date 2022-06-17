using intranetMVC.Models;
using intranetMVC.WCFCliente;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class SedeController : Controller
    {
        WCFIntranetClient cliente = new WCFIntranetClient();
        // GET: Sede
        public ActionResult Index()
        {
            return View(cliente.SedesListar(new SedesListarRequest()));
        }

        // GET: Sede/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        [HttpPost]
        public ActionResult Create(Sede e)
        {
            try { 
                SedeAdicionarRequest re = new SedeAdicionarRequest();
                re.sed = e;
                cliente.SedeAdicionar(re);
                ViewBag.JavaScriptFunction = "swal('Proceso con éxito', 'Sede registrado con éxito!', 'success');";
                return View(); //RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sede/Edit/5
        [HttpPost]
        public ActionResult Edit(Sede e)
        {
            SedeActualizarRequest re = new SedeActualizarRequest();
            re.sed = e;
            try
            {
                cliente.SedeActualizar(re);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sede/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sede/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult ListarSedes()
        {
            JsonResult result = Json(cliente.SedesListar(new SedesListarRequest()), JsonRequestBehavior.AllowGet);
            return result;        
        }
    }
}
