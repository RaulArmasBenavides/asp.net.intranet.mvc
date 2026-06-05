window.onload = function () {
    ListarSedes();
};

function ListarSedes() {
    pintar(
        {
            url: "Sede/ListarSedes",
            id: "divTabla",
            cabeceras: ["ID", "Nombre", "Dirección"],
            propiedades: ["Idsede", "Nombre", "Direccion"],
            editar: true,
            eliminar: true,
            urlEliminar: "Sede/Delete",
            parametroEliminar: "IdSede",
            urlRecuperar: "Sede/SedeObtener",
            parametroRecuperar: "IdSede",
            propiedadId: "Idsede"
        },
        {
            busqueda: true,
            url: "Sede/SedeBuscar",
            nombreparametro: "nombre",
            type: "text",
            button: true,
            id: "txtnombresede",
            placeholder: "Buscar por nombre o dirección"
        },
        {
            id: "frmSede",
            type: "fieldset",
            urlGuardar: "Sede/Create",
            legend: "Datos de la sede",
            formulario: [
                [
                    { class: "mb-3 col-md-8", label: "Nombre de la Sede", name: "Nombre",    classControl: "o max-100 min-3" },
                    { class: "mb-3 col-md-8", label: "Dirección",         name: "Direccion", classControl: "o max-200 min-5" }
                ]
            ]
        }
    );
}
