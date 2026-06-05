using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    public class CursoDisponible
    {
        public int    Id                  { get; set; }
        public string Codigo              { get; set; }
        public string Nombre              { get; set; }
        public int    Creditos            { get; set; }
        public string Dia                 { get; set; }
        public string Horario             { get; set; }
        public string Docente             { get; set; }
        public string Aula                { get; set; }
        public int    VacantesDisponibles { get; set; }
        public int    Ciclo               { get; set; }
    }

    public class MatriculaViewModel
    {
        public string              Periodo              { get; set; }
        public int                 MaxCreditos          { get; set; }
        public int                 CreditosMatriculados { get; set; }
        public List<CursoDisponible> CursosDisponibles  { get; set; }
        public List<CursoDisponible> CursosMatriculados { get; set; }
    }
}
