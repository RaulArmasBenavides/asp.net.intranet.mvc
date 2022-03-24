using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace intranet.entity
{
    [DataContract]
    public class Usuario
    {
  
        public Usuario()
        {
            user = string.Empty;
            password = string.Empty;
        }
        [DataMember(Name = "user", Order = 1)]
        public string user { get; set; }
        [DataMember(Name = "password", Order =2)]
        public string password { get; set; }

    }
}
