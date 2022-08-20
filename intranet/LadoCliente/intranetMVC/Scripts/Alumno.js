//eventos 

window.onload = function () {
    ListarAlumnos();
    TableConfig();
}

function ListarAlumnos() {
    pintar({
        url: "Alumno/getClientes",
        id: "divTabla",
        cabeceras: ["IdAlumno", "NomAlumno", "ApePatAlumno"],
        propiedades: ["IdAlumno", "NomAlumno", "ApePatAlumno"],
        editar: true,
        eliminar: true,
        urlEliminar: "Alumno/eliminarCama",
        parametroEliminar: "idcama",
        urlRecuperar: "Alumno/recuperarCama",
        parametroRecuperar: "idcamita",
        propiedadId: "idcama"
    },
        {
            busqueda: true,
            url: "Cama/filtrarCama",
            nombreparametro: "nombre",
            type: "text",
            button: false,
            id: "txtnombrecama"
        }
        , {
            id: "frmCama",
            type: "fieldset",
            urlGuardar: "Cama/guardarCama",
            legend: "Datos de la Cama",
            formulario: [
                [
                    {
                        class: "mb-3 col-md-5",
                        label: "Id Cama",
                        name: "idcama",
                        value: 0,
                        readonly: true
                    },
                    {
                        class: "mb-3 col-md-7",
                        label: "Nombre cama",
                        name: "nombre",
                        classControl: "o max-50 min-3"
                    }

                ],
                [
                    {
                        class: "col-md-12",
                        type: "textarea",
                        label: "Descripcion Cama",
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
            url: "http://localhost:11828/Alumno/getClientes",
            success: function (data) {
                console.log(data);
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


