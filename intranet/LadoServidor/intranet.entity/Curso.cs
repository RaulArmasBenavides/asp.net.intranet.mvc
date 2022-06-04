using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    [DataContract]
    public class Curso
    {

        public  Curso()
        {

        }

        [DataMember(Name = "idcurso", Order = 1)]
        public int idcurso { get; set; }

        [DataMember(Name = "NombreCurso", Order = 2)]
        public string NombreCurso { get; set; }

        [DataMember(Name = "Estado", Order = 3)]
        public string Estado { get; set; }

        [DataMember(Name = "Tipo", Order = 4)]
        public char Tipo { get; set; }

        [DataMember(Name = "Malla", Order = 5)]
        public char Malla { get; set; }

        [DataMember(Name = "idclclo", Order = 6)]
        public int idclclo { get; set; }

        [DataMember(Name = "idTarifa", Order =7)]
        public int idTarifa { get; set; }


        //public string docente { get; set; }
        //public int creditaje { get; set; }
        //public int seccion { get; set; }
    }
}
