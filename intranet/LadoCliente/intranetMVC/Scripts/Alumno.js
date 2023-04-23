//eventos 

window.onload = function () {
    console.log("test");
    ListarAlumnos();
   // TableConfig();
}

function ListarAlumnos() {
    pintar({
        url: "Alumno/getClientes",
        id: "divTabla",
        cabeceras: ["IdAlumno", "NomAlumno", "ApePatAlumno", "ApeMatAlumno", "DNI","TelAlumno"],
        propiedades: ["IdAlumno", "NomAlumno", "ApePatAlumno", "ApeMatAlumno", "DNI", "TelAlumno", "EmailAlumno","DirAlumno"],
        editar: true,
        eliminar: true,
        urlEliminar: "Alumno/Delete",
        parametroEliminar: "IdAlumno",
        urlRecuperar: "Alumno/Edit",
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
        }
        , {
            id: "frmAlumno",
            type: "fieldset",
            urlGuardar: "Alumno/Create",
            legend: "Datos del alumno",
            formulario: [
                [
                    //{
                    //    class: "mb-3 col-md-5",
                    //    label: "Id Alumno",
                    //    name: "IdAlumno",
                    //    value: 0,
                    //    readonly: true
                    //},
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre Alumno",
                        name: "NomAlumno",
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Apellido Paterno del Alumno",
                        name: "ApePatAlumno",
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Apellido Materno del Alumno",
                        name: "ApeMatAlumno",
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "DNI",
                        name: "DNI",
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Teléfono",
                        name: "TelAlumno", 
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Email",
                        name: "EmailAlumno",
                        classControl: "o max-50 min-3"
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Dirección",
                        name: "DirAlumno",
                        classControl: "o max-50 min-3"
                    }
                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripcion Alumno",
                        name: "descripcion",
                        rows: "5",
                        cols: "20",
                        classControl: "o max-70 min-10"

                    }
                ],
                [
                    {
                        class: "col-md-12",
                        label: "Seleccione una Opciòn",
                        type: "radio",
                        labels: ["Excelente Estado", "Buen Estado", "Mal estado", "Malogrado"],
                        values: ["1", "2", "3", "4"],
                        ids: ["rbExcelente", "rbBuen", "rbMal", "rbMalogrado"],
                        name: "iidestado",
                        checked: "rbBuen"
                    }
                ]
            ]

        })
}
let TableConfig = () => {
        $.ajax({
            url: "http://localhost:17476/WCFIntranet.svc/Alumno/AlumnoListar",
            success: function (data) {
                console.log(data);
                console.log("ga");
                var o = data;//A la variable le asigno el json decodificado
                $('#table_id').dataTable({
                    data: o,
                    columns: [
                        { "data": "IdAlumno" },
                        { "data": "NomAlumno" },
                        { "data": "ApePatAlumno" },
                        { "data": "ApeMatAlumno" },
                        { "data": "CodigoAlu" },
                        { "data": "DNI" },
                        { "data": "DirAlumno" },
                        { "data": "EmailAlumno" },
                        { "data": "TelAlumno" }

                    ],
                });
            }
        });
}


