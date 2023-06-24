using intranet.dataaccess.Repository.IRepository;
using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace intranet.dataaccess
{
    public class AsistenciasDAO : IRepository<Asistencia>
    {

        public void Create(Asistencia asist)
        {
            SqlConnection cn;

            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_registrar_asistencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", asist.codigo);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    foreach (ListaAsistencias l in asist.listaAsistentes)
                    {
                        //registra cada asistencia 
                        cmd = new SqlCommand("usp_registrar_det_asistencia", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", l.codigo);
                        cmd.Parameters.AddWithValue("@DNI", l.DNI);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        public void Update(Asistencia o)
        {
            throw new NotImplementedException();
        }

        public void Delete(Asistencia o)
        {
            throw new NotImplementedException();
        }

        public Asistencia Find(Asistencia o)
        {
            throw new NotImplementedException();
        }

        List<Asistencia> ReadAll()
        {
            throw new NotImplementedException();
        }
        public List<Asistencia> readAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public Asistencia FindById(int o)
        {
            throw new NotImplementedException();
        }

        public List<Asistencia> ReadAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
