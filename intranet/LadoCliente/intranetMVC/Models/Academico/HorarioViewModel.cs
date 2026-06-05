using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    public class ClaseHorario
    {
        public string Codigo      { get; set; }
        public string Nombre      { get; set; }
        public string Dia         { get; set; }
        public string HoraInicio  { get; set; }
        public string HoraFin     { get; set; }
        public string Aula        { get; set; }
        public string Docente     { get; set; }
        public string ColorClass  { get; set; }
        public int    TopPx       { get; set; }
        public int    HeightPx    { get; set; }
    }

    public class HorarioViewModel
    {
        public string              Periodo { get; set; }
        public List<ClaseHorario>  Clases  { get; set; }
        public string[]            Dias    { get; set; }
    }
}
