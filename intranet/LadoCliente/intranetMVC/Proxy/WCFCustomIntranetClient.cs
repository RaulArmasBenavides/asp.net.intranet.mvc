using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace intranetMVC.Proxy
{
    public class WCFCustomIntranetClient
    {
        private static string BASE_URL => ConfigurationManager.AppSettings["WcfBaseUrl"];

        #region Alumno

        public List<Student> AlumnoListar3()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                var json = webclient.DownloadString(BASE_URL + "Student/AlumnoListar");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Student>>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.AlumnoListar3] {0}", ex.Message);
                return null;
            }
        }

        public async Task<List<Student>> AlumnoListar()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_URL + "Student/AlumnoListar"),
                    Content = new StringContent("{}")
                    {
                        Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                    }
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var js = new JavaScriptSerializer();
                    return js.Deserialize<List<Student>>(body);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.AlumnoListar] {0}", ex.Message);
                throw;
            }
        }

        public Student find(string id)
        {
            try
            {
                var webclient = new WebClient();
                var url = string.Format(BASE_URL + "find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Student>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.find] {0}", ex.Message);
                return null;
            }
        }

        public bool createStudent(Student student)
        {
            try
            {
                Entidad<Student> data = new Entidad<Student>();
                data.MyProperty = student;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Entidad<Student>));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, data);
                string alumno = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Student/AlumnoAdicionar", "POST", alumno);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.createStudent] {0}", ex.Message);
                return false;
            }
        }

        public bool edit(Student student)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Student));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, student);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.edit] {0}", ex.Message);
                return false;
            }
        }

        public async Task<bool> delete(string IdAlumno)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_URL + "Student/AlumnoEliminar/" + IdAlumno)
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return Convert.ToBoolean(body);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCustomIntranetClient.delete] {0}", ex.Message);
                throw;
            }
        }

        #endregion
    }
}
