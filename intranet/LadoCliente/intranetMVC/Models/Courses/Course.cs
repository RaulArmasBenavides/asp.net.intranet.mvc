using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranetMVC.Models
{
    /// <summary>
    /// Representa un curso o asignatura en el sistema de intranet.
    /// Usado como DTO/Modelo de datos simple.
    /// </summary>
    public class Course
    {
        // Identificador único del curso
        public int CourseId { get; set; }

        // Código alfanumérico estandarizado del curso (ej: MAT101)
        public string Code { get; set; }

        // Nombre formal completo del curso
        public string Name { get; set; }

        // Descripción o sumario del contenido del curso
        public string Description { get; set; }

        // Número de créditos académicos que otorga el curso
        public decimal Credits { get; set; }

        // Número de horas que se imparte el curso por semana
        public int WeeklyHours { get; set; }

        // Clave que lo enlaza a la Facultad o Departamento que lo ofrece
        public int DepartmentId { get; set; }

        // Indica si el curso se está ofreciendo activamente (True/False)
        public bool IsActive { get; set; }

        // Nivel educativo o dificultad (ej: "Undergraduate", "Graduate")
        public string EducationLevel { get; set; }

        // Campo de auditoría: Fecha en que se creó este registro
        public DateTime DateCreated { get; set; }
    }
}