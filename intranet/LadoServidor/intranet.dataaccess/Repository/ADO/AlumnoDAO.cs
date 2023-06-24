using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using intranet.service;
using intranet.entity;
using System;
using app.erp.rmab.common;

namespace intranet.dataaccess.Factory
{
    public class AlumnoDAO : IAlumnoDataAccess
    {
        SqlConnection cn;
        public string CadenaConexion { get; set; }

        public AlumnoDAO()
        {
            CadenaConexion = CustomXMLReader.leerConexion(1);//Constantes.CADENA_CONEXION;//ConfigurationManager.ConnectionStrings["neptuno"].ConnectionString;
        }

        public void Create(Alumno o)
        {
            using (cn = new SqlConnection(CadenaConexion))
            using (SqlCommand cmd = new SqlCommand("usp_alumno_registrar", cn))
            {
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
                    cn.Close();
                    //emp.IdEmpleado = (int)cmd.Parameters["@IdEmpleado"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(Alumno o)
        {
            using (cn = new SqlConnection(CadenaConexion))
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

        public void Delete(int id)
        {
            using (cn = new SqlConnection(CadenaConexion))
            {
                var cmd = new SqlCommand("usp_alumno_eliminar_id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idalumno", id);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    //emp.IdEmpleado = (int)cmd.Parameters["@IdEmpleado"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(Alumno o)
        {
            using (cn = new SqlConnection(CadenaConexion))
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

        public Alumno FindById(int id)
        {
            try
            {
                Alumno al = null;
                using (cn = new SqlConnection(CadenaConexion))
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

        public List<Alumno> ReadAll(int skip, int limit)
        {
            try
            {
                List<Alumno> lista = new List<Alumno>();
                int pageNumber = skip;  // Página 2
                int pageSize = limit;   // 10 elementos por página
                using (cn = new SqlConnection(CadenaConexion))
                {
                    cn.Open();
                    SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM alumnos where estado ='S'", cn);
                    int totalRecords = (int)countCommand.ExecuteScalar();

                    // Calcular el índice de inicio y el número de registros para la página actual
                    int startIndex = 0;
                    if (pageNumber > 0)
                    {
                        startIndex = (pageNumber - 1) * pageSize;
                    }

                    int endIndex = startIndex + pageSize;
                    // Obtener los registros de la página actual
                    SqlCommand command = new SqlCommand(
                        "SELECT * FROM (" +
                        "   SELECT ROW_NUMBER() OVER (ORDER BY x.idalumno) AS RowNum,* " +
                        "   FROM (select * from  alumnos where estado ='S') x " +
                        ") AS T " +
                        "WHERE T.RowNum > @startIndex AND T.RowNum <= @endIndex ", cn);
                    command.Parameters.AddWithValue("@startIndex", startIndex);
                    command.Parameters.AddWithValue("@endIndex", endIndex);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Leer los registros de la página actual
                        while (reader.Read())
                        {
                            Alumno alu = new Alumno()
                            {
                                IdAlumno = Convert.ToInt32(reader["idalumno"]),
                                ApePatAlumno = reader["ap_paterno"].ToString(),
                                ApeMatAlumno = reader["ap_materno"].ToString(),
                                NomAlumno = reader["nombre"].ToString(),
                                DNI = reader["DNI"].ToString(),
                                CodigoAlu = reader["codigo"].ToString(),
                                TelAlumno = reader["telefono"].ToString(),
                                Sexo = Convert.ToChar(reader["sexo"].ToString()),
                                EmailAlumno = reader["correo"].ToString(),
                                DirAlumno = reader["direccion"].ToString(),
                            };
                            lista.Add(alu);
                        }
                    }
                    cn.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alumno Find(Alumno o)
        {
            throw new NotImplementedException();
        }

        
    }
}
