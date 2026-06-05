window.Modulos = window.Modulos || {};

window.Modulos.Sala = {
    tabla: {
        url: 'Sala/ListarSalas',
        id: 'divTabla',
        cabeceras: ['ID', 'Nombre', 'Capacidad', 'Tipo', 'Ubicación', 'Estado'],
        propiedades: ['IdSala', 'Nombre', 'Capacidad', 'TipoSala', 'Ubicacion', 'Estado'],
        editar: true, eliminar: true,
        urlEliminar: 'Sala/Delete', parametroEliminar: 'IdSala',
        urlRecuperar: 'Sala/SalaObtener', parametroRecuperar: 'IdSala',
        propiedadId: 'IdSala'
    },
    busqueda: {
        busqueda: true, url: 'Sala/SalaBuscar',
        nombreparametro: 'nombre', type: 'text', button: true,
        id: 'txtnombresala', placeholder: 'Buscar por nombre, tipo o ubicación'
    },
    formulario: {
        id: 'frmSala', type: 'fieldset',
        urlGuardar: 'Sala/Create', legend: 'Datos de la sala',
        formulario: [
            [
                { class: 'mb-3 col-md-5', label: 'Nombre',     name: 'Nombre',    classControl: 'o max-100 min-3' },
                { class: 'mb-3 col-md-2', label: 'Capacidad',  name: 'Capacidad', classControl: 'o max-4 snc' }
            ],
            [
                { class: 'mb-3 col-md-3', label: 'Tipo de Sala', name: 'TipoSala',  classControl: 'o max-50 min-3' },
                { class: 'mb-3 col-md-5', label: 'Ubicación',    name: 'Ubicacion', classControl: 'o max-150 min-3' },
                { class: 'mb-3 col-md-4', label: 'Estado',       name: 'Estado',    classControl: 'o max-50 min-3' }
            ]
        ]
    }
};
