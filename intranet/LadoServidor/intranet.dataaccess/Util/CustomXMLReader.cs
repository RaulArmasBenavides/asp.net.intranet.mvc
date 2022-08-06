using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace intranet.dataaccess.Util
{
    public class CustomXMLReader
    {
        public static string ArchivoConfig = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) + "\\xmlConfig";
        public static string ArchivoParam = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) + "\\xmlParam";
        public static string GetConnectionStringFromXML(string myfilepath)
        {
            XmlTextReader xtr = new XmlTextReader(myfilepath);
            string constring = string.Empty;
            while (xtr.Read())
            {

                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "codurl")
                {

                    constring = xtr.ReadElementContentAsString();
                }

            }
            return constring;
        }

        public static DataTable LeerConfiguracionXML(string psNombreArchivo, string psTabla)
        {
            try
            {
                DataSet dsConfig = new DataSet();
                DataTable dtConfig = new DataTable();
                dsConfig.ReadXml(psNombreArchivo);
                dtConfig = dsConfig.Tables[psTabla];

                if (dtConfig == null)
                {
                    //MessageBox.Show("Datos nulos en archivo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return null;
                }
                if (dtConfig.Rows.Count <= 0)
                {
                    //MessageBox.Show("No existen datos en archivo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return null;
                }
                return dtConfig;
            }
            catch (Exception)
            {
                //MessageBox.Show("No se pudo leer archivo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return null;
            }
        }

        public static void ActualizarConfiguracionXML()
        {
            try
            {
                if (System.IO.File.Exists(ArchivoConfig))
                {
                    System.IO.File.Delete(ArchivoConfig);
                }

                XmlTextWriter Xml = new XmlTextWriter(ArchivoConfig, null);
                Xml.Indentation = 4;
                Xml.IndentChar = ' ';
                Xml.Formatting = (Formatting)Xml.Indentation;
                Xml.WriteStartDocument();
                Xml.WriteStartElement("Config");
                Xml.WriteStartElement("info");
                //Xml.WriteElementString("codurl", Configuracion.ConfigSistema.URL);
                //Xml.WriteElementString("serweb", Configuracion.ConfigSistema.SerWeb);
                ////Print Server
                //Xml.WriteElementString("impbob", Configuracion.ConfigSistema.PrintServerEtiquetaBobina);
                //Xml.WriteElementString("impcab", Configuracion.ConfigSistema.PrintServerEtiquetaCable);
                //Xml.WriteElementString("impposte", Configuracion.ConfigSistema.PrintServerEtiquetaPoste);
                //Xml.WriteElementString("impemp", Configuracion.ConfigSistema.PrintServerEtiquetaEmpaque);
                //Xml.WriteElementString("impind", Configuracion.ConfigSistema.PrintServerEtiquetaIndividual);
                //Xml.WriteElementString("impubi", Configuracion.ConfigSistema.PrintServerEtiquetaUbicacion);
                ////Impresoras
                //Xml.WriteElementString("impresoracab", Configuracion.ConfigSistema.ImpresoraEtiquetaCable);
                //Xml.WriteElementString("impresoraind", Configuracion.ConfigSistema.ImpresoraEtiquetaIndividual);
                //Xml.WriteElementString("impresoraposte", Configuracion.ConfigSistema.ImpresoraEtiquetaPoste);
                //Xml.WriteElementString("impresorabob", Configuracion.ConfigSistema.ImpresoraEtiquetaBobina);
                //Xml.WriteElementString("impresoraemp", Configuracion.ConfigSistema.ImpresoraEtiquetaEmpaque);
                //Xml.WriteElementString("impresoraubi", Configuracion.ConfigSistema.ImpresoraEtiquetaUbicacion);

                //Xml.WriteElementString("tmovil", Configuracion.ConfigSistema.TMovil);
                //Xml.WriteElementString("ultmod", Configuracion.ConfigSistema.UltMod);
                //Xml.WriteElementString("versionsma", Configuracion.ConfigSistema.VersionSMA);
                Xml.WriteEndElement();
                Xml.WriteEndElement();
                Xml.Close();
               // MessageBox.Show("Se actualizó configuración del sistema.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
               //MessageBox.Show("Error al actualizar configuración del sistema\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        //method using XmlTextReader
        public static string leerConexion()
        {
            return GetConnectionStringFromXML(ArchivoConfig);
        }

        //method using DataSet readXml
        public static string leerConexion2()
        {
            string con;
            DataTable dtConfig = LeerConfiguracionXML(ArchivoConfig, "info");
            if (dtConfig == null)
            {
                return "";
            }
            if (dtConfig.Rows.Count <= 0)
            {
                return "";
            }
            //con = dtConfig.Rows[0]["PRUEBA"].ToString().Trim();
            //ConfigSistema.URL = dtConfig.Rows[0]["codurl"].ToString().Trim();
            con = dtConfig.Rows[0]["codurl"].ToString().Trim();
            return con;
        }
    }
}


