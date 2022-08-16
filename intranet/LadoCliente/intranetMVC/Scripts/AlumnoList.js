//eventos 
$(document).ready(function () {

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

    console.log("cargando");
    TableConfig();
});