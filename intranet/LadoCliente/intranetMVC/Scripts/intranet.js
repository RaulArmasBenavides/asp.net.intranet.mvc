// ── Globals ────────────────────────────────────────────────────────────────
var objConfiguracionGlobal;
var objBusquedaGlobal;
var objFormularioGlobal;
var combosLlenar = [];
var radioLimpiar = [];
var radioNames   = [];

// ── Utilidades DOM ─────────────────────────────────────────────────────────

function escapeHtml(text) {
    if (text == null) return '';
    return String(text)
        .replace(/&/g, '&amp;').replace(/</g, '&lt;')
        .replace(/>/g, '&gt;').replace(/"/g, '&quot;')
        .replace(/'/g, '&#039;');
}

function get(id)          { return document.getElementById(id).value; }
function set(id, val)     { document.getElementById(id).value = val; }
function setD(id, val)    { document.getElementById(id).style.display = val; }
function setN(id, val)    { document.getElementsByName(id)[0].value = val; }
function setSRC(id, val)  { document.getElementsByName(id)[0].src = val; }
function getN(id)         { return document.getElementsByName(id)[0].value; }
function setC(sel)        { document.querySelector(sel).checked = true; }

// ── Alertas ────────────────────────────────────────────────────────────────

function mostrarError(texto) {
    Swal.fire({ icon: 'error', title: 'Error', text: texto || 'Ocurrió un error' });
}

function Correcto(texto) {
    Swal.fire({
        position: 'top', icon: 'success',
        title: texto || 'Se realizó correctamente',
        showConfirmButton: false, timer: 1500
    });
}

function Confirmacion(texto, title, callback) {
    return Swal.fire({
        title: title || 'Confirmación', text: texto || '¿Desea continuar?',
        icon: 'warning', showCancelButton: true,
        confirmButtonColor: '#3085d6', cancelButtonColor: '#d33',
        confirmButtonText: 'Sí', cancelButtonText: 'No'
    }).then(function (r) { if (r.isConfirmed) callback(); });
}

// ── HTTP ───────────────────────────────────────────────────────────────────

function _url(path) {
    var raiz = document.getElementById('hdfOculto').value;
    return window.location.protocol + '//' + window.location.host + raiz + path;
}

function fetchGet(url, cb) {
    setD('cargando', 'block');
    fetch(_url(url))
        .then(function (r) { return r.json(); })
        .then(function (r) { setD('cargando', 'none'); cb(r); })
        .catch(function (e) { setD('cargando', 'none'); mostrarError(e.message); });
}

function fetchGetText(url, cb) {
    setD('cargando', 'block');
    fetch(_url(url))
        .then(function (r) { return r.text(); })
        .then(function (r) { setD('cargando', 'none'); cb(r); })
        .catch(function (e) { setD('cargando', 'none'); mostrarError(e.message); });
}

function fetchPostText(url, frm, cb) {
    setD('cargando', 'block');
    fetch(_url(url), { method: 'POST', body: frm })
        .then(function (r) { return r.text(); })
        .then(function (r) { setD('cargando', 'none'); cb(r); })
        .catch(function (e) { setD('cargando', 'none'); mostrarError(e.message); });
}

// ── Tabla ──────────────────────────────────────────────────────────────────

function generarTabla(cfg, res, frm, primeravez) {
    var lista = (primeravez && cfg.name) ? res[cfg.name] : res;
    var h = "<table class='table table-hover table-bordered table-sm'><thead class='table-dark'><tr>";
    cfg.cabeceras.forEach(function (c) { h += '<th>' + escapeHtml(c) + '</th>'; });
    if (cfg.editar || cfg.eliminar) h += '<th style="width:90px">Acciones</th>';
    h += '</tr></thead><tbody>';

    lista.forEach(function (fila) {
        h += '<tr>';
        cfg.propiedades.forEach(function (p) {
            h += cfg.columnaimg.includes(p)
                ? "<td><img width='80px' src='" + escapeHtml(fila[p]) + "'/></td>"
                : '<td>' + escapeHtml(fila[p]) + '</td>';
        });
        if (cfg.editar || cfg.eliminar) {
            h += '<td class="text-center">';
            if (cfg.editar) {
                var cbEd = (frm && frm.formulariogenerico) ? 'EditarGenerico' : cfg.callbackEditar;
                h += '<button class="btn btn-sm btn-warning me-1" onclick=\'' + cbEd + '(' + fila[cfg.propiedadId] + ',"' + (frm ? frm.id : '') + '")\'>'
                   + '<i class="fas fa-edit"></i></button>';
            }
            if (cfg.eliminar) {
                var cbEl = (frm && frm.formulariogenerico) ? 'EliminarGenerico' : cfg.callbackEliminar;
                h += '<button class="btn btn-sm btn-danger" onclick=\'' + cbEl + '(' + fila[cfg.propiedadId] + ')\'>'
                   + '<i class="fas fa-trash"></i></button>';
            }
            h += '</td>';
        }
        h += '</tr>';
    });
    h += '</tbody></table>';
    return h;
}

// ── Búsqueda ───────────────────────────────────────────────────────────────

function Buscar() {
    var valor = get(objBusquedaGlobal.id);
    fetchGet(objBusquedaGlobal.url + '?' + objBusquedaGlobal.nombreparametro + '=' + encodeURIComponent(valor), function (r) {
        document.getElementById('divContenedor').innerHTML = generarTabla(objConfiguracionGlobal, r, objFormularioGlobal);
    });
}

// ── Render principal ───────────────────────────────────────────────────────

function pintar(cfg, busq, frm) {
    fetch(_url(cfg.url))
        .then(function (r) { return r.json(); })
        .then(function (res) {
            // defaults cfg
            cfg.editar           = cfg.editar           || false;
            cfg.eliminar         = cfg.eliminar         || false;
            cfg.propiedadId      = cfg.propiedadId      || 'id';
            cfg.callbackEliminar = cfg.callbackEliminar || 'Eliminar';
            cfg.callbackEditar   = cfg.callbackEditar   || 'Editar';
            cfg.popup            = cfg.popup            || false;
            cfg.sizepopup        = cfg.sizepopup        || '';
            cfg.recuperarexcepcion = cfg.recuperarexcepcion || [];
            cfg.iscallbackeditar = cfg.iscallbackeditar || false;
            cfg.columnaimg       = cfg.columnaimg       || [];
            objConfiguracionGlobal = cfg;

            var out = '';

            // formulario
            if (frm) {
                objFormularioGlobal = frm;
                frm.guardar            = frm.guardar !== false;
                frm.limpiarexcepcion   = frm.limpiarexcepcion   || [];
                frm.limpiar            = frm.limpiar !== false;
                frm.formulariogenerico = frm.formulariogenerico !== false;
                frm.callbackGuardar    = frm.callbackGuardar    || 'GuardarDatos';
                frm.id                 = frm.id                 || 'frmFormulario';
                frm.tituloconfirmacionguardar = frm.tituloconfirmacionguardar || '¿Desea guardar los cambios?';

                var accionGuardar = frm.formulariogenerico
                    ? "GuardarGenerico('" + frm.id + "','" + frm.urlGuardar + "')"
                    : frm.callbackGuardar + '()';
                var accionLimpiar = (frm.formulariogenerico ? 'LimpiarGenerico' : 'Limpiar') + "('" + frm.id + "')";

                if (frm.type === 'fieldset') {
                    out += '<fieldset class="border p-3 mb-3 rounded"><legend class="w-auto px-2 fw-bold fs-6">' + escapeHtml(frm.legend || '') + '</legend>';
                    out += construirFormulario(frm);
                    if (frm.guardar) out += '<button class="btn btn-primary btn-sm me-2" onclick="' + accionGuardar + '"><i class="fas fa-save me-1"></i>Guardar</button>';
                    if (frm.limpiar) out += '<button class="btn btn-secondary btn-sm" onclick="' + accionLimpiar + '"><i class="fas fa-eraser me-1"></i>Limpiar</button>';
                    out += '</fieldset>';
                } else if (frm.type === 'popup') {
                    out += '<button class="btn btn-success btn-sm mb-3" onclick="EditarGenerico(0,\'' + frm.id + '\')" data-bs-toggle="modal" data-bs-target="#' + cfg.idpopup + '"><i class="fas fa-plus me-1"></i>Nuevo</button>';
                    out += '<div class="modal fade" id="' + cfg.idpopup + '" data-bs-backdrop="static" tabindex="-1"><div class="modal-dialog ' + cfg.sizepopup + '"><div class="modal-content">'
                         + '<div class="modal-header"><h5 class="modal-title" id="lbl' + cfg.idpopup + '"></h5><button type="button" class="btn-close" data-bs-dismiss="modal"></button></div>'
                         + '<div class="modal-body">' + construirFormulario(frm) + '</div>'
                         + '<div class="modal-footer">'
                         + '<button class="btn btn-secondary" data-bs-dismiss="modal" id="btnCerrar' + cfg.idpopup + '">Cerrar</button>'
                         + '<button class="btn btn-primary" onclick="' + accionGuardar + '">Guardar</button>'
                         + '</div></div></div></div>';
                }
            }

            // búsqueda
            if (busq && busq.busqueda) {
                busq.placeholder = busq.placeholder || 'Ingrese un valor';
                busq.id          = busq.id          || 'txtbusqueda';
                busq.type        = busq.type        || 'text';
                busq.button      = busq.button !== false;
                cfg.id           = cfg.id           || 'divTabla';
                objBusquedaGlobal = busq;
                out += '<div class="input-group mb-3">';
                out += busq.type === 'text'
                    ? '<input type="text" class="form-control" id="' + busq.id + '" placeholder="' + escapeHtml(busq.placeholder) + '"' + (!busq.button ? " onkeyup='Buscar()'" : '') + '/>'
                    : '<select class="form-control" id="' + busq.id + '"' + (!busq.button ? " onchange='Buscar()'" : '') + '></select>';
                if (busq.button) out += '<button class="btn btn-primary" onclick="Buscar()" type="button"><i class="fas fa-search me-1"></i>Buscar</button>';
                out += '</div>';
            }

            out += "<div id='divContenedor'>" + generarTabla(cfg, res, frm, true) + '</div>';
            document.getElementById(cfg.id).innerHTML = out;

            if (busq) llenarComboBusqueda(res);
            combosLlenar.forEach(function (item) { llenarCombo(res[item.datasource], item.id, item.propiedadMostrar, item.propiedadId); });
        })
        .catch(function (e) { mostrarError('Error al cargar datos: ' + e.message); });
}

// ── Combos ─────────────────────────────────────────────────────────────────

function llenarComboBusqueda(res) {
    if (objBusquedaGlobal.type === 'combobox')
        llenarCombo(res[objBusquedaGlobal.name], objBusquedaGlobal.id, objBusquedaGlobal.displaymember, objBusquedaGlobal.valuemember);
}

function llenarCombo(data, id, mostrar, valor, defecto) {
    var h = "<option value='" + (defecto || '') + "'>--Seleccione--</option>";
    (data || []).forEach(function (e) {
        h += "<option value='" + escapeHtml(String(e[valor])) + "'>" + escapeHtml(e[mostrar]) + '</option>';
    });
    document.getElementById(id).innerHTML = h;
}

// ── Recuperar formulario ───────────────────────────────────────────────────

function recuperarGenerico(url, idFrm, excepciones, adicional) {
    excepciones = excepciones || [];
    var els = document.querySelectorAll('#' + idFrm + ' [name]');
    fetchGet(url, function (res) {
        els.forEach(function (el) {
            if (excepciones.includes(el.name)) return;
            var tipo = (el.type || '').toUpperCase();
            if (tipo === 'RADIO') setC("[type='radio'][value='" + res[el.name] + "']");
            else if (tipo !== 'FILE') setN(el.name, res[el.name] != null ? res[el.name] : '');
            else if (el.tagName === 'IMG') setSRC(el.name, res[el.name]);
        });
        if (adicional) objConfiguracionGlobal.callbackeditar(res);
    });
}

// ── Validaciones ───────────────────────────────────────────────────────────

function ValidarObligatorios(id) {
    var els = document.querySelectorAll('#' + id + ' .o');
    for (var i = 0; i < els.length; i++) {
        if (els[i].tagName === 'INPUT' && els[i].value === '') return 'Debe ingresar ' + els[i].name;
    }
    return '';
}

function ValidarLongitudMaxima(id) {
    var ctrls = document.querySelectorAll('#' + id + ' [class*="max-"]');
    for (var i = 0; i < ctrls.length; i++) {
        var max = parseInt(ctrls[i].className.split(' ').filter(function (c) { return c.startsWith('max-'); })[0].replace('max-', ''), 10);
        if (ctrls[i].value.length > max) return 'El campo ' + ctrls[i].name + ' supera los ' + max + ' caracteres';
    }
    return '';
}

function ValidarLongitudMinima(id) {
    var ctrls = document.querySelectorAll('#' + id + ' [class*="min-"]');
    for (var i = 0; i < ctrls.length; i++) {
        var min = parseInt(ctrls[i].className.split(' ').filter(function (c) { return c.startsWith('min-'); })[0].replace('min-', ''), 10);
        if (ctrls[i].value.length > 0 && ctrls[i].value.length < min) return 'El campo ' + ctrls[i].name + ' requiere al menos ' + min + ' caracteres';
    }
    return '';
}

function validarSoloNumerosEnteros(id) {
    var ctrls = document.querySelectorAll('#' + id + ' [class*="snc"]');
    for (var i = 0; i < ctrls.length; i++) {
        if (ctrls[i].value && !/^\d+$/.test(ctrls[i].value)) return 'El campo ' + ctrls[i].name + ' solo admite números enteros';
    }
    return '';
}

function validarSoloNumerosDecimalesControl(id) {
    var ctrls = document.querySelectorAll('#' + id + ' [class*="sndc"]');
    for (var i = 0; i < ctrls.length; i++) {
        var v = ctrls[i].value;
        if (v && !/^\d*\.?\d*$/.test(v)) return 'El campo ' + ctrls[i].name + ' solo admite números';
    }
    return '';
}

function validarSoloNumeros(e) { if (e.keyCode < 48 || e.keyCode > 57) e.preventDefault(); }
function validarSoloNumerosDecimales(e) {
    var k = e.keyCode;
    if ((k < 48 && k !== 46) || k > 57) { e.preventDefault(); return; }
    if (String.fromCharCode(k) === '.' && (e.target.value.includes('.') || e.target.value.length === 0)) e.preventDefault();
}

function encontroClase(clase, buscar) { return clase.split(' ').some(function (c) { return c.includes(buscar); }); }

// ── Constructor de formularios ─────────────────────────────────────────────

function construirFormulario(frm) {
    var out = "<div class='mt-2'><form id='" + frm.id + "' method='POST'>";
    frm.formulario.forEach(function (fila) {
        out += "<div class='row'>";
        fila.forEach(function (h) {
            h.class        = h.class        || 'mb-3';
            h.type         = h.type         || 'text';
            h.readonly     = h.readonly     || false;
            h.value        = h.value        != null ? h.value : '';
            h.label        = h.label        || h.name;
            h.rows         = h.rows         || '4';
            h.classControl = h.classControl || '';
            h.id           = h.id           || ('cbo_' + h.name);
            var snc  = encontroClase(h.classControl, 'snc');
            var sndc = encontroClase(h.classControl, 'sndc');
            out += '<div class="' + h.class + '"><label class="form-label fw-semibold">' + escapeHtml(h.label) + '</label>';

            if (h.type === 'text' || h.type === 'number' || h.type === 'date') {
                out += '<input type="text" class="form-control ' + h.classControl + '" name="' + h.name + '" value="' + escapeHtml(String(h.value)) + '"'
                    + (snc  ? " onkeypress='validarSoloNumeros(event)'" : '')
                    + (sndc ? " onkeypress='validarSoloNumerosDecimales(event)'" : '')
                    + (h.readonly ? ' readonly' : '') + '/>';
            } else if (h.type === 'textarea') {
                out += '<textarea name="' + h.name + '" class="form-control ' + h.classControl + '" rows="' + h.rows + '">' + escapeHtml(String(h.value)) + '</textarea>';
            } else if (h.type === 'combobox') {
                out += '<select name="' + h.name + '" class="form-select ' + h.classControl + '" id="' + h.id + '"></select>';
                combosLlenar.push(h);
            } else if (h.type === 'radio' || h.type === 'checkbox') {
                out += '<div class="d-flex gap-3 flex-wrap mt-1">';
                for (var z = 0; z < h.labels.length; z++) {
                    out += '<div class="form-check"><input class="form-check-input" type="' + h.type + '"'
                        + (h.ids && h.ids[z] === h.checked ? ' checked' : '')
                        + ' id="' + (h.ids ? h.ids[z] : z) + '" name="' + h.name + (h.type === 'checkbox' ? '[]' : '') + '" value="' + escapeHtml(String(h.values[z])) + '"/>'
                        + '<label class="form-check-label" for="' + (h.ids ? h.ids[z] : z) + '">' + escapeHtml(h.labels[z]) + '</label></div>';
                }
                radioLimpiar.push(h.checked);
                radioNames.push(h.name);
                out += '</div>';
            }
            out += '</div>';
        });
        out += '</div>';
    });
    out += '</form></div>';
    return out;
}

function previewImage(ctrl, img) {
    var reader = new FileReader();
    reader.onloadend = function () { document.getElementById(img).src = reader.result; };
    reader.readAsDataURL(ctrl.files[0]);
}

// ── CRUD ───────────────────────────────────────────────────────────────────

function GuardarGenerico(idFrm, urlGuardar) {
    var err = ValidarObligatorios(idFrm) || ValidarLongitudMaxima(idFrm) || ValidarLongitudMinima(idFrm)
            || validarSoloNumerosEnteros(idFrm) || validarSoloNumerosDecimalesControl(idFrm);
    if (err) { mostrarError(err); return; }

    Confirmacion(objFormularioGlobal.tituloconfirmacionguardar, 'Confirmar', function () {
        var frm = new FormData(document.getElementById(idFrm));
        fetchPostText(urlGuardar, frm, function (res) {
            if (res.trim() === '1') {
                var cfg = objConfiguracionGlobal, busq = objBusquedaGlobal;
                var refUrl = busq
                    ? busq.url + '?' + busq.nombreparametro + '=' + encodeURIComponent(get(busq.id))
                    : cfg.url;
                fetchGet(refUrl, function (data) {
                    if (cfg.name && !busq) data = data[cfg.name];
                    document.getElementById('divContenedor').innerHTML = generarTabla(cfg, data, objFormularioGlobal);
                });
                if (objFormularioGlobal.type === 'popup')
                    document.getElementById('btnCerrar' + cfg.idpopup).click();
                LimpiarDatos(idFrm, objFormularioGlobal.limpiarexcepcion.concat(radioNames));
                Correcto('Guardado correctamente');
            } else {
                mostrarError('No se pudo guardar el registro');
            }
        });
    });
}

function EditarGenerico(id, idFrm) {
    var cfg = objConfiguracionGlobal;
    if (objFormularioGlobal.type === 'popup') {
        LimpiarGenerico(objFormularioGlobal.id);
        document.getElementById('lbl' + cfg.idpopup).innerHTML = (id === 0 ? 'Nuevo ' : 'Editar ') + escapeHtml(objFormularioGlobal.titulo || '');
        if (id !== 0)
            recuperarGenerico(cfg.urlRecuperar + '?' + cfg.parametroRecuperar + '=' + id, idFrm, cfg.recuperarexcepcion, cfg.iscallbackeditar);
    } else {
        recuperarGenerico(cfg.urlRecuperar + '?' + cfg.parametroRecuperar + '=' + id, idFrm, cfg.recuperarexcepcion, cfg.iscallbackeditar);
    }
}

function EliminarGenerico(id) {
    var cfg = objConfiguracionGlobal;
    Confirmacion('¿Desea eliminar este registro?', 'Confirmar eliminación', function () {
        fetchGetText(cfg.urlEliminar + '?' + cfg.parametroEliminar + '=' + id, function (r) {
            if (r.trim() === '1') {
                Correcto('Eliminado correctamente');
                fetchGet(cfg.url, function (data) {
                    if (cfg.name) data = data[cfg.name];
                    document.getElementById('divContenedor').innerHTML = generarTabla(cfg, data, objFormularioGlobal);
                });
            } else {
                mostrarError('No se pudo eliminar el registro');
            }
        });
    });
}

function LimpiarGenerico(idFrm) { LimpiarDatos(idFrm, objFormularioGlobal.limpiarexcepcion.concat(radioNames)); }

function LimpiarDatos(idFrm, excepciones) {
    excepciones = excepciones || [];
    radioLimpiar.forEach(function (r) { var el = document.getElementById(r); if (el) el.checked = true; });
    document.querySelectorAll('#' + idFrm + " [type='checkbox']").forEach(function (el) { el.checked = false; });
    document.querySelectorAll('#' + idFrm + ' [name]').forEach(function (el) {
        if (!excepciones.includes(el.name)) el.value = '';
    });
}

// ── UI: sidebar y navegación (jQuery) ─────────────────────────────────────

$(document).ready(function () {
    $('#show-sidebar').click(function () {
        $('#sidebar').toggleClass('toggled');
        $('.navbar-custom').toggleClass('toggled');
        $('.page-content').toggleClass('toggled');
    });
});

function logout() { window.location.href = '/Login/LogOut'; }
