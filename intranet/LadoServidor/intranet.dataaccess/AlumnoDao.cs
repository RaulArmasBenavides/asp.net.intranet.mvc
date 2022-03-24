using System;
using System.Collections.Generic;
using intranet.entity;
using intranet.service;
using System.Data.SqlClient;
using System.Data;
using intranet.dataaccess;

namespace iintranet.dataaccess
{
    public class AlumnoDao: Service<Alumno>
    {
        SqlConnection cn;
        public void create(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellido", o.NomAlumno);
                cmd.Parameters.AddWithValue("@Nombre", o.ApePatAlumno);
                cmd.Parameters.AddWithValue("@Cargo", o.EmailAlumno);
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

        public void delete(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", o.IdAlumno);
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

        public Alumno find(Alumno o)
        {
            throw new NotImplementedException();
        }

        public void update(Alumno o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_alumno_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellido", o.IdAlumno);
                cmd.Parameters.AddWithValue("@Apellido", o.NomAlumno);
                cmd.Parameters.AddWithValue("@Nombre", o.ApeMatAlumno);
                cmd.Parameters.AddWithValue("@Cargo", o.EmailAlumno);
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

        public List<Alumno>  readAll()
        {
            List<Alumno> lista = new List<Alumno>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_alumnos_all", cn);
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
                            NomAlumno = dr[1].ToString(),
                            ApePatAlumno = dr[2].ToString(),
                            ApeMatAlumno = dr[3].ToString(),
                            DirAlumno = dr[4].ToString(),
                            TelAlumno = dr[5].ToString(),
                            EmailAlumno= dr[6].ToString(),
                            DNI = dr[7].ToString()
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


        //variables
        //Alumno[] lista = new Alumno[100];
        //static int n = 0, cont = 0;

        ////METODOS DE PERSISTENCIA DE DATOS EN MEMORIA
        //public void create(Alumno o)
        //{
        //    cont++;
        //    o.IdAlumno = cont;  // genera codigo de producto
        //    lista[n] = o; // aqui guarda producto en el arreglo lista
        //    n++;
        //}

        //public void delete(Alumno o)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (lista[i].IdAlumno == o.IdAlumno)
        //        {
        //            //aqui elimina
        //            for (int j = i; j < n; j++)
        //            {
        //                lista[j] = lista[j + 1];
        //            }
        //            n--;
        //            break;
        //        }
        //    }
        //}

        //public Alumno findForId(int o)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (lista[i].IdAlumno == o)
        //        {
        //            return lista[i];
        //        }
        //    }
        //    return null;
        //}

        //public Alumno[] readAll()
        //{
        //    Alumno[] temp;
        //    if (n ==100)
        //    {
        //        temp = lista;
        //    }
        //    else
        //    {
        //        temp = new Alumno[n];
        //        Array.Copy(lista, temp, n);
        //    }
        //    return temp;
        //}

        //public void update(Alumno o)
        //{
        //    int index = 0;
        //    foreach (var item in lista)
        //    {
        //        if (item.IdAlumno == o.IdAlumno)
        //        {
        //            lista[index] = o; // aqui actualiza
        //            break;
        //        }
        //        index++;
        //    }
        //}
    }
}
