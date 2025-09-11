using System.Runtime.Serialization;

namespace intranetMVC.Models.Auth
{
    [DataContract]
    public class SendOtpRequest
    {
        [DataMember] 
        public string user { get; set; }
    }
}