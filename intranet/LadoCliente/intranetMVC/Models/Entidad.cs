using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace intranetMVC.Models
{
    [DataContract]
    public class Entidad<T>
    {
        public Entidad()
        {
        }

        [DataMember(Name = "data", Order = 1)]
        public T MyProperty { get; set; }
    }
}