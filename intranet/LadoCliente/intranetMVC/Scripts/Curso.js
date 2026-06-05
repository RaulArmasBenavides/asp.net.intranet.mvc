window.onload = function () {
    ListarCursos();
};

function ListarCursos() {
    pintar(
        {
            url: "Curso/ListarCursos",
            id: "divTabla",
            cabeceras: ["ID", "Código", "Nombre del Curso", "Créditos", "Hrs/Semana", "Nivel"],
            propiedades: ["CourseId", "Code", "Name", "Credits", "WeeklyHours", "EducationLevel"],
            editar: true,
            eliminar: true,
            urlEliminar: "Curso/Delete",
            parametroEliminar: "CourseId",
            urlRecuperar: "Curso/CursoObtener",
            parametroRecuperar: "CourseId",
            propiedadId: "CourseId"
        },
        {
            busqueda: true,
            url: "Curso/CursoBuscar",
            nombreparametro: "nombre",
            type: "text",
            button: true,
            id: "txtnombrecurso",
            placeholder: "Buscar por nombre o código"
        },
        {
            id: "frmCurso",
            type: "fieldset",
            urlGuardar: "Curso/Create",
            legend: "Datos del curso",
            formulario: [
                [
                    { class: "mb-3 col-md-4", label: "Código",       name: "Code",           classControl: "o max-10 min-3" },
                    { class: "mb-3 col-md-8", label: "Nombre",        name: "Name",           classControl: "o max-150 min-3" }
                ],
                [
                    { class: "mb-3 col-md-3", label: "Créditos",      name: "Credits",        classControl: "o max-2 sndc" },
                    { class: "mb-3 col-md-3", label: "Horas/Semana",  name: "WeeklyHours",    classControl: "o max-2 snc" },
                    { class: "mb-3 col-md-6", label: "Nivel Educativo", name: "EducationLevel", classControl: "o max-50 min-3" }
                ],
                [
                    { class: "mb-3 col-md-12", label: "Descripción", name: "Description", type: "textarea", rows: "3", classControl: "max-500" }
                ]
            ]
        }
    );
}
