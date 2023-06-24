using System;
using intranet.service;
using intranet.entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using app.erp.rmab.common;

namespace intranet.dataaccess
{
    public class UsuarioDAO : IUsuarioDataAccess
    {
        SqlConnection cn;
        public string CadenaConexion { get; set; }

        public UsuarioDAO()
        {
            CadenaConexion = CustomXMLReader.leerConexion(1);//Constantes.CADENA_CONEXION;//ConfigurationManager.ConnectionStrings["neptuno"].ConnectionString;
        }
        public bool  valida_usuario_exists(Usuario u)
        {
            bool resultado = false;
            List<Usuario> lista = new List<Usuario>();
            using (cn = new SqlConnection(CadenaConexion))
            {
                var cmd = new SqlCommand("usp_valida_usuario_exists", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", u.user);
                cmd.Parameters.AddWithValue("@Clave", u.password);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = cmd.Parameters["@result"].Value.Equals(1)?true:false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return resultado;
            }
        }

        public void Create(Usuario o)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Find(Usuario o)
        {
            throw new NotImplementedException();
        }



        public System.Collections.Generic.List<Usuario> readAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario o)
        {
            throw new NotImplementedException();
        }

       
        public List<Usuario> ReadAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int o)
        {
            throw new NotImplementedException();
        }

      
    }
}
