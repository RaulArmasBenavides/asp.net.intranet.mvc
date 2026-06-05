using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    public class CursoHistorial
    {
        public int    Anio        { get; set; }
        public string Semestre    { get; set; }
        public string Codigo      { get; set; }
        public string NombreCurso { get; set; }
        public int    Creditos    { get; set; }
        public decimal Nota       { get; set; }
        public string Estado      { get; set; }
    }

    public class HistorialViewModel
    {
        public string NombreCompleto     { get; set; }
        public string CodigoAlumno       { get; set; }
        public string Facultad           { get; set; }
        public string Carrera            { get; set; }
        public string Modalidad          { get; set; }
        public decimal PromedioGeneral   { get; set; }
        public int    CreditosAprobados  { get; set; }
        public int    CicloActual        { get; set; }
        public List<CursoHistorial> Cursos { get; set; }
    }
}
