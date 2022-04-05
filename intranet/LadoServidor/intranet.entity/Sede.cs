using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{

    [DataContract]
    public class Sede
    {
        public Sede()
        {

        }

        [DataMember(Name = "user", Order = 1)]
        public int idsede { get; set; }
        [DataMember(Name = "nombre", Order = 2)]
        public string nombre { get; set; }
        [DataMember(Name = "direccion", Order = 3)]
        public string direccion { get; set; }

    }
}
