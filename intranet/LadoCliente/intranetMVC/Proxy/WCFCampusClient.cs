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
    public class WCFCampusClient
    {
        private static string BASE_URL => ConfigurationManager.AppSettings["WcfBaseUrl"];

        #region Campus Operations

        public List<Campus> CampusListar()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                var json = webclient.DownloadString(BASE_URL + "Campus/CampusListar");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Campus>>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCampusClient.CampusListar] {0}", ex.Message);
                return null;
            }
        }

        public Campus find(string id)
        {
            try
            {
                var webclient = new WebClient();
                var url = string.Format(BASE_URL + "Campus/find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Campus>(json);
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCampusClient.find] {0}", ex.Message);
                return null;
            }
        }

        public bool createCampus(Campus campus)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Campus));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, campus);
                string campusJson = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Campus/CampusAdicionar", "POST", campusJson);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCampusClient.createCampus] {0}", ex.Message);
                return false;
            }
        }

        public bool edit(Campus campus)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Campus));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, campus);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Campus/edit", "PUT", data);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("[WCFCampusClient.edit] {0}", ex.Message);
                return false;
            }
        }

        public async Task<bool> delete(string IdCampus)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BASE_URL + "Campus/CampusEliminar/" + IdCampus)
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
                Trace.TraceError("[WCFCampusClient.delete] {0}", ex.Message);
                throw;
            }
        }

        #endregion
    }
}
