using System;
using intranet.service;
using intranet.entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace intranet.dataaccess
{
    public class UsuarioDAO : Service<Usuario>
    {
        SqlConnection cn;
 

        //bdcongresoEntities e = new bdcongresoEntities();

        ////crear usuario
        //public void create(usp_usuarios_listar_all_Result t)
        //{
        //    //throw new NotImplementedException();
        //    e.usp_registrar_usuario(t.usuario, t.clave);

        //}
        ////eliminar usuario
        //public void delete(usp_usuarios_listar_all_Result t)
        //{
        //    //throw new NotImplementedException();
        //    e.usp_eliminar_usuario(t.usuario);
        //}
        ////encontrar usuarios
        //public usp_usuarios_listar_all_Result find(usp_usuarios_listar_all_Result t)
        //{
        //    throw new NotImplementedException();
        //}
        ////listar usuarios
        //public List<usp_usuarios_listar_all_Result> readAll()
        //{
        //    return e.usp_usuarios_listar_all().ToList();
        //}
        ////actualizar usuarios
        //public void update(usp_usuarios_listar_all_Result t)
        //{
        //    e.usp_actualizar_usuario(t.usuario, t.clave);
        //}


        ////string usuario, string clave

        //public ObjectResult<usp_ValidaUsuario_Result> validar(usp_usuarios_listar_all_Result t)
        //{

        //    return  e.usp_ValidaUsuario(t.usuario, t.clave);
        //    //try
        //    //{
        //    //    if (Convert.ToInt32(e.usp_ValidaUsuario(t.usuario, t.clave)) == 1)
        //    //        return 1;
        //    //    else
        //    //        return 0;
        //    //}
        //    //catch (SqlException ex)
        //    //{
        //    //    throw ex;
        //    //}

        //}

        /* public usp_usuarios_listar_all_Result validar(usp_usuarios_listar_all_Result t)
            {   
                MessageBox.Show(" 1 " + t.usuario);
                MessageBox.Show(" 2 " + t.clave);


                return e.ValidaUsuario(t.usuario, t.clave);
                //return e.ValidaUsuario(t.usuario, t.clave);
                //MessageBox.Show(" el x es " + x);

                /*if(x==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               

    }*/

        public bool  valida_usuario_exists(Usuario u)
        {
            bool resultado = false;
            List<Usuario> lista = new List<Usuario>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
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

        public void create(Usuario o)
        {
            throw new NotImplementedException();
        }

        public void delete(Usuario o)
        {
            throw new NotImplementedException();
        }

        public Usuario find(Usuario o)
        {
            throw new NotImplementedException();
        }

        public Usuario findForId(int o)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Usuario> readAll()
        {
            throw new NotImplementedException();
        }

        public void update(Usuario o)
        {
            throw new NotImplementedException();
        }
    }
}
