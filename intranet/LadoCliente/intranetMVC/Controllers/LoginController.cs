
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using intranetMVC.Models;
using System.Web.Mvc;
using intranetMVC.WCFCliente;

namespace intranetMVC.Controllers
{
    public class LoginController : Controller
    {
        WCFIntranetClient cliente = new WCFIntranetClient();
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

        [HttpPost]
        public ActionResult Autenticar(WCFCliente.Usuario us)
        {
            try
            {
                if (!cliente.Validarusuario(us))
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