using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace intranet.dataaccess
{
    public class ParticipanteDAO : IService<Participante>
    {
        SqlConnection cn;
        //bdcongresoEntities e = new bdcongresoEntities();
        //public void create(usp_participantes_listar_all_Result t)
        //{
        //    e.usp_registrar_participante(t.ap_paterno, t.ap_materno, t.nombre, t.telefono, t.sexo, t.correo, t.DNI, t.carrera, t.direccion, t.tipo_participante);
        //}

        //public void delete(usp_participantes_listar_all_Result t)
        //{
        //    e.usp_eliminar_participante(t.DNI);
        //}

        //public usp_participantes_listar_all_Result find(usp_participantes_listar_all_Result t)
        //{
        //    usp_participantes_listar_all_Result dato = null;
        //    var pro = e.usp_participantes_datos(t.DNI);
        //    foreach (var item in pro)
        //    {
        //        dato = new usp_participantes_listar_all_Result()
        //        {
        //            idparticipante = item.idparticipante,
        //            nombre = item.nombre,
        //            ap_paterno = item.ap_paterno,
        //            ap_materno = item.ap_materno,
        //            DNI = item.DNI,
        //            correo = item.correo,
        //            direccion = item.direccion,
        //            tipo_participante = item.tipo_participante,
        //            carrera = item.carrera,
        //            sexo = item.sexo,
        //            telefono = item.telefono
        //        };
        //    }
        //    return dato;
        //}

        //public List<usp_participantes_listar_all_Result> readAll()
        //{
        //    return e.usp_participantes_listar_all().ToList();
        //}

        //public void update(usp_participantes_listar_all_Result t)
        //{
        //    try
        //    {
        //        e.usp_actualiza_participante_oficial(t.ap_paterno, t.ap_materno, t.nombre, t.telefono, t.sexo, t.correo, t.DNI, t.direccion, t.tipo_participante);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //  //  e.SaveChanges();
        //}

        ////lista solo los estudiantes
        //public List<usp_participantes_listar_estudiantes_Result> readAlumnos()
        //{
        //    return e.usp_participantes_listar_estudiantes().ToList();  
        //}

        ////lista solo los profesionales
        //public List<usp_participantes_listar_profesionales_Result> readProfesionales()
        //{
        //    return e.usp_participantes_listar_profesionales().ToList();
        //}

        //public List<usp_participantes_listar_ponentes_Result> readPonentes()
        //{
        //    return e.usp_participantes_listar_ponentes().ToList();
        //}

        public void create(Participante p)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_registrar_participante", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellido", p.nombre);
                cmd.Parameters.AddWithValue("@Nombre", p.ap_paterno);
                cmd.Parameters.AddWithValue("@Nombre", p.ap_materno);
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

        public void update(Participante p)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_actualizar_participante", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellido", p.nombre);
                cmd.Parameters.AddWithValue("@Nombre", p.ap_paterno);
                cmd.Parameters.AddWithValue("@Nombre", p.ap_materno);
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


        public List<Participante> readAll()
        {
            List<Participante> lista = new List<Participante>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_participantes_listar_all", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Participante pa = new Participante()
                        {
                            idparticipante = Convert.ToInt32(dr[0]),
                            ap_paterno = dr[1].ToString(),
                            ap_materno = dr[2].ToString(),
                            nombre = dr[3].ToString(),
                            telefono = dr[4].ToString(),
                            sexo = dr[5].ToString(),
                            correo = dr[6].ToString()
                            //IdEmpleado = Convert.ToInt32(dr[0]),
                            //Apellidos = dr[1].ToString(),
                            //Nombre = dr[2].ToString(),
                            //Cargo = dr[3].ToString()
                        };
                        lista.Add(pa);
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

        public void delete(Participante o)
        {
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_eliminar_participante", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idparticipante", o.idparticipante);
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

        public Participante findForId(int o)
        {
            throw new NotImplementedException();
        }

  

        public Participante find(Participante o)
        {
            throw new NotImplementedException();
        }
    }
}
