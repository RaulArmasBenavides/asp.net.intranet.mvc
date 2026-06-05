// Estado global de la página actual
var objConfiguracionGlobal;
var objBusquedaGlobal;
var objFormularioGlobal;
var combosLlenar = [];
var radioLimpiar = [];
var radioNames = [];

// ── Utilidades DOM ──────────────────────────────────────────────────────────

function escapeHtml(text) {
    if (text == null) return '';
    return String(text)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#039;');
}

function get(id) { return document.getElementById(id).value; }
function set(id, valor) { document.getElementById(id).value = valor; }
function setD(id, valor) { document.getElementById(id).style.display = valor; }
function setN(id, valor) { document.getElementsByName(id)[0].value = valor; }
function setSRC(id, valor) { document.getElementsByName(id)[0].src = valor; }
function getN(id) { return document.getElementsByName(id)[0].value; }
function setC(selector) { document.querySelector(selector).checked = true; }

// ── Alertas ─────────────────────────────────────────────────────────────────

function mostrarError(texto) {
    Swal.fire({ icon: 'error', title: 'Error', text: texto || "Ocurrió un error" });
}

function Correcto(texto) {
    Swal.fire({
        position: 'top', icon: 'success',
        title: texto || "Se realizó correctamente",
        showConfirmButton: false, timer: 1500
    });
}

function Confirmacion(texto, title, callback) {
    return Swal.fire({
        title: title || "Confirmación",
        text: texto || "¿Desea continuar?",
        icon: 'warning', showCancelButton: true,
        confirmButtonColor: '#3085d6', cancelButtonColor: '#d33',
        confirmButtonText: 'Sí', cancelButtonText: 'No'
    }).then(function (result) { if (result.isConfirmed) callback(); });
}

// ── HTTP helpers ─────────────────────────────────────────────────────────────

function _resolverUrl(url) {
    var raiz = document.getElementById("hdfOculto").value;
    return window.location.protocol + "//" + window.location.host + raiz + url;
}

function fetchGet(url, callback) {
    setD("cargando", "block");
    fetch(_resolverUrl(url))
        .then(function (res) { return res.json(); })
        .then(function (res) { setD("cargando", "none"); callback(res); })
        .catch(function (err) { setD("cargando", "none"); mostrarError(err.message); });
}

function fetchGetText(url, callback) {
    setD("cargando", "block");
    fetch(_resolverUrl(url))
        .then(function (res) { return res.text(); })
        .then(function (res) { setD("cargando", "none"); callback(res); })
        .catch(function (err) { setD("cargando", "none"); mostrarError(err.message); });
}

function fetchPostText(url, frm, callback) {
    setD("cargando", "block");
    fetch(_resolverUrl(url), { method: "POST", body: frm })
        .then(function (res) { return res.text(); })
        .then(function (res) { setD("cargando", "none"); callback(res); })
        .catch(function (err) { setD("cargando", "none"); mostrarError(err.message); });
}

// ── Tabla ────────────────────────────────────────────────────────────────────

function generarTabla(objConfiguracion, res, objFormulario, primeravez) {
    var listaPintar = (primeravez && objConfiguracion.name) ? res[objConfiguracion.name] : res;
    var contenido = "<table class='table'><tr>";

    for (var j = 0; j < objConfiguracion.cabeceras.length; j++)
        contenido += "<th>" + escapeHtml(objConfiguracion.cabeceras[j]) + "</th>";
    if (objConfiguracion.editar || objConfiguracion.eliminar)
        contenido += "<th>Operaciones</th>";
    contenido += "</tr>";

    for (var i = 0; i < listaPintar.length; i++) {
        var fila = listaPintar[i];
        contenido += "<tr>";
        for (var j = 0; j < objConfiguracion.propiedades.length; j++) {
            var prop = objConfiguracion.propiedades[j];
            if (objConfiguracion.columnaimg.includes(prop))
                contenido += "<td><img width='100px' height='100px' src='" + escapeHtml(fila[prop]) + "' /></td>";
            else
                contenido += "<td>" + escapeHtml(fila[prop]) + "</td>";
        }
        if (objConfiguracion.editar || objConfiguracion.eliminar) {
            contenido += "<td>";
            if (objConfiguracion.editar) {
                var cbEditar = (objFormulario && objFormulario.formulariogenerico) ? "EditarGenerico" : objConfiguracion.callbackEditar;
                contenido += `<i ${objConfiguracion.popup ? `data-bs-toggle="modal" data-bs-target="#${objConfiguracion.idpopup}"` : ""}
                    class="btn btn-primary"
                    onclick='${cbEditar}(${fila[objConfiguracion.propiedadId]}, "${objFormulario ? objFormulario.id : ""}") '>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eyedropper" viewBox="0 0 16 16">
                        <path d="M13.354.646a1.207 1.207 0 0 0-1.708 0L8.5 3.793l-.646-.647a.5.5 0 1 0-.708.708L8.293 5l-7.147 7.146A.5.5 0 0 0 1 12.5v1.793l-.854.854a.5.5 0 1 0 .708.707L1.707 15H3.5a.5.5 0 0 0 .354-.146L11 7.707l1.146 1.147a.5.5 0 0 0 .708-.708l-.647-.646 3.147-3.146a1.207 1.207 0 0 0 0-1.708l-2-2zM2 12.707l7-7L10.293 7l-7 7H2v-1.293z"/>
                    </svg></i>`;
            }
            if (objConfiguracion.eliminar) {
                var cbEliminar = (objFormulario && objFormulario.formulariogenerico) ? "EliminarGenerico" : objConfiguracion.callbackEliminar;
                contenido += `<i class="btn btn-danger" onclick='${cbEliminar}(${fila[objConfiguracion.propiedadId]}) '>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                        <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                    </svg></i>`;
            }
            contenido += "</td>";
        }
        contenido += "</tr>";
    }
    contenido += "</table>";
    return contenido;
}

// ── Búsqueda ─────────────────────────────────────────────────────────────────

function Buscar() {
    var objBus = objBusquedaGlobal;
    var valor = get(objBus.id);
    fetchGet(objBus.url + "?" + objBus.nombreparametro + "=" + encodeURIComponent(valor), function (res) {
        document.getElementById("divContenedor").innerHTML = generarTabla(objConfiguracionGlobal, res, objFormularioGlobal);
    });
}

// ── Render principal ─────────────────────────────────────────────────────────

function pintar(objConfiguracion, objBusqueda, objFormulario) {
    var urlAbsoluta = _resolverUrl(objConfiguracion.url);

    fetch(urlAbsoluta)
        .then(function (res) { return res.json(); })
        .then(function (res) {
            var contenido = "";

            if (objConfiguracion) {
                objConfiguracion.editar          = objConfiguracion.editar          || false;
                objConfiguracion.eliminar        = objConfiguracion.eliminar        || false;
                objConfiguracion.propiedadId     = objConfiguracion.propiedadId     || "id";
                objConfiguracion.callbackEliminar = objConfiguracion.callbackEliminar || "Eliminar";
                objConfiguracion.callbackEditar  = objConfiguracion.callbackEditar  || "Editar";
                objConfiguracion.popup           = objConfiguracion.popup           || false;
                objConfiguracion.sizepopup       = objConfiguracion.sizepopup       || "";
                objConfiguracion.recuperarexcepcion = objConfiguracion.recuperarexcepcion || [];
                objConfiguracion.iscallbackeditar = objConfiguracion.iscallbackeditar || false;
                objConfiguracion.columnaimg      = objConfiguracion.columnaimg      || [];
                objConfiguracionGlobal = objConfiguracion;
            }

            if (objFormulario) {
                objFormularioGlobal = objFormulario;
                objFormulario.guardar            = objFormulario.guardar !== false;
                objFormulario.limpiarexcepcion   = objFormulario.limpiarexcepcion   || [];
                objFormulario.limpiar            = objFormulario.limpiar !== false;
                objFormulario.formulariogenerico = objFormulario.formulariogenerico !== false;
                objFormulario.callbackGuardar    = objFormulario.callbackGuardar    || "GuardarDatos";
                objFormulario.id                 = objFormulario.id                 || "frmFormulario";
                objFormulario.tituloconfirmacionguardar = objFormulario.tituloconfirmacionguardar || "¿Desea guardar los cambios?";

                var urlGuardar = "GuardarGenerico('" + objFormulario.id + "', '" + objFormulario.urlGuardar + "')";
                var callbackGuardar = objFormulario.formulariogenerico ? urlGuardar : objFormulario.callbackGuardar + "()";
                var limpiarFn = objFormulario.formulariogenerico ? "LimpiarGenerico" : "Limpiar";

                if (objFormulario.type == "fieldset") {
                    contenido += "<fieldset>";
                    if (objFormulario.legend)
                        contenido += "<legend>" + escapeHtml(objFormulario.legend) + "</legend>";
                    contenido += construirFormulario(objFormulario);
                    if (objFormulario.guardar)
                        contenido += `<button class="btn btn-primary" onclick="${callbackGuardar}">Aceptar</button>`;
                    if (objFormulario.limpiar)
                        contenido += `<button class="btn btn-danger" onclick="${limpiarFn}('${objFormulario.id}')">Limpiar</button>`;
                    contenido += "</fieldset>";

                } else if (objFormulario.type == "popup") {
                    contenido += `<button type="button" class="btn btn-primary mb-3"
                        onclick="EditarGenerico(0,'${objFormulario.id}')"
                        data-bs-toggle="modal" data-bs-target="#${objConfiguracion.idpopup}">Nuevo</button>`;
                    contenido += `<div class="modal fade" id="${objConfiguracion.idpopup}"
                        data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-hidden="true">
                        <div class="modal-dialog ${objConfiguracion.sizepopup}">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="lbl${objConfiguracion.idpopup}"></h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">`;
                    contenido += construirFormulario(objFormulario);
                    contenido += `   </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal"
                                        id="btnCerrar${objConfiguracion.idpopup}">Cerrar</button>
                                    <button type="button" class="btn btn-primary"
                                        onclick="${callbackGuardar}">Guardar</button>
                                </div>
                            </div>
                        </div>
                    </div>`;
                }
            }

            if (objBusqueda && objBusqueda.busqueda) {
                objBusqueda.placeholder = objBusqueda.placeholder || "Ingrese un valor";
                objBusqueda.id          = objBusqueda.id          || "txtbusqueda";
                objBusqueda.type        = objBusqueda.type        || "text";
                objBusqueda.button      = objBusqueda.button !== false;
                objConfiguracion.id     = objConfiguracion.id     || "divTabla";
                objBusquedaGlobal = objBusqueda;

                contenido += `<div class="input-group mb-3">`;
                if (objBusqueda.type == "text") {
                    contenido += `<input type="text" class="form-control" id="${objBusqueda.id}"
                        ${!objBusqueda.button ? "onkeyup='Buscar()'" : ""}
                        placeholder="${escapeHtml(objBusqueda.placeholder)}" />`;
                } else if (objBusqueda.type == "combobox") {
                    contenido += `<select class="form-control" id="${objBusqueda.id}"
                        ${!objBusqueda.button ? "onchange='Buscar()'" : ""}></select>`;
                }
                if (objBusqueda.button)
                    contenido += `<button class="btn btn-primary" onclick="Buscar()" type="button">Buscar</button>`;
                contenido += `</div>`;
            }

            contenido += "<div id='divContenedor'>";
            contenido += generarTabla(objConfiguracion, res, objFormulario, true);
            contenido += "</div>";
            document.getElementById(objConfiguracion.id).innerHTML = contenido;

            if (objBusqueda) llenarComboBusqueda(res);
            for (var i = 0; i < combosLlenar.length; i++) {
                var item = combosLlenar[i];
                llenarCombo(res[item.datasource], item.id, item.propiedadMostrar, item.propiedadId);
            }
        })
        .catch(function (err) { mostrarError("Error al cargar los datos: " + err.message); });
}

// ── Combos ───────────────────────────────────────────────────────────────────

function llenarComboBusqueda(res) {
    if (objBusquedaGlobal.type == "combobox")
        llenarCombo(res[objBusquedaGlobal.name], objBusquedaGlobal.id,
            objBusquedaGlobal.displaymember, objBusquedaGlobal.valuemember);
}

function llenarCombo(data, id, propiedadMostrar, propiedadId, valueDefecto) {
    valueDefecto = valueDefecto || "";
    var contenido = "<option value='" + valueDefecto + "'>--Seleccione--</option>";
    for (var j = 0; j < data.length; j++) {
        contenido += "<option value='" + escapeHtml(String(data[j][propiedadId])) + "'>"
            + escapeHtml(data[j][propiedadMostrar]) + "</option>";
    }
    document.getElementById(id).innerHTML = contenido;
}

// ── Recuperar formulario ──────────────────────────────────────────────────────

function recuperarGenerico(url, idFormulario, excepciones, adicional) {
    excepciones = excepciones || [];
    var elementos = document.querySelectorAll("#" + idFormulario + " [name]");
    fetchGet(url, function (res) {
        for (var i = 0; i < elementos.length; i++) {
            var nombre = elementos[i].name;
            if (excepciones.includes(nombre)) continue;
            var tipo = (elementos[i].type || "").toUpperCase();
            if (tipo == "RADIO") {
                setC("[type='radio'][value='" + res[nombre] + "']");
            } else if (tipo != "FILE") {
                setN(nombre, res[nombre]);
            } else if (elementos[i].tagName.toUpperCase() == "IMG") {
                setSRC(nombre, res[nombre]);
            }
        }
        if (adicional) objConfiguracionGlobal.callbackeditar(res);
    });
}

function recuperarGenericoEspecifico(url, idFormulario, excepciones, adicional) {
    excepciones = excepciones || [];
    var elementos = document.querySelectorAll("#" + idFormulario + " [name]");
    fetchGet(url, function (res) {
        for (var i = 0; i < elementos.length; i++) {
            var nombre = elementos[i].name;
            if (excepciones.includes(nombre)) continue;
            var tipo = (elementos[i].type || "").toUpperCase();
            if (tipo == "RADIO") {
                setC("[type='radio'][value='" + res[nombre] + "']");
            } else if (tipo == "CHECKBOX") {
                var propiedad = nombre.replace("[]", "");
                var valores = res[propiedad] || [];
                for (var j = 0; j < valores.length; j++)
                    setC("[type='checkbox'][value='" + valores[j] + "']");
            } else if (tipo != "FILE") {
                setN(nombre, res[nombre]);
            } else if (elementos[i].tagName.toUpperCase() == "IMG") {
                setSRC(nombre, res[nombre]);
            }
        }
        if (adicional) recuperarEspecifico(res);
    });
}

// ── Validaciones ─────────────────────────────────────────────────────────────

function ValidarObligatorios(idFormulario) {
    var contenedorcheckbox = document.querySelectorAll("#" + idFormulario + " [class*='o-']");
    for (var i = 0; i < contenedorcheckbox.length; i++) {
        var contenedor = contenedorcheckbox[i];
        var claseO = contenedor.className.split(" ").filter(function (p) { return p.includes("o-"); })[0];
        var minimo = parseInt(claseO.replace("o-", ""), 10);
        var marcados = 0;
        for (var j = 0; j < contenedor.children.length; j++) {
            var hijo = contenedor.children[j];
            if (hijo.type && hijo.type.toUpperCase() == "CHECKBOX" && hijo.checked) marcados++;
        }
        if (minimo > marcados) return "Debe seleccionar al menos " + minimo + " opción con un check";
    }
    var elementos = document.querySelectorAll("#" + idFormulario + " .o");
    for (var i = 0; i < elementos.length; i++) {
        if (elementos[i].tagName.toUpperCase() == "INPUT" && elementos[i].value == "")
            return "Debe ingresar el " + elementos[i].name;
        if (elementos[i].tagName.toUpperCase() == "IMG" && elementos[i].src == window.location.href)
            return "Debe ingresar la " + elementos[i].name.replace("base64", "").replace("data", "");
    }
    return "";
}

function ValidarLongitudMaxima(idFormulario) {
    var controles = document.querySelectorAll("#" + idFormulario + " [class*='max-']");
    for (var i = 0; i < controles.length; i++) {
        var claseMax = controles[i].className.split(" ").filter(function (p) { return p.includes("max-"); })[0];
        var valorMax = parseInt(claseMax.replace("max-", ""), 10);
        if (controles[i].value.length > valorMax)
            return "El campo " + controles[i].name + " supera los " + valorMax + " caracteres permitidos";
    }
    return "";
}

function ValidarLongitudMinima(idFormulario) {
    var controles = document.querySelectorAll("#" + idFormulario + " [class*='min-']");
    for (var i = 0; i < controles.length; i++) {
        var claseMin = controles[i].className.split(" ").filter(function (p) { return p.includes("min-"); })[0];
        var valorMin = parseInt(claseMin.replace("min-", ""), 10);
        if (controles[i].value.length < valorMin)
            return "El campo " + controles[i].name + " requiere al menos " + valorMin + " caracteres";
    }
    return "";
}

function validarSoloNumerosEnteros(idFormulario) {
    var controles = document.querySelectorAll("#" + idFormulario + " [class*='snc']");
    for (var i = 0; i < controles.length; i++) {
        if (!/^\d+$/.test(controles[i].value))
            return "El campo " + controles[i].name + " solo admite números enteros";
    }
    return "";
}

function validarSoloNumerosDecimalesControl(idFormulario) {
    var controles = document.querySelectorAll("#" + idFormulario + " [class*='sndc']");
    for (var i = 0; i < controles.length; i++) {
        var valor = controles[i].value;
        if (valor.startsWith(".")) return "El campo " + controles[i].name + " no puede iniciar con punto";
        if (valor.endsWith("."))   return "El campo " + controles[i].name + " no puede terminar con punto";
        if ((valor.match(/\./g) || []).length > 1) return "El campo " + controles[i].name + " solo puede tener un punto decimal";
        if (!/^\d*\.?\d*$/.test(valor)) return "El campo " + controles[i].name + " solo admite números";
    }
    return "";
}

function validarSoloNumeros(e) {
    if (e.keyCode < 48 || e.keyCode > 57) e.preventDefault();
}

function validarSoloNumerosDecimales(e) {
    var kc = e.keyCode;
    if ((kc < 48 && kc != 46) || kc > 57) { e.preventDefault(); return; }
    if (String.fromCharCode(kc) == "." && e.target.value.includes(".")) e.preventDefault();
    if (e.target.value.length == 0 && String.fromCharCode(kc) == ".") e.preventDefault();
}

function encontroClase(clase, claseBuscar) {
    return clase.split(" ").some(function (p) { return p.includes(claseBuscar); });
}

// ── Constructor de formularios ────────────────────────────────────────────────

function construirFormulario(objFormulario) {
    var elementos = objFormulario.formulario;
    var contenido = "<div class='mt-3 mb-3'><form id='" + objFormulario.id + "' method='POST'>";

    for (var i = 0; i < elementos.length; i++) {
        var fila = elementos[i];
        contenido += "<div class='row'>";
        for (var j = 0; j < fila.length; j++) {
            var h = fila[j];
            h.class        = h.class        || "mb-3";
            h.type         = h.type         || "text";
            h.readonly     = h.readonly     || false;
            h.value        = h.value        != undefined ? h.value : "";
            h.label        = h.label        || h.name;
            h.cols         = h.cols         || "50";
            h.rows         = h.rows         || "10";
            h.id           = h.id           || "cboPrueba";
            h.propiedadMostrar = h.propiedadMostrar || "nombre";
            h.propiedadId      = h.propiedadId      || "id";
            h.classControl = h.classControl || "";
            h.imgwidth     = h.imgwidth     || "100";
            h.imgheight    = h.imgheight    || "100";
            h.imgclass     = h.imgclass     || "";
            h.preview      = h.preview !== false;

            var snc  = encontroClase(h.classControl, "snc");
            var sndc = encontroClase(h.classControl, "sndc");

            contenido += `<div class="${h.class}"><label>${escapeHtml(h.label)}</label>`;

            if (h.type == "text" || h.type == "number" || h.type == "date") {
                contenido += `<input type="text" class="form-control ${h.classControl}"
                    ${snc  ? "onkeypress='validarSoloNumeros(event)'" : ""}
                    ${sndc ? "onkeypress='validarSoloNumerosDecimales(event)'" : ""}
                    name="${h.name}" value="${escapeHtml(String(h.value))}"
                    ${h.readonly ? "readonly" : ""} />`;

            } else if (h.type == "textarea") {
                contenido += `<textarea name="${h.name}" class="form-control ${h.classControl}"
                    rows="${h.rows}" cols="${h.cols}">${escapeHtml(String(h.value))}</textarea>`;

            } else if (h.type == "combobox") {
                contenido += `<select name="${h.name}" class="form-control ${h.classControl}" id="${h.id}"></select>`;
                combosLlenar.push(h);

            } else if (h.type == "radio" || h.type == "checkbox") {
                contenido += "<div>";
                for (var z = 0; z < h.labels.length; z++) {
                    contenido += `<input type="${h.type}"
                        ${h.ids && h.ids[z] == h.checked ? "checked" : ""}
                        id="${h.ids ? h.ids[z] : z}"
                        name="${h.name}${h.type == "checkbox" ? '[]' : ''}"
                        value="${escapeHtml(String(h.values[z]))}" />
                        <label>${escapeHtml(h.labels[z])}</label>`;
                }
                radioLimpiar.push(h.checked);
                radioNames.push(h.name);
                contenido += "</div>";

            } else if (h.type == "file") {
                if (h.preview) {
                    contenido += `<img width="${h.imgwidth}" class="${h.imgclass}"
                        height="${h.imgheight}" id="img${h.name}"
                        name="${h.namefoto}" style="display:block" />`;
                }
                contenido += `<input type="file" id="fup${h.name}" name="${h.name}"
                    ${h.preview ? `onchange='previewImage(this,"img${h.name}")'` : ""} />`;
            }
            contenido += "</div>";
        }
        contenido += "</div>";
    }
    contenido += "</form></div>";
    return contenido;
}

function previewImage(control, img) {
    var file = control.files[0];
    var reader = new FileReader();
    reader.onloadend = function () { document.getElementById(img).src = reader.result; };
    reader.readAsDataURL(file);
}

// ── Operaciones CRUD ─────────────────────────────────────────────────────────

function GuardarGenerico(idformulario, urlguardar) {
    var error = ValidarObligatorios(idformulario)          || ValidarLongitudMaxima(idformulario)
             || ValidarLongitudMinima(idformulario)         || validarSoloNumerosEnteros(idformulario)
             || validarSoloNumerosDecimalesControl(idformulario);
    if (error) { mostrarError(error); return; }

    Confirmacion(objFormularioGlobal.tituloconfirmacionguardar, "Confirmar guardar datos", function () {
        var frm = new FormData(document.getElementById(idformulario));
        fetchPostText(urlguardar, frm, function (res) {
            if (res.trim() == "1") {
                var objConf = objConfiguracionGlobal;
                var objBus  = objBusquedaGlobal;
                var refrescar = objBus
                    ? objBus.url + "?" + objBus.nombreparametro + "=" + encodeURIComponent(get(objBus.id))
                    : objConf.url;
                fetchGet(refrescar, function (data) {
                    if (objConf.name && !objBus) data = data[objConf.name];
                    document.getElementById("divContenedor").innerHTML = generarTabla(objConf, data, objFormularioGlobal);
                });
                if (objFormularioGlobal.type == "popup")
                    document.getElementById("btnCerrar" + objConfiguracionGlobal.idpopup).click();
                LimpiarDatos(idformulario, objFormularioGlobal.limpiarexcepcion.concat(radioNames));
            }
        });
    });
}

function EditarGenerico(id, idFormulario) {
    var url            = objConfiguracionGlobal.urlRecuperar;
    var nombreparametro = objConfiguracionGlobal.parametroRecuperar;

    if (objFormularioGlobal.type == "popup") {
        LimpiarGenerico(objFormularioGlobal.id);
        document.getElementById("lbl" + objConfiguracionGlobal.idpopup).innerHTML
            = (id == 0 ? "Agregar " : "Editar ") + escapeHtml(objFormularioGlobal.titulo || "");
        if (id != 0)
            recuperarGenerico(url + "?" + nombreparametro + "=" + id, idFormulario,
                objConfiguracionGlobal.recuperarexcepcion, objConfiguracionGlobal.iscallbackeditar);
    } else {
        recuperarGenerico(url + "?" + nombreparametro + "=" + id, idFormulario,
            objConfiguracionGlobal.recuperarexcepcion, objConfiguracionGlobal.iscallbackeditar);
    }
}

function EliminarGenerico(id) {
    var objConf = objConfiguracionGlobal;
    Confirmacion("¿Desea eliminar este registro?", "Confirmar eliminación", function () {
        fetchGetText(objConf.urlEliminar + "?" + objConf.parametroEliminar + "=" + id, function (rpta) {
            if (rpta.trim() == "1") {
                Correcto("Se eliminó correctamente");
                fetchGet(objConf.url, function (res) {
                    if (objConf.name) res = res[objConf.name];
                    document.getElementById("divContenedor").innerHTML = generarTabla(objConf, res, objFormularioGlobal);
                });
            } else {
                mostrarError("No se pudo eliminar el registro");
            }
        });
    });
}

function LimpiarGenerico(idFormulario) {
    LimpiarDatos(idFormulario, objFormularioGlobal.limpiarexcepcion.concat(radioNames));
}

function LimpiarDatos(idFormulario, excepciones) {
    excepciones = excepciones || [];
    for (var j = 0; j < radioLimpiar.length; j++) {
        var el = document.getElementById(radioLimpiar[j]);
        if (el) el.checked = true;
    }
    var checkboxs = document.querySelectorAll("#" + idFormulario + " [type='checkbox']");
    for (var j = 0; j < checkboxs.length; j++) checkboxs[j].checked = false;

    var elementos = document.querySelectorAll("#" + idFormulario + " [name]");
    for (var i = 0; i < elementos.length; i++) {
        if (!excepciones.includes(elementos[i].name)) {
            if (elementos[i].tagName.toUpperCase() == "IMG") elementos[i].src = "";
            else elementos[i].value = "";
        }
    }
}
