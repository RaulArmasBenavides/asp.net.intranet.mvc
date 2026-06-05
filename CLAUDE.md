# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

- **Solution**: `intranet/intranet.sln` (Visual Studio 2019+)
- **Build**: Open in Visual Studio → Build Solution (`Ctrl+Shift+B`), or via MSBuild:
  ```
  msbuild intranet\LadoCliente\intranetMVC\intranetMVC.csproj /p:Configuration=Debug
  ```
- **Run**: IIS Express on port **11828** (configured in `Properties/launchSettings.json` and `.vs/` IIS config)
- **No test projects exist** in this solution.

## External Dependency: WCF Backend

This MVC app is a **frontend-only client**. All data operations go through a separate WCF backend service that must be running locally:

- Default URL: `http://localhost:17476/WCFIntranet.svc/`
- Configured in `Web.config` under `<appSettings>` key `WcfBaseUrl`
- To point to a different backend, change only that key — no code changes needed

## Architecture

```
Browser → ASP.NET MVC 5 Controllers → Proxy Layer → WCF REST Backend (separate project)
```

### Proxy Layer (`Proxy/`)

Three proxy clients wrap all backend HTTP calls:

| Class | Entities handled |
|---|---|
| `WCFCustomIntranetClient` | Student (Alumno) CRUD |
| `WCFCampusClient` | Campus/Sede CRUD |
| `WCFCourseClient` | Course (Curso) CRUD |

All proxies follow the same pattern:
- Read from `ConfigurationManager.AppSettings["WcfBaseUrl"]`
- Serialize/deserialize JSON with `JavaScriptSerializer` (GET) or `DataContractJsonSerializer` (POST/PUT)
- Error handling: reads/finds return `null` on failure with `Trace.TraceError` log; writes return `bool`; async deletes rethrow with `throw` (not `throw ex`)

### Authentication

Authentication is **session-based via WCF**, not ASP.NET Identity (Identity is wired up but unused for auth):

1. `LoginController.Autenticar` (POST) calls `WcfBaseUrl + "Usuario/Validarusuario"`
2. On success: sets `Session["userName"]`
3. On failure: re-renders login view
4. Logout: `Session.Abandon()` → redirects to `Login/Index`

All protected routes rely on `Session["userName"]` being set; there is no `[Authorize]` attribute in use.

### Models

Models use `[DataContract]` / `[DataMember]` attributes for WCF JSON serialization. Key entities:

- `Student` → `Models/Student/Student.cs`
- `Campus` (Sede) → `Models/Campus/Sede.cs`
- `Course` → `Models/Courses/Course.cs`
- `Attendance` → `Models/Attendance/Attendance.cs`
- `Response<T>` — generic response wrapper for WCF calls
- `Entidad<T>` — generic request container used when POSTing entities

### Reporting

`Reportes/StudentExcel.cs` uses **EPPlus 6.2.10** to generate `.xlsx` files. Excel generation is triggered from `AlumnoController`.

### Frontend

- Bootstrap 5.3.2 + jQuery 3.7.1 + jQuery UI 1.13.2
- Shared layout: `Views/Shared/_Layout.cshtml` — fixed top navbar + collapsible left sidebar
- Custom JS per entity: `Scripts/Alumno.js`, `Scripts/Curso.js`, `Scripts/Generic.js`
- Custom CSS: `Content/miEstilo.css`, `Content/Login.css`
- Asset bundling configured in `App_Start/BundleConfig.cs`

## Key Conventions

- Controllers instantiate proxies directly (no DI container): `var client = new WCFCustomIntranetClient();`
- Default route points to `Login/Index` (set in `App_Start/RouteConfig.cs`)
- Errors in proxy calls are traced via `System.Diagnostics.Trace.TraceError` — check Visual Studio Output window or IIS logs
