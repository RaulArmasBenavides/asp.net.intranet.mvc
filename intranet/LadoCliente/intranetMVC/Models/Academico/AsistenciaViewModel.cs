using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    public class DetalleAsistencia
    {
        public string Fecha  { get; set; }
        public string Estado { get; set; } // A | T | F
    }

    public class CursoAsistencia
    {
        public string Codigo       { get; set; }
        public string Nombre       { get; set; }
        public string Docente      { get; set; }
        public int    TotalClases  { get; set; }
        public int    Asistencias  { get; set; }
        public int    Tardanzas    { get; set; }
        public int    Faltas       { get; set; }
        public decimal Porcentaje  { get; set; }
        public string EstadoBadge  { get; set; } // success | warning | danger
        public List<DetalleAsistencia> Detalle { get; set; }
    }

    public class AsistenciaViewModel
    {
        public string Periodo { get; set; }
        public List<CursoAsistencia> Cursos { get; set; }
    }
}
