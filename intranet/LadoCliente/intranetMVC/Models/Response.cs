using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranetMVC.Models
{
    public class Response<T>
    {
        public Response()
        {

        }

        public T myObject { get; set; }
    }
}