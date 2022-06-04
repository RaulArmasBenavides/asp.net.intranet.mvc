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
                var cmd = new SqlCommand("usp_registrar_sede", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", sa.nombre);
                cmd.Parameters.AddWithValue("@direccion", sa.direccion);
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





        //Sala

        public void create(Sala sa)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_registrar_sala", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", sa.nombre);
                cmd.Parameters.AddWithValue("@capacidad", sa.capacidad);
                cmd.Parameters.AddWithValue("@tipo_sala", sa.capacidad);
                cmd.Parameters.AddWithValue("@rol_creacion", sa.rol_creacion);
                cmd.Parameters.AddWithValue("@ubicacion", sa.ubicacion);
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

        public void delete(Sala s)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_eliminar_sala", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", s.idsala);
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

        public Sala find(Sala o)
        {
            throw new NotImplementedException();
        }

        public Sala findForIdSala(int o)
        {
            throw new NotImplementedException();
        }

        public Sala findbyName(string nombre)
        {
            Sala sa = new Sala();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_buscar_sala_nombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sala sa1 = new Sala()
                        {
                            idsala = Convert.ToInt32(dr[0]),
                            nombre = dr[1].ToString(),
                            ubicacion = dr[2].ToString(),
                            capacidad = Convert.ToInt32(dr[3].ToString()),

                        };
                        sa = sa1;
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return sa;
            }
        }

        public List<Sala> readAllSalas()
        {
            List<Sala> lista = new List<Sala>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_salas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sala sa = new Sala()
                        {
                            idsala = Convert.ToInt32(dr[0]),
                            nombre = dr[1].ToString(),
                            ubicacion = dr[2].ToString(),
                            tipo_sala = dr[3].ToString(),
                            capacidad = Convert.ToInt32(dr[4])
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

        public void update(Sala s)
        {
            throw new NotImplementedException();
        }
    }
}
