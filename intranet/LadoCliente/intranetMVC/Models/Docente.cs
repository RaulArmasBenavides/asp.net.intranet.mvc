namespace intranetMVC.Models
{
    public class Docente
    {
        public int    IdDocente    { get; set; }
        public string Apellidos    { get; set; }
        public string Nombres      { get; set; }
        public string DNI          { get; set; }
        public string Especialidad { get; set; }
        public string Departamento { get; set; }
        public string Email        { get; set; }
        public string Categoria    { get; set; } // Auxiliar | Asociado | Principal
        public string Dedicacion   { get; set; } // TC | TP
    }
}
