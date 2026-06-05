window.onload = function () {
    ListarAlumnos();
};

function ListarAlumnos() {
    pintar(
        {
            url: "Alumno/getClientes",
            id: "divTabla",
            cabeceras: ["Id", "Nombre", "Ap. Paterno", "Ap. Materno", "DNI", "Teléfono"],
            propiedades: ["IdAlumno", "NomAlumno", "ApePatAlumno", "ApeMatAlumno", "DNI", "TelAlumno"],
            editar: true,
            eliminar: true,
            urlEliminar: "Alumno/Delete",
            parametroEliminar: "IdAlumno",
            urlRecuperar: "Alumno/AlumnoObtener",
            parametroRecuperar: "IdAlumno",
            propiedadId: "IdAlumno"
        },
        {
            busqueda: true,
            url: "Alumno/AlumnoBuscar",
            nombreparametro: "nombre",
            type: "text",
            button: true,
            id: "txtnombrealumno"
        },
        {
            id: "frmAlumno",
            type: "fieldset",
            urlGuardar: "Alumno/Create",
            legend: "Datos del alumno",
            formulario: [
                [
                    { class: "mb-3 col-md-7", label: "Nombre",           name: "NomAlumno",    classControl: "o max-50 min-3" },
                    { class: "mb-3 col-md-7", label: "Apellido Paterno", name: "ApePatAlumno", classControl: "o max-50 min-3" },
                    { class: "mb-3 col-md-7", label: "Apellido Materno", name: "ApeMatAlumno", classControl: "o max-50 min-3" },
                    { class: "mb-3 col-md-7", label: "DNI",              name: "DNI",          classControl: "o max-8 min-8 snc" },
                    { class: "mb-3 col-md-7", label: "Teléfono",         name: "TelAlumno",    classControl: "max-15 snc" },
                    { class: "mb-3 col-md-7", label: "Email",            name: "EmailAlumno",  classControl: "max-100" },
                    { class: "mb-3 col-md-7", label: "Dirección",        name: "DirAlumno",    classControl: "max-200" }
                ]
            ]
        }
    );
}
