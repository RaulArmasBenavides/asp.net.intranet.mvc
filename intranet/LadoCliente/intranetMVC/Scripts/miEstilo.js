$(document).ready(function () {
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

})

//eventos 
$(document).ready(function () {

    $(".btn-create").click(function (e) {
        $("#modal").load("/Alumno/Create").attr("title", "Nuevo Alumno").dialog({ width: 550, height: 'auto' });
    });

    $(".btn-details").click(function () {
        var codigo = $(this).attr("data-codigo");
        $("#modal").load("/Alumno/Details/" + codigo).attr("title", "Visualizar").dialog();
    });

    $(".btn-edit").click(function () {
        var codigo = $(this).attr("data-codigo");
        $("#modal").load("/Alumno/Edit/" + codigo).attr("title", "Editar Alumno").dialog({ width: 550, height: 'auto' });
    });

    $(".btn-delete").click(function () {
        var codigo = $(this).attr("data-codigo");
        $("#modal").load("/Alumno/Delete/" + codigo).attr("title", "Eliminar Alumno").dialog();
    });

});