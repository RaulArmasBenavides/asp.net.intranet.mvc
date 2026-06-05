window.Modulos = window.Modulos || {};

window.Modulos.Docente = {
    tabla: {
        url: 'Docente/ListarDocentes',
        id: 'divTabla',
        cabeceras: ['ID', 'Apellidos', 'Nombres', 'DNI', 'Especialidad', 'Categoría', 'Dedicación'],
        propiedades: ['IdDocente', 'Apellidos', 'Nombres', 'DNI', 'Especialidad', 'Categoria', 'Dedicacion'],
        editar: true, eliminar: true,
        urlEliminar: 'Docente/Delete', parametroEliminar: 'IdDocente',
        urlRecuperar: 'Docente/DocenteObtener', parametroRecuperar: 'IdDocente',
        propiedadId: 'IdDocente'
    },
    busqueda: {
        busqueda: true, url: 'Docente/DocenteBuscar',
        nombreparametro: 'nombre', type: 'text', button: true,
        id: 'txtnombredocente', placeholder: 'Buscar por apellido, nombre o especialidad'
    },
    formulario: {
        id: 'frmDocente', type: 'fieldset',
        urlGuardar: 'Docente/Create', legend: 'Datos del docente',
        formulario: [
            [
                { class: 'mb-3 col-md-4', label: 'Apellidos',    name: 'Apellidos',    classControl: 'o max-100 min-2' },
                { class: 'mb-3 col-md-4', label: 'Nombres',      name: 'Nombres',      classControl: 'o max-100 min-2' },
                { class: 'mb-3 col-md-4', label: 'DNI',          name: 'DNI',          classControl: 'o max-8 min-8 snc' }
            ],
            [
                { class: 'mb-3 col-md-4', label: 'Especialidad', name: 'Especialidad', classControl: 'o max-100 min-2' },
                { class: 'mb-3 col-md-4', label: 'Departamento', name: 'Departamento', classControl: 'o max-100 min-2' },
                { class: 'mb-3 col-md-4', label: 'Email',        name: 'Email',        classControl: 'max-100' }
            ],
            [
                { class: 'mb-3 col-md-3', label: 'Categoría (Auxiliar/Asociado/Principal)', name: 'Categoria',  classControl: 'o max-20 min-2' },
                { class: 'mb-3 col-md-3', label: 'Dedicación (TC/TP)',                      name: 'Dedicacion', classControl: 'o max-5 min-2' }
            ]
        ]
    }
};
