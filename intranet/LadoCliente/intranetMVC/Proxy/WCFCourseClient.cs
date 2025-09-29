using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace intranetMVC.Proxy
{
    public class WCFCourseClient
    {
        // Asegúrese de que la URL base sea correcta
        private const string BASE_URL = "http://localhost:17476/WCFIntranet.svc/";

        // El modelo Course debe existir en intranetMVC.Models
        // public class Course { public int CourseId { get; set; } public string Name { get; set; } /* ... otros campos */ }

        #region Course Operations

        /// <summary>
        /// Lista todos los cursos usando JavaScriptSerializer.
        /// Corresponde a AlumnoListar3.
        /// </summary>
        public List<Course> CourseListar()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;

                // Asumiendo el endpoint REST para listar cursos
                var json = webclient.DownloadString(BASE_URL + "Course/CourseListar");

                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Course>>(json.ToString());
            }
            catch (Exception)
            {
                // Manejo de errores simple, se puede mejorar con logs.
                return null;
            }
        }

        /// <summary>
        /// Obtiene un curso por su ID.
        /// Corresponde a find(id) de Student.
        /// </summary>
        public Course find(string id)
        {
            try
            {
                var webclient = new WebClient();
                // Asumiendo el endpoint REST para buscar por ID
                var url = string.Format(BASE_URL + "Course/find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Course>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Crea un nuevo curso.
        /// Corresponde a createStudent. Se asume que no requiere la clase Entidad<T>.
        /// </summary>
        public bool createCourse(Course course)
        {
            try
            {
                // Serializa el objeto Course a JSON usando DataContractJsonSerializer
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Course));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, course);
                string courseJson = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;

                // Asumiendo el endpoint REST para añadir un curso
                webclient.UploadString(BASE_URL + "Course/CourseAdicionar", "POST", courseJson);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un curso existente.
        /// Corresponde a edit.
        /// </summary>
        public bool edit(Course course)
        {
            try
            {
                // Serializa el objeto Course a JSON
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Course));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, course);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;

                // Asumiendo el endpoint REST para editar un curso
                webclient.UploadString(BASE_URL + "Course/edit", "PUT", data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un curso por su ID (implementación asíncrona similar a la suya).
        /// Corresponde a delete(IdAlumno).
        /// </summary>
        public async Task<bool> delete(string IdCourse)
        {
            // Nota: Aunque usa async/await y HttpClient, sigue el patrón de su método original.
            bool resu = false;
            try
            {
                var client = new System.Net.Http.HttpClient();
                var request = new System.Net.Http.HttpRequestMessage
                {
                    // Asumiendo que su servicio WCF usa GET para la eliminación
                    Method = System.Net.Http.HttpMethod.Get,
                    RequestUri = new Uri(BASE_URL + "Course/CourseEliminar/" + IdCourse)
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    // Asumiendo que el cuerpo de la respuesta es un booleano en formato string ("true" o "false")
                    resu = Convert.ToBoolean(body);
                }
            }
            catch (Exception ex)
            {
                // En un entorno de producción, considere registrar la excepción
                throw ex;
            }
            return resu;
        }

        #endregion
    }
}
