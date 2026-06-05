# Intranet Universitaria — ASP.NET MVC 5

Sistema de intranet académica para gestión estudiantil, inspirado en el SUM de la UNMSM. Construido sobre ASP.NET MVC 5 con .NET Framework 4.8.

---

## Stack tecnológico

| Capa | Tecnología |
|---|---|
| Framework web | ASP.NET MVC 5.2.9 / .NET Framework 4.8 |
| Motor de vistas | Razor (MVC 5 / Razor 2) |
| ORM | Entity Framework 6.4.4 (configurado, pendiente de uso) |
| Backend de datos | WCF REST — `http://localhost:17476/WCFIntranet.svc/` |
| Autenticación | Session-based via WCF (no ASP.NET Identity) |
| Frontend | Bootstrap 5.3.2 + jQuery 3.7.1 + jQuery UI 1.13.2 |
| Alertas | SweetAlert2 |
| Iconos | Font Awesome 5.15 (CDN) |
| Reportes Excel | EPPlus 6.2.10 |
| Telemetría | Application Insights 2.21.0 |
| Servidor dev | IIS Express — puerto **11828** |

---

## Requisitos previos

- Visual Studio 2019 o superior
- .NET Framework 4.8 SDK
- IIS Express (incluido con Visual Studio)
- Backend WCF corriendo en `http://localhost:17476/` (proyecto separado)

---

## Configuración

La URL del backend WCF se configura en un solo lugar:

```xml
<!-- Web.config -->
<appSettings>
    <add key="WcfBaseUrl" value="http://localhost:17476/WCFIntranet.svc/" />
</appSettings>
```

Para apuntar a otro ambiente, solo cambia ese valor.

---

## Módulos implementados

### Portal del alumno
| Módulo | Ruta |
|---|---|
| Dashboard | `/Home/Index` |
| Mi Perfil | `/Alumno/Perfil` |
| Datos Personales | `/Alumno/DatosPersonales` |
| Historial Académico | `/Alumno/Historial` |
| Horario de Clases | `/Alumno/Horario` |
| Matrícula de Cursos | `/Matricula/Index` |
| Mis Asistencias | `/Asistencia/Index` |

### Reportes
| Reporte | Ruta |
|---|---|
| Hub de Reportes | `/Reportes/Index` |
| Evaluaciones y Notas | `/Reportes/Notas` |
| Constancia de Matrícula | `/Reportes/Matricula` |
| Pre-Matrícula | `/Reportes/PreMatricula` |
| Estado de Deudas | `/Reportes/Deudas` |

### Mantenedores (administración)
| Módulo | Ruta |
|---|---|
| Alumnos | `/Alumno/Index` |
| Docentes | `/Docente/Index` |
| Cursos | `/Curso/Index` |
| Sedes | `/Sede/Index` |
| Salas | `/Sala/Index` |

---

## Arquitectura JavaScript

```
Scripts/
  intranet.js          # Motor CRUD + sidebar toggle + logout
  intranet.init.js     # Lee data-modulo y dispara pintar()
  modulos/
    alumno.modulo.js   # Config CRUD de Alumno
    sede.modulo.js     # Config CRUD de Sede
    curso.modulo.js    # Config CRUD de Curso
    sala.modulo.js     # Config CRUD de Sala
    docente.modulo.js  # Config CRUD de Docente
```

Todos los archivos anteriores se sirven en un **único bundle** `~/bundles/intranet`.

Para agregar un nuevo módulo CRUD:
1. Crear `Scripts/modulos/nuevo.modulo.js` con la config
2. Registrarlo en `BundleConfig.cs`
3. La vista solo necesita: `<div id="divTabla" data-modulo="Nuevo"></div>`

---

## Estado de los datos

Los mantenedores y el portal del alumno usan **datos en memoria** (listas estáticas en los controllers). Cuando el backend WCF tenga los endpoints implementados:

- Los proxies (`Proxy/WCFCustomIntranetClient.cs`, `WCFCampusClient.cs`, `WCFCourseClient.cs`) ya están listos
- Los datos del horario se centralizan en `Controllers/HorarioHelper.cs`
- En los controllers de mantenedores, reemplazar la lista estática por la llamada al proxy correspondiente

---

## Build

```bash
msbuild intranet\LadoCliente\intranetMVC\intranetMVC.csproj /p:Configuration=Debug
```

O desde Visual Studio: **Build → Build Solution** (`Ctrl+Shift+B`)
