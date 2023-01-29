using intranetMVC.Models;
using intranetMVC.Proxy;
using intranetMVC.Reportes;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace intranetMVC.Controllers
{
    public class AlumnoController : Controller
    {
        //private EduTecEntities db = new EduTecEntities();
        //WCFIntranetClient cliente = new WCFIntranetClient();
        WCFCustomIntranetClient client = new WCFCustomIntranetClient();

        
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getClientes()
        {
            var res = Json(client.AlumnoListar3(),JsonRequestBehavior.AllowGet);
            return res;
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }

        //public JsonResult AlumnoDatos()
        //{
        //    var alumno = new Alumno()
        //    {
        //        ID = 101,
        //        Nombre = "Juan Perez",
        //        Curso = "ASP NET MVC 5",
        //        Notas = new int[] { 17, 15, 14, 16 }
        //    };
        //    return Json(alumno, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult Search3(string input)
        //{
        //    //EduTecEntities edu = new EduTecEntities();
        //    //SqlMethods.Like(r.NomAlumno, "ronnie")
        //    //var result = from r in edu.Alumnoes
        //    //             where r.NomAlumno == input
        //    //             select new { r.IdAlumno,r.NomAlumno, r.ApeAlumno };

        //   // return Json(result, JsonRequestBehavior.AllowGet);
        //}


        // GET: Alumno/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Alumno alumno = null;// db.Alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlumno,ApePatAlumno,ApeMatAlumno,NomAlumno,DirAlumno,TelAlumno,EmailAlumno,DNI,Sexo")] Alumno alumno)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Alumnoes.Add(alumno);
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            // cliente.AlumnoAdicionar(alumno);
            client.createStudent(alumno);
            //ViewBag.JavaScriptFunction = "swal('Éxito!', 'Se registró el nuevo alumno con éxito!', 'Éxito');";
            return View();
            //return View(alumno);
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ////Alumno alumno = cliente.AlumnoBuscar(Convert.ToInt32(id)); //null; // db.Alumnoes.Find(id);
            //if (alumno == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlumno,ApePatAlumno,ApeMatAlumno,NomAlumno,DirAlumno,TelAlumno,EmailAlumno,DNI,Sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                //cliente.AlumnoActualizar(alumno);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<bool> Delete(string IdAlumno)
        {
            bool res = false;
            if (IdAlumno != null)
            {
               res = await client.delete(IdAlumno);
                //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return res;
            //Alumno alumno = null; // db.Alumnoes.Find(id);
            //if (alumno == null)
            //{
            //    return HttpNotFound();
            //}
            //return View();
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                //db.Alumnoes.Remove(db.Alumnoes.Find(id));
                // db.Alumnoes.Remove(alumno);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Imprimir()
        {
            //   return View(db.Alumnoes.ToList());
            return View();
        }



        //imprimir 
        //public ActionResult ImprimirPDF()
        //{
        //    //var userdetails = new List<Alumno>()
        //    //{
        //    //    //new user() {id = 101, nombre = "juan perez", direccion = "av. lima 123",email = "jperez@gmail.com"},
        //    //    //new user() {id = 102, nombre = "fanny chiara", direccion = "av. peru 890",email = "fchiara@gmail.com"},
        //    //    //new user() {id = 103, nombre = "ricardo flores", direccion = "calle los olivos 234",email = "rfloresz@gmail.com"},
        //    //    //new user() {id = 104, nombre = "milagros aguilar", direccion = "jr. viru 111",email = "maguilarz@hotmail.com"},
        //    //    //new user() {id = 105, nombre = "raquel medina", direccion = "av. san juan 345",email = "rmedina@gmail.com"},
        //    //    //new user() {id = 106, nombre = "fredy luna", direccion = "jr. los cipreces 233",email = "fluna@hotmail.com"},
        //    //};
        //    //Excel();

        //    //return new Rotativa.MVC.ActionAsPdf("Imprimir")
        //    //{
        //    //    FileName = "test.pdf"
        //    //};  //.PdfResult(db.Alumnoes.ToList(), "Imprimir");
        //}

        //public void Excel()
        //{
        //    string etapa = "";
        //    int nroFila = 0;
        //    string ruta = @"C:\Users\RAUL\Documents\rmab\report";
        //    byte[] archivoExcelSalida = null;
        //    OfficeOpenXml.ExcelPackage paqueteExcel = null;
        //    OfficeOpenXml.ExcelWorksheet hojaExcel = null;
        //    string nombreArchivo = "ReporteErrores.xlsx";
        //    OfficeOpenXml.ExcelRange celda;
        //    System.IO.FileStream archivoExcel = null;

        //    ruta += nombreArchivo;
        //    archivoExcel = new System.IO.FileStream(ruta, System.IO.FileMode.OpenOrCreate);
        //    etapa = "CARGÓ FILESTREAM";

        //    paqueteExcel = new OfficeOpenXml.ExcelPackage(archivoExcel);
        //    etapa = "ABRIÓ PAQUETE EXCEL";

        //    //Ventas
        //    hojaExcel = paqueteExcel.Workbook.Worksheets.Add("Compras");
        //    etapa = "GENERÓ HOJA EXCEL";

        //    //cabecera
        //    nroFila = 1;
        //    nroFila = 4;//SeteaCabeceraExcel(ref hojaExcelCompras, 1, 1, 17, "Consulta Generica de los Comprobantes de Compra", parametrosComprobante.EmpresaEjecucion.Nombre.Trim(), filtroComprobante);
        //    etapa = "SETEÓ CABECERA EXCEL COMPRAS";
        //    //titulos
        //    nroFila += 1;
        //    hojaExcel.Cells[nroFila, 1].Value = "Nro_Solicitud";
        //    hojaExcel.Cells[nroFila, 2].Value = "Fecha_pagador";
        //    hojaExcel.Cells[nroFila, 3].Value = "Hora_pagador";
        //    hojaExcel.Cells[nroFila, 4].Value = "Proceso";
        //    hojaExcel.Cells[nroFila, 5].Value = "Descripción del error";
        //    //hojaExcel.Cells[nroFila, 6].Value = "Número ID";
        //    //hojaExcel.Cells[nroFila, 7].Value = "Razón Social";
        //    //hojaExcel.Cells[nroFila, 8].Value = "Fecha Emisión";
        //    //hojaExcel.Cells[nroFila, 9].Value = "Estado";
        //    //hojaExcel.Cells[nroFila, 10].Value = "Total a Pagar";
        //    //hojaExcel.Cells[nroFila, 11].Value = "Moneda";
        //    //hojaExcel.Cells[nroFila, 12].Value = "Origen";
        //    //hojaExcel.Cells[nroFila, 13].Value = "CR";
        //    //hojaExcel.Cells[nroFila, 14].Value = "Tipo Detrac.";
        //    //hojaExcel.Cells[nroFila, 15].Value = "Derivado";
        //    //hojaExcel.Cells[nroFila, 16].Value = "Rol Digitador";
        //    //hojaExcel.Cells[nroFila, 17].Value = "Fecha Digitación";

        //    hojaExcel.Cells[nroFila, 1, nroFila, 17].Style.Font.Size = 12;
        //    hojaExcel.Cells[nroFila, 1, nroFila, 17].Style.Font.Bold = true;
        //    hojaExcel.Cells[nroFila, 1, nroFila, 17].Style.Font.Color.SetColor(System.Drawing.Color.DarkBlue);
        //    //hojaExcel.Cells[nroFila, 1, nroFila, 17].AutoFilter = true;

        //    etapa = "SETEÓ DATOS EXCEL COMPRAS";

        //    paqueteExcel.Save();
        //    etapa = "GUARDANDO EXCEL";

        //    archivoExcelSalida = System.IO.File.ReadAllBytes(ruta);
        //    etapa = "RETORNANDO EXCEL";
        //}

        //Métodos para generar reporte en  Excel
        public void Excel()
        {
            StudentExcel excel = new StudentExcel();
            Response.ClearContent();
            //Response.BinaryWrite(excel.GenerateExcel(GetStudents()));
            Response.AddHeader("content-disposition", "attachment;filename = Students.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheet";
            Response.Flush();
            Response.End();
        }







    }
}
