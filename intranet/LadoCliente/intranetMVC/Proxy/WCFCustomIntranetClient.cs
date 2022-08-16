using intranetMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace intranetMVC.Proxy
{
    //This replace the old service reference
    public class WCFCustomIntranetClient
    {
        private string BASE_URL = "http://localhost:17476/WCFIntranet.svc/";

        #region Alumno

        //using JavascriptSerializer
        public List<Alumno> AlumnoListar3()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                var json = webclient.DownloadString(BASE_URL + "Alumno/AlumnoListar");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Alumno>>(json.ToString());
            }
            catch (Exception ex) 
            {
                return null;
            }
        }//

        //using DataContractJsonSerializer
        public List<Alumno> AlumnoListar2()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "Alumno/AlumnoListar");
                var deserializedUser = new List<Alumno>();
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                var ser = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser = ser.ReadObject(ms) as List<Alumno>;
                ms.Close();
                return deserializedUser;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw;
            }
        }

        public async Task<List<Alumno>> AlumnoListar()
        {
            List<Alumno> lis = new List<Alumno>();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:17476/WCFIntranet.svc/Alumno/AlumnoListar"),
                    Content = new StringContent("{\n \n}")
                    {
                        Headers = {
                                ContentType = new MediaTypeHeaderValue("application/json")
                              }
                    }
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    //lis = Javabody;
                    var js = new JavaScriptSerializer();
                    lis = js.Deserialize<List<Alumno>>(body);
                    Console.WriteLine(body);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lis;
        }




        public Alumno find(string id)
        {
            try
            {
                var webclient = new WebClient();
                var url = string.Format(BASE_URL + "find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Alumno>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }//

        public bool create(Alumno empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Alumno));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "create", "POST", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//

        public bool edit(Alumno empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Alumno));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//

        public bool delete(Alumno empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Alumno));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//
        #endregion

    }
}