using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace intranetMVC.Proxy
{
    public class WCFCourseClient
    {
        private static string BASE_URL => ConfigurationManager.AppSettings["WcfBaseUrl"];

        #region Course Operations

        public List<Course> CourseListar()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                var json = webclient.DownloadString(BASE_URL + "Course/CourseListar");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Course>>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCourseClient.CourseListar] {0}", ex.Message);
                return null;
            }
        }

        public Course find(string id)
        {
            try
            {
                var webclient = new WebClient();
                var url = string.Format(BASE_URL + "Course/find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Course>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCourseClient.find] {0}", ex.Message);
                return null;
            }
        }

        public bool createCourse(Course course)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Course));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, course);
                string courseJson = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Course/CourseAdicionar", "POST", courseJson);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCourseClient.createCourse] {0}", ex.Message);
                return false;
            }
        }

        public bool edit(Course course)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Course));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, course);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Course/edit", "PUT", data);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCourseClient.edit] {0}", ex.Message);
                return false;
            }
        }

        public async Task<bool> delete(string IdCourse)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_URL + "Course/CourseEliminar/" + IdCourse)
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
                Trace.TraceError("[WCFCourseClient.delete] {0}", ex.Message);
                throw;
            }
        }

        #endregion
    }
}
