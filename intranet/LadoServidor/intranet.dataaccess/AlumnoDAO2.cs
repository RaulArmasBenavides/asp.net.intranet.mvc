using System;
using System.Collections.Generic;
using intranet.entity;
using intranet.service;
using System.Data.SqlClient;
using System.Data;
using intranet.dataaccess;

namespace iintranet.dataaccess
{
    public class AlumnoDao: IService<Alumno>
    {
        SqlConnection cn;
        public void create(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_registrar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", o.NomAlumno);
                cmd.Parameters.AddWithValue("@ap_paterno", o.ApePatAlumno);
                cmd.Parameters.AddWithValue("@ap_materno", o.ApeMatAlumno);
                cmd.Parameters.AddWithValue("@DNI", o.DNI);
                cmd.Parameters.AddWithValue("@sexo", o.Sexo);
                cmd.Parameters.AddWithValue("@carrera", o.Carrera);
                cmd.Parameters.AddWithValue("@telefono", o.TelAlumno);
                cmd.Parameters.AddWithValue("@correo", o.EmailAlumno);
                cmd.Parameters.AddWithValue("@direccion", o.DirAlumno);
                cmd.Parameters.AddWithValue("@tipo_alumno", o.Tipo);
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

        public void delete(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_eliminar_id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idalumno", o.IdAlumno);
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

        public void update(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", o.NomAlumno);
                cmd.Parameters.AddWithValue("@ap_paterno", o.ApePatAlumno);
                cmd.Parameters.AddWithValue("@ap_materno", o.ApeMatAlumno);
                cmd.Parameters.AddWithValue("@DNI", o.DNI);
                cmd.Parameters.AddWithValue("@sexo", o.Sexo);
                cmd.Parameters.AddWithValue("@carrera", o.Carrera);
                cmd.Parameters.AddWithValue("@telefono", o.TelAlumno);
                cmd.Parameters.AddWithValue("@correo", o.EmailAlumno);
                cmd.Parameters.AddWithValue("@direccion", o.DirAlumno);
                cmd.Parameters.AddWithValue("@tipo_alumno", o.Tipo);
                // cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public Alumno findForId(int id)
        {
            try
            {
                Alumno al = null;
                using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
                {
                    var cmd = new SqlCommand("usp_buscar_alumno_id", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (dr != null)
                    {
                        int posId = dr.GetOrdinal("idAlumno");
                        int posApePat = dr.GetOrdinal("ApePatAlumno");
                        int posApeMat = dr.GetOrdinal("ApeMatAlumno");
                        int posNom = dr.GetOrdinal("NomAlumno");
                        int posmail = dr.GetOrdinal("EmailAlumno");
                        int posdni = dr.GetOrdinal("DNI");
                        int postel = dr.GetOrdinal("TelAlumno");
                        if (dr.Read())
                        {
                            al = new Alumno();
                            al.IdAlumno = dr.GetInt32(posId);
                            al.NomAlumno = dr.GetString(posNom);
                            al.ApePatAlumno = dr.GetString(posApePat);
                            al.ApeMatAlumno = dr.GetString(posApeMat);
                            al.EmailAlumno = dr.GetString(posdni);
                            al.TelAlumno = dr.GetString(postel);
                        }
                        dr.Close();
                    }
                }
                return al;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }


        public List<Alumno> readAll()
        {
            List<Alumno> lista = new List<Alumno>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumnos_listar_all", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Alumno al = new Alumno()
                        {

                            IdAlumno = Convert.ToInt32(dr[0]),
                            ApePatAlumno = dr[1].ToString(),
                            ApeMatAlumno = dr[2].ToString(),
                            NomAlumno = dr[3].ToString(),
                            DNI = dr[4].ToString(),
                            CodigoAlu = dr[5].ToString(),
                            TelAlumno = dr[6].ToString(),
                            Sexo = Convert.ToChar(dr[7].ToString()),
                            EmailAlumno = dr[8].ToString(),
                            DirAlumno = dr[9].ToString(),

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

        public Alumno find(Alumno o)
        {
            throw new NotImplementedException();
        }

        
    }
}
