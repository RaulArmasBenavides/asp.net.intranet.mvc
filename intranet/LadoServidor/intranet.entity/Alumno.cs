using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    public class Alumno
    {
        public Alumno()
        {
            this.IdAlumno = 0;
            this.NomAlumno = string.Empty;
            this.ApeMatAlumno = string.Empty;
            this.ApePatAlumno = string.Empty;
            this.CodigoAlu = string.Empty;
        }
        //[DisplayName("IdAlumno")]
        //[Required(ErrorMessage = "El IdAlumno es requerido.")]
        public int IdAlumno { get; set; }

        public string CodigoAlu { get; set; }
        //[DisplayName("ApeAlumno")]
        //[Required, StringLength(30)]
        public string ApePatAlumno { get; set; }
        public string ApeMatAlumno { get; set; }
        public string NomAlumno { get; set; }
        public string DirAlumno { get; set; }
        public string TelAlumno { get; set; }
        public string EmailAlumno { get; set; }
        public string DNI { get; set; }
        public string Escuela { get; set; }
        public int Creditos { get; set; }
    }
}
