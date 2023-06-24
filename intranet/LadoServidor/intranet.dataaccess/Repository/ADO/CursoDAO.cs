using intranet.dataaccess.Repository.IRepository;
using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace intranet.dataaccess
{
    public class CursoDAO: IRepository<Curso>
    {
        //variables
        Curso[] lista = new Curso[100];
        static int n = 0, cont = 0;
        SqlConnection cn;

        public void Create(Curso cur)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_curso_registrar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCurso", cur.NombreCurso);
                cmd.Parameters.AddWithValue("@malla", cur.Malla);
                cmd.Parameters.AddWithValue("@tipo", cur.Tipo);
                cmd.Parameters.AddWithValue("@idCiclo", cur.idclclo);
                cmd.Parameters.AddWithValue("@idTarifa", cur.idTarifa);
                cmd.Parameters.Add("@idcurso", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public void Update(Curso cur)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCurso", cur.NombreCurso);
                cmd.Parameters.AddWithValue("@malla", cur.Malla);
                cmd.Parameters.AddWithValue("@tipo", cur.Tipo);
                cmd.Parameters.AddWithValue("@idCiclo", cur.idclclo);
                cmd.Parameters.AddWithValue("@idTarifa", cur.idTarifa);
                cmd.Parameters.Add("@idcurso", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public Curso Find(Curso o)
        {
            throw new NotImplementedException();
        }

   
        public void Delete(Curso o)
        {
            throw new NotImplementedException();
        }

        public List<Curso> ReadAll()
        {
            List<Curso> lista = new List<Curso>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_curso_all", cn);
                cmd.Parameters.AddWithValue("@tipo", "0");
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Curso al = new Curso()
                        {
                            idcurso = Convert.ToInt32(dr[0]),  
                            NombreCurso = dr[3].ToString(),
                            Malla = (Char)dr[2],
                            idclclo = Convert.ToInt32(dr[3])
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

        public Curso FindById(int o)
        {
            for (int i = 0; i < n; i++)
            {
                if (lista[i].idcurso == o)
                {
                    return lista[i];
                }
            }
            return null;
        }

        public List<Curso> ReadAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
