// Responsabilidad única: leer data-modulo del div y disparar pintar()
document.addEventListener('DOMContentLoaded', function () {
    var div = document.getElementById('divTabla');
    if (!div) return;
    var modulo = div.getAttribute('data-modulo');
    var cfg = window.Modulos && window.Modulos[modulo];
    if (cfg) pintar(cfg.tabla, cfg.busqueda, cfg.formulario);
});
