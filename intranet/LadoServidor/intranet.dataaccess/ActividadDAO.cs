using intranet.entity;
using intranet.service;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;

namespace intranet.dataaccess
{
    public class ActividadDAO : IService<Actividad>
    {
        SqlConnection cn;
        public void create(Actividad o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Apellido", o.NomAlumno);
                //cmd.Parameters.AddWithValue("@Nombre", o.ApePatAlumno);
                //cmd.Parameters.AddWithValue("@Cargo", o.EmailAlumno);
                cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public void update(Actividad o)
        {
            throw new NotImplementedException();
        }

        public void delete(Actividad o)
        {
            throw new NotImplementedException();
        }

        public Actividad find(Actividad o)
        {
            throw new NotImplementedException();
        }

        public Actividad findForId(int o)
        {
            throw new NotImplementedException();
        }

        public List<Actividad> readAll()
        {
            List<Actividad> lista = new List<Actividad>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_actividades_all", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Actividad al = new Actividad()
                        {
                            
                            //IdAlumno = Convert.ToInt32(dr[0]),
                            //NomAlumno = dr[1].ToString(),
                            //ApePatAlumno = dr[2].ToString(),
                            //ApeMatAlumno = dr[3].ToString(),
                            //DirAlumno = dr[4].ToString(),
                            //TelAlumno = dr[5].ToString(),
                            //EmailAlumno = dr[6].ToString(),
                            //DNI = dr[7].ToString()
                            //Nombre = dr[2].ToString(),
                            //Cargo = dr[3].ToString()
                        };
                        lista.Add(al);
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

        public List<Actividad> readAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
