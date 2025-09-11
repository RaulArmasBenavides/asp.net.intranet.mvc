namespace intranetMVC.Models.Auth
{
    public class VerifyCodeViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ingresa el código")]
        [System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 4)]
        public string Code { get; set; }

        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}