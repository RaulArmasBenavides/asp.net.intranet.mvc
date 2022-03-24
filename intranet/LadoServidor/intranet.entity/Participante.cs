using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    public class Participante
    {
        public Participante()
        {
            this.ap_materno = string.Empty;
            this.ap_paterno = string.Empty;
            this.nombre = string.Empty;
        }

        public int idparticipante { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public string correo { get; set; }
        public string DNI { get; set; }
        public string carrera { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string tipo_participante { get; set; }
    }
}
