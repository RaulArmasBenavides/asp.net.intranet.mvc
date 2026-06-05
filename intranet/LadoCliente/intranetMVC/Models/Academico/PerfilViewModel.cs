namespace intranetMVC.Models.Academico
{
    public class PerfilViewModel
    {
        // Datos personales
        public string NombreCompleto   { get; set; }
        public string CodigoAlumno     { get; set; }
        public string DNI              { get; set; }
        public string FechaNacimiento  { get; set; }
        public string Sexo             { get; set; }
        public string Email            { get; set; }
        public string Telefono         { get; set; }
        public string Direccion        { get; set; }
        public string Distrito         { get; set; }
        public string Provincia        { get; set; }
        public string Departamento     { get; set; }

        // Datos académicos
        public string Facultad         { get; set; }
        public string Carrera          { get; set; }
        public string Modalidad        { get; set; }
        public string Turno            { get; set; }
        public string Estado           { get; set; }
        public int    CicloActual      { get; set; }
        public decimal Promedio        { get; set; }
        public int    CreditosAprobados { get; set; }
        public string AnioIngreso      { get; set; }
        public string Tutor            { get; set; }
    }
}
