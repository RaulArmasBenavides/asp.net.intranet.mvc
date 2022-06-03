using System.Web;
using System.Web.Optimization;

namespace intranetMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.css",
          "~/Content/themes/base/jquery-ui.css",
          "~/Content/datatable/css/jquery.dataTables.min.css",
          "~/Content/miEstilo.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-3.6.0.min.js"));
            //bundles.Add(new Bundle("~/bundles/jquery2", "https://code.jquery.com/ui/1.13.1/jquery-ui.js"));
            //bundles.Add(new Bundle("~/bundles/jquery2", "https://code.jquery.com/ui/1.13.1/jquery-ui.js"));
            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include("~/Content/datatable/js/dataTables.dataTables.min.js"));
            bundles.UseCdn = true;
            //bundles.Add(new ScriptBundle("~/bundles/jquery3").Include("https://cdn.datatables.net/buttons/2.2.2/js/dataTables.buttons.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery4").Include("https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery5").Include("https://cdn.datatables.net/buttons/2.2.2/js/buttons.html5.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //       //   "~/Scripts/jquery-{version}.js",
            //          "~/Scripts/jquery-ui.js"));





            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new ScriptBundle("~/bundles/respond").Include("~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/alert").Include("~/Scripts/alert.js"));
            bundles.Add(new ScriptBundle("~/bundles/MisEventos2").Include("~/Scripts/MisEventos2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/MisEventos2.js",
            //           "~/Scripts/MiEstilo.js",
            //          "~/Scripts/respond.js"));


            //bundles.Add(new Bundle("~/bundles/jquery", "http://code.jquery.com/jquery-2.0.3.min.js")
            // .Include("~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/sweetalert", "//cdn.jsdelivr.net/npm/sweetalert2@11")
            //       .Include("~/Scripts/sweetalemin.js"));

        }
    }
}
