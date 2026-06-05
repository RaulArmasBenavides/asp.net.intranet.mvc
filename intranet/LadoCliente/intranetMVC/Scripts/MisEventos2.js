$(document).ready(function () {
    "use strict";

    $("#show-sidebar").click(function () {
        $("#sidebar").toggleClass("toggled");
        $(".navbar-custom").toggleClass("toggled");
        $(".page-content").toggleClass("toggled");
    });
});
