﻿using intranetMVC.Models;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class SedeController : Controller
    {
        //WCFIntranetClient cliente = new WCFIntranetClient();
        // GET: Sede
        public ActionResult Index()
        {
            return View();
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
            try
            {
                //cliente.SedeAdicionarAsync(e);
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
            try
            {
                //cliente.SedeActualizar(e);
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


        //public JsonResult ListarSedes()
        //{
        //    //JsonResult result = Json(cliente.SedesListar(), JsonRequestBehavior.AllowGet);
        //    //return result;        
        //}
    }
}
