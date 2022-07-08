
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using intranetMVC.Models;
using System.Web.Mvc;
//using intranetMVC.WCFCliente;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Text;

namespace intranetMVC.Controllers
{
    public class LoginController : Controller
    {
        private string BASE_URL = "http://localhost:17476/WCFIntranet.svc/";
        //WCFIntranetClient cliente = new WCFIntranetClient();
        // private EduTecEntities db = new EduTecEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            //recuparar valor de la variable de session
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        //[HttpPost]
        //public ActionResult Autenticar(Empleado usuario)
        //{

        //try
        //{

        //      var usuario1 = dao.validar(usuario.Nombre, usuario.Apellidos);
        //    if (usuario1 == null)
        //    {
        //       // usuario.LoginErrorMessage = "El usuario o password es incorrecto.";
        //        return View("Index", usuario);
        //    }
        //    else
        //    {
        //        //CREAR SESSION Y ASIGNAR VALORES
        //        Session["userID"] = usuario.IdEmpleado;
        //        Session["userName"] = usuario.Nombre;
        //        //Session["usuario"] = usuario1;
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //catch (Exception e)
        //{
        //    throw e;
        //}

        //  }


        public bool Validarusuario(Response<Usuario> u)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response<Usuario>));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, u);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Usuario/Validarusuario", "POST", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//
        [HttpPost]
        public ActionResult Autenticar(Usuario us)
        {
            try
            {

                Response<Usuario> res = new Response<Usuario>();
                res.myObject = us;
                if (!this.Validarusuario(res))
                {
                    //usuario.LoginErrorMessage = "El usuario o password es incorrecto.";
                    Session["userName"] = null;
                    return View("Index", us);
                }
                else
                {
                    //CREAR SESSION Y ASIGNAR VALORES
                    //Session["userID"] = us.i;
                    Session["userName"] = us.user;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}