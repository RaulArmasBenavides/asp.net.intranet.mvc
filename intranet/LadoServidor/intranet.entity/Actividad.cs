using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    public class Actividad
    {
        public Actividad()
        {
            this.descripcion = string.Empty;
            this.rol_creacion = "SGIT";
            this.Nombre = string.Empty;
            this.fecha_creacion = DateTime.Today;
            this.fec_inicio = DateTime.Today;
            this.fec_fin = DateTime.Today;

        }
        public int idactividad { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fec_inicio { get; set; }
        public DateTime fec_fin { get; set; }
        public string rol_creacion { get; set; }
        public string estado { get; set; }
        public string rol_responsable { get; set; }
        public int idlistaeq { get; set; }
        public int idasistencias { get; set; }
        public int idsala { get; set; }
    }
}
