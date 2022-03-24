using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    public class ListaEquipos
    {

        public int idlistaeq { get; set; }
        public int idEquipo { get; set; }
        public string codigo { get; set; }
        public string Nombre { get; set; }
        public string Procesador { get; set; }
        public string RAM { get; set; }
        public string SO { get; set; }
        public string TarjetaMadre { get; set; }
    }
}
