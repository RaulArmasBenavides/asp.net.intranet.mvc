using System.Runtime.Serialization;

namespace intranetMVC.Models.Auth
{
    [DataContract]
    public class VerifyOtpRequest
    {
        [DataMember] 
        public string User { get; set; }

        [DataMember] 
        public string Code { get; set; }
    }
}