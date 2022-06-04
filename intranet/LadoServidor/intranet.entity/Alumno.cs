using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    [DataContract]
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

        [DataMember(Name = "IdAlumno", Order = 1)]
        public int IdAlumno { get; set; }

        [DataMember(Name = "CodigoAlu", Order = 1)]
        public string CodigoAlu { get; set; }

        [DataMember(Name = "ApePatAlumno", Order = 1)]
        public string ApePatAlumno { get; set; }

        [DataMember(Name = "ApeMatAlumno", Order = 1)]
        public string ApeMatAlumno { get; set; }

        [DataMember(Name = "NomAlumno", Order = 1)]
        public string NomAlumno { get; set; }

        [DataMember(Name = "DirAlumno", Order = 1)]
        public string DirAlumno { get; set; }

        [DataMember(Name = "TelAlumno", Order = 1)]
        public string TelAlumno { get; set; }

        [DataMember(Name = "EmailAlumno", Order = 1)]
        public string EmailAlumno { get; set; }

        [DataMember(Name = "Sexo", Order = 1)]
        public char Sexo { get; set; }

        [DataMember(Name = "Tipo", Order = 1)]
        public string Tipo { get; set; }

        [DataMember(Name = "DNI", Order = 1)]
        public string DNI { get; set; }

        [DataMember(Name = "Carrera", Order = 1)]
        public string Carrera { get; set; }

    }
}
