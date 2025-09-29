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
    public class WCFCampusClient
    {
        // La URL base del servicio WCF
        private const string BASE_URL = "http://localhost:17476/WCFIntranet.svc/";

        // El modelo Campus debe existir en intranetMVC.Models
        // Ejemplo: public class Campus { public int CampusId { get; set; } public string Name { get; set; } /* ... */ }

        #region Campus Operations

        /// <summary>
        /// Lista todos los campus (sedes) usando JavaScriptSerializer.
        /// Endpoint: Campus/CampusListar
        /// </summary>
        public List<Campus> CampusListar()
        {
            try
            {
                var webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;

                // Llamada GET al endpoint para listar campus
                var json = webclient.DownloadString(BASE_URL + "Campus/CampusListar");

                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Campus>>(json.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene un campus por su ID.
        /// Endpoint: Campus/find/{id}
        /// </summary>
        public Campus find(string id)
        {
            try
            {
                var webclient = new WebClient();
                // Llamada GET para buscar por ID
                var url = string.Format(BASE_URL + "Campus/find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Campus>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Crea un nuevo campus.
        /// Endpoint: Campus/CampusAdicionar
        /// </summary>
        public bool createCampus(Campus campus)
        {
            try
            {
                // Serializa el objeto Campus a JSON
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Campus));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, campus);
                string campusJson = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;

                // Llamada POST para añadir un campus
                webclient.UploadString(BASE_URL + "Campus/CampusAdicionar", "POST", campusJson);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un campus existente.
        /// Endpoint: Campus/edit
        /// </summary>
        public bool edit(Campus campus)
        {
            try
            {
                // Serializa el objeto Campus a JSON
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Campus));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, campus);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;

                // Llamada PUT para editar un campus
                webclient.UploadString(BASE_URL + "Campus/edit", "PUT", data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un campus por su ID.
        /// Endpoint: Campus/CampusEliminar/{IdCampus}
        /// </summary>
        public async Task<bool> delete(string IdCampus)
        {
            bool resu = false;
            try
            {
                var client = new System.Net.Http.HttpClient();
                var request = new System.Net.Http.HttpRequestMessage
                {
                    // Usa GET, siguiendo el patrón de su servicio WCF
                    Method = System.Net.Http.HttpMethod.Get,
                    RequestUri = new Uri(BASE_URL + "Campus/CampusEliminar/" + IdCampus)
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    // Conversión a booleano de la respuesta del servicio
                    resu = Convert.ToBoolean(body);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resu;
        }

        #endregion
    }
}
