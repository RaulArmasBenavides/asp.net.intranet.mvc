using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranetMVC.Models
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
            this.DNI = string.Empty;
            this.Carrera = string.Empty;
            this.EmailAlumno = string.Empty;
            this.Tipo = string.Empty;

        }

        public int IdAlumno { get; set; }

        public string ApePatAlumno { get; set; }

        public string ApeMatAlumno { get; set; }

        public string NomAlumno { get; set; }

        public string DNI { get; set; }

        public string CodigoAlu { get; set; }

        public string TelAlumno { get; set; }

        public char Sexo { get; set; }

        public string EmailAlumno { get; set; }

        public string DirAlumno { get; set; }

        public string Tipo { get; set; }

        public string Carrera { get; set; }
    }
}