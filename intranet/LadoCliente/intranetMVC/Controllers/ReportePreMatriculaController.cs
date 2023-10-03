using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intranetMVC.Controllers
{
    public class ReportePreMatriculaController : Controller
    {
        // GET: ReportePreMatricula
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Obtener el nombre del archivo
                string fileName = Path.GetFileName(file.FileName);

                // Guardar el archivo en una ubicación específica
                string filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(filePath);

                // Mostrar un mensaje de éxito
                ViewBag.Message = "File uploaded successfully.";
            }
            else
            {
                // Mostrar un mensaje de error si no se selecciona ningún archivo
                ViewBag.Message = "Please select a file.";
            }

            return View("Index");
        }
    }
}