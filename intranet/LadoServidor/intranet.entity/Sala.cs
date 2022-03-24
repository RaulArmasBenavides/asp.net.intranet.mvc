using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    public class Sala
    {
        public int idsala { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public int capacidad { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string estado { get; set; }
        public string rol_creacion { get; set; }
        public string tipo_sala { get; set; }
    }
}
