using System.Collections.Generic;

namespace intranetMVC.Models.Academico
{
    // ── Notas / Evaluaciones ──────────────────────────────────────────────────

    public class EvaluacionDetalle
    {
        public string  Tipo    { get; set; }
        public decimal Peso    { get; set; }
        public decimal Nota    { get; set; }
    }

    public class NotasCurso
    {
        public string  Codigo        { get; set; }
        public string  Nombre        { get; set; }
        public string  Docente       { get; set; }
        public int     Creditos      { get; set; }
        public decimal NotaFinal     { get; set; }
        public string  Estado        { get; set; }
        public List<EvaluacionDetalle> Evaluaciones { get; set; }
    }

    public class ReporteNotasViewModel
    {
        public string  Periodo            { get; set; }
        public decimal PromedioSemestral  { get; set; }
        public List<NotasCurso> Cursos    { get; set; }
    }

    // ── Matrícula ─────────────────────────────────────────────────────────────

    public class CursoMatriculaItem
    {
        public string Codigo    { get; set; }
        public string Nombre    { get; set; }
        public int    Creditos  { get; set; }
        public string Dia       { get; set; }
        public string Horario   { get; set; }
        public string Docente   { get; set; }
        public string Aula      { get; set; }
    }

    public class ReporteMatriculaViewModel
    {
        public string Periodo       { get; set; }
        public string NombreAlumno  { get; set; }
        public string CodigoAlumno  { get; set; }
        public string Facultad      { get; set; }
        public string Carrera       { get; set; }
        public string Ciclo         { get; set; }
        public int    TotalCreditos { get; set; }
        public List<CursoMatriculaItem> Cursos { get; set; }
    }

    // ── Deudas ────────────────────────────────────────────────────────────────

    public class DeudaItem
    {
        public string  Concepto          { get; set; }
        public decimal Monto             { get; set; }
        public string  FechaVencimiento  { get; set; }
        public string  Estado            { get; set; } // Pagado | Pendiente | Vencido
    }

    public class ReporteDeudasViewModel
    {
        public string  NombreAlumno    { get; set; }
        public string  CodigoAlumno    { get; set; }
        public decimal TotalPendiente  { get; set; }
        public List<DeudaItem> Deudas  { get; set; }
    }

    // ── Pre-Matrícula ─────────────────────────────────────────────────────────

    public class CursoPreMatricula
    {
        public string Codigo        { get; set; }
        public string Nombre        { get; set; }
        public int    Creditos      { get; set; }
        public string Prerequisito  { get; set; }
        public bool   HabilitadoPrereq { get; set; }
        public int    CicloSugerido { get; set; }
    }

    public class ReportePreMatriculaViewModel
    {
        public string Periodo               { get; set; }
        public string NombreAlumno          { get; set; }
        public string CodigoAlumno          { get; set; }
        public int    CicloActual           { get; set; }
        public int    CicloSiguiente        { get; set; }
        public List<CursoPreMatricula> Cursos { get; set; }
    }
}
