using intranetMVC.Models.Academico;
using System.Collections.Generic;

namespace intranetMVC.Controllers
{
    // Responsabilidad única: proveer los datos del horario del alumno actual.
    // Cuando conecte con WCF, solo este archivo cambia.
    public static class HorarioHelper
    {
        private const double PxPorMinuto = 1.5;
        private const int    HoraBase    = 8; // 08:00

        public static List<ClaseHorario> ObtenerClases()
        {
            return new List<ClaseHorario>
            {
                Clase("MAT301","Cálculo III",        "Lunes",     "08:00","10:00","A-201", "Dr. Huanca Flores",  "bg-primary"        ),
                Clase("MAT301","Cálculo III",        "Miércoles", "08:00","10:00","A-201", "Dr. Huanca Flores",  "bg-primary"        ),
                Clase("SIS201","Base de Datos I",    "Lunes",     "11:00","13:00","Lab-01","Dr. Torres Medina",  "bg-info text-dark" ),
                Clase("SIS201","Base de Datos I",    "Viernes",   "11:00","13:00","Lab-01","Dr. Torres Medina",  "bg-info text-dark" ),
                Clase("PRO301","Algoritmos",         "Martes",    "10:00","11:30","B-102", "Mg. Quispe Ríos",    "bg-success"        ),
                Clase("PRO301","Algoritmos",         "Jueves",    "10:00","11:30","B-102", "Mg. Quispe Ríos",    "bg-success"        ),
                Clase("RED101","Redes",              "Miércoles", "14:00","15:30","B-301", "Ing. Salinas Cruz",  "bg-warning text-dark"),
                Clase("RED101","Redes",              "Viernes",   "14:00","15:30","B-301", "Ing. Salinas Cruz",  "bg-warning text-dark"),
                Clase("EST201","Estadística p/ Ing.","Martes",    "16:00","17:30","A-305", "Mg. Paredes Soto",   "bg-danger"         ),
                Clase("EST201","Estadística p/ Ing.","Jueves",    "16:00","17:30","A-305", "Mg. Paredes Soto",   "bg-danger"         ),
            };
        }

        private static ClaseHorario Clase(string cod, string nom, string dia,
            string ini, string fin, string aula, string doc, string color)
        {
            int startMin = ToMin(ini);
            int endMin   = ToMin(fin);
            return new ClaseHorario
            {
                Codigo     = cod, Nombre    = nom, Dia      = dia,
                HoraInicio = ini, HoraFin   = fin, Aula     = aula,
                Docente    = doc, ColorClass = color,
                TopPx      = (int)((startMin - HoraBase * 60) * PxPorMinuto),
                HeightPx   = (int)((endMin - startMin) * PxPorMinuto)
            };
        }

        private static int ToMin(string t)
        {
            var p = t.Split(':');
            return int.Parse(p[0]) * 60 + int.Parse(p[1]);
        }
    }
}
