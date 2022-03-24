using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranetMVC.Models
{
    public class Usuario
    {

        public Usuario()
        {
            usuario = string.Empty;
            password = string.Empty;
        }

        public string usuario { get; set; }

        public string password { get; set; }
    }
}