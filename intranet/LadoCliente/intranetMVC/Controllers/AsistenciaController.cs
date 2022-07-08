using intranetMVC.WCFCliente;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class AsistenciaController : Controller
    {

        //WCFIntranetClient cliente = new WCFIntranetClient();

        // GET: Asistencia
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asistencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asistencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asistencia/Create
        [HttpPost]
        public ActionResult Create(Asistencias asis)
        {
            try
            {
                //cliente.AsistenciaAdicionar(asis);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asistencia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asistencia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asistencia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asistencia/Delete/5
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
    }
}
