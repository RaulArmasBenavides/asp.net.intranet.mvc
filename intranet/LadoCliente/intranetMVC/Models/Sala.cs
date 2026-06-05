using System;

namespace intranetMVC.Models
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string TipoSala { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
    }
}
