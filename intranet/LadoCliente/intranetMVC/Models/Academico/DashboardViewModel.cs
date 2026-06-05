using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    public class Anuncio
    {
        public string Titulo      { get; set; }
        public string Descripcion { get; set; }
        public string Fecha       { get; set; }
        public string Tipo        { get; set; } // info | warning | danger | success
    }

    public class DashboardViewModel
    {
        public string  NombreAlumno       { get; set; }
        public string  CodigoAlumno       { get; set; }
        public string  Periodo            { get; set; }
        public decimal Promedio           { get; set; }
        public int     CreditosAprobados  { get; set; }
        public int     CicloActual        { get; set; }
        public int     CursosMatriculados { get; set; }
        public string  Estado             { get; set; }
        public List<Anuncio>       Anuncios    { get; set; }
        public List<ClaseHorario>  HoyClases   { get; set; }
    }
}
