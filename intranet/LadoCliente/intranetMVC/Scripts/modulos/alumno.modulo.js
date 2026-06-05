window.Modulos = window.Modulos || {};

window.Modulos.Alumno = {
    tabla: {
        url: 'Alumno/getClientes',
        id: 'divTabla',
        cabeceras: ['Id', 'Nombre', 'Ap. Paterno', 'Ap. Materno', 'DNI', 'Teléfono'],
        propiedades: ['IdAlumno', 'NomAlumno', 'ApePatAlumno', 'ApeMatAlumno', 'DNI', 'TelAlumno'],
        editar: true, eliminar: true,
        urlEliminar: 'Alumno/Delete', parametroEliminar: 'IdAlumno',
        urlRecuperar: 'Alumno/AlumnoObtener', parametroRecuperar: 'IdAlumno',
        propiedadId: 'IdAlumno'
    },
    busqueda: {
        busqueda: true, url: 'Alumno/AlumnoBuscar',
        nombreparametro: 'nombre', type: 'text', button: true,
        id: 'txtnombrealumno', placeholder: 'Buscar por nombre, apellido o DNI'
    },
    formulario: {
        id: 'frmAlumno', type: 'fieldset',
        urlGuardar: 'Alumno/Create', legend: 'Datos del alumno',
        formulario: [[
            { class: 'mb-3 col-md-4', label: 'Nombre',           name: 'NomAlumno',    classControl: 'o max-50 min-2' },
            { class: 'mb-3 col-md-4', label: 'Apellido Paterno', name: 'ApePatAlumno', classControl: 'o max-50 min-2' },
            { class: 'mb-3 col-md-4', label: 'Apellido Materno', name: 'ApeMatAlumno', classControl: 'o max-50 min-2' },
            { class: 'mb-3 col-md-3', label: 'DNI',              name: 'DNI',          classControl: 'o max-8 min-8 snc' },
            { class: 'mb-3 col-md-3', label: 'Teléfono',         name: 'TelAlumno',    classControl: 'max-15 snc' },
            { class: 'mb-3 col-md-6', label: 'Email',            name: 'EmailAlumno',  classControl: 'max-100' },
            { class: 'mb-3 col-md-8', label: 'Dirección',        name: 'DirAlumno',    classControl: 'max-200' }
        ]]
    }
};
