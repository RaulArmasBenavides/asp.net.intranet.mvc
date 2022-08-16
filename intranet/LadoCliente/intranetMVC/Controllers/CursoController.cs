using intranetMVC.Models;
using System.Net;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class CursoController : Controller
    {
        //WCFIntranetClient cliente = new WCFIntranetClient();
        // GET: Curso
        public ActionResult Index()
        {
            //var cursoes = db.Cursoes.Include(c => c.Tarifa);
            //return View(cursoes.ToList());
            return View();
        }

        // GET: Curso/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = null; // db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            //ViewBag.IdTarifa = new SelectList(db.Tarifas, "IdTarifa", "Descripcion");
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCurso,IdTarifa,NomCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                //db.Cursoes.Add(curso);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.IdTarifa = new SelectList(db.Tarifas, "IdTarifa", "Descripcion", curso.IdTarifa);
            return View(curso);
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = null;// db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdTarifa = new SelectList(db.Tarifas, "IdTarifa", "Descripcion", curso.IdTarifa);
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurso,IdTarifa,NomCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(curso).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.IdTarifa = new SelectList(db.Tarifas, "IdTarifa", "Descripcion", curso.IdTarifa);
            return View(curso);
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = null;// db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
           // Curso curso = db.Cursoes.Find(id);
           // db.Cursoes.Remove(curso);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

       

    }
}
