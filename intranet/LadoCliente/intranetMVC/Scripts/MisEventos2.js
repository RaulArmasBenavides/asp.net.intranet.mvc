//eventos 
$(document).ready(function () {
    "use strict";
    $("#btnSedesListas").click(function () {
        console.log('ok');
        $.ajax({
            url: "/Sede/ListarSedes",
            success: function (sede) {
                var data = sede;
                //$("#div2").html(datos);
                $('table').empty();
                var items = '<table><tr><th>Nombre</th><th>Direccion</th></tr>';
                $.each(data, function (i, country) {
                    items = "<tr><td>" + country.nombre + "</td><td>" + country.direccion + "</td></tr>";
                    $('table').append(items);
                });
                items += "</table>";
            }
        });
        console.log('ok');
    });

    $("#btnShowModel").click(function () {
        console.log('ga');
        _xquery();
    });

    let _xquery = function () {
        let plantilla = "\
<div class='modal fade' id='modal'>\
    <div class='modal-dialog' style='min-width: 800px !important;'>\
        <div class='modal-content' style='font-size: 10px;'>\
            <div class='modal-header' style='width: 100%'>\
                <h4 class='modal-title'>titulo</h4>\
                <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>\
            </div>\
            <div class='row'>\
                <div class='col-12'>\
                    <div id='idFiltro' class='input-group'></div>\
                    <div id='idFiltro2' class='input-group'></div>\
                </div>\
            </div>\
            <div class='modal-body' style='color: black; width: 100%;'>\
                <div class='row'>\
                    <div class='col-md-12'>\
                        <table style='width: 100%;' class='table table-striped table-hover nowrap table-bordered'>\
                            <thead>\
                                <tr>cabecera</tr>\
                            </thead>\
                        </table>\
                    </div>\
                </div>\
            </div>\
        </div>\
    </div>\
</div>\
    ";
        $("body").append(plantilla);
        console.log('ga2');
        let _modal = $("#modal");

        $("#modal").on("shown.bs.modal", function () {
            alert('Hi');
        }).modal('show');
    }



    //ALUMNOS CONTROLLER

    let tabsapp = () => {
        $("#pestañas").tabs();
    }

   


            //$('#table_id').DataTable({
            //    dom: 'Bfrtip',

            //    buttons: [

            //        'excel',

            //        {

            //            extend: 'excelHtml5',

            //            text: 'Exportar Excel',

            //            filename: 'Reporte Empleados',

            //            title: '',

            //            exportOptions: {

            //                columns: [1, 2, 3, 4, 5, 6]

            //            },

            //            className: 'btn-exportar-excel',

            //        },]
            //});
    

    let GetDatosAlumno = () => {
        $.ajax({
            url: "/Ajax/AlumnoDatos",
            success: function (alumno) {
                var datos = "Codigo: " + alumno.ID + "<br/>"
                    + "Nombre: " + alumno.Nombre + "<br/>"
                    + "Curso : " + alumno.Curso + "<br/>"
                    + "Notas: " + alumno.Notas;
                $("#div2").html(datos);
            }
        });
    }

    tabsapp();
    $(function () {
        $("#btnGet").click(function () {
            $.ajax({
                type: "POST",
                url: "/Home/AjaxMethod",
                data: '{name: "' + $("#txtName").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert("Hola: " + response.Name + " .\nFecha y Hora: " + response.DateTime);
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        });
    });


    $(".sidebar-dropdown > a").click(function () {
        $(".sidebar-submenu").slideUp(200);
        if (
            $(this)
                .parent()
                .hasClass("active")
        ) {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .parent()
                .removeClass("active");
        } else {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .next(".sidebar-submenu")
                .slideDown(200);
            $(this)
                .parent()
                .addClass("active");
        }
    });

    $("#close-sidebar").click(function () {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function () {
        $(".page-wrapper").addClass("toggled");
    });
    //$(document).ready(function () {
    //    $.ajax({
    //        url: "/Ajax/FechaHora",
    //        success: function (data) {
    //            $("#div1").html(data);
    //        }
    //    });
    //});
});