using System;
using System.Collections.Generic;
using intranet.entity;
using intranet.service;
using System.Data.SqlClient;
using System.Data;

namespace intranet.dataaccess
{
    public class SedeDAO : Service<Sede>
    {

        SqlConnection cn;
 
        public void create(Sede sa)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_registrar_sala", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", sa.nombre);
                cmd.Parameters.AddWithValue("@direccion", sa.direccion);
                //cmd.Parameters.AddWithValue("@tipo_sala", sa.capacidad);
                //cmd.Parameters.AddWithValue("@rol_creacion", sa.rol_creacion);
                //cmd.Parameters.AddWithValue("@ubicacion", sa.ubicacion);
                //cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    //emp.IdEmpleado = (int)cmd.Parameters["@IdEmpleado"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void delete(Sede s)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_eliminar_sala", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", s.idsede);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    //emp.IdEmpleado = (int)cmd.Parameters["@IdEmpleado"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Sede find(Sede o)
        {
            throw new NotImplementedException();
        }

        public Sede findForId(int o)
        {
            throw new NotImplementedException();
        }

        public List<Sede> readAll()
        {
            List<Sede> lista = new List<Sede>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_sede_all", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sede sa = new Sede()
                        {
                            idsede = Convert.ToInt32(dr[0]),
                            nombre = dr[1].ToString(),
                            direccion = dr[2].ToString()

                        };
                        lista.Add(sa);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lista;
            }
        }

        public void update(Sede s)
        {
            throw new NotImplementedException();
        }
    }
}
