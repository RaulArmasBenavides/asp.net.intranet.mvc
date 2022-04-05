//eventos 
$(document).ready(function () {
    "use strict";

    console.log('cargando');
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

    $("#btn-createsede").click(function (e) {
        swal("Good job!", "You clicked the button!", "success");
    });

    let tabsapp = () => {

        $("#pestañas").tabs();
        console.log("hola");
    }

    tabsapp();
});