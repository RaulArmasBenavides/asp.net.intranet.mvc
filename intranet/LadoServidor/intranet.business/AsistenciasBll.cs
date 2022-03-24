using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class AsistenciasBll
    {

        //variable de la clase usuarioeDAO
        AsistenciasDAO dao;
        //constructor
        public AsistenciasBll()
        {
            dao = new AsistenciasDAO();
        }

        public void AsistenciaAdicionar(Asistencias asis)
        {
            try
            {
                dao.create(asis);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
    
        }

        //public List<Asistencias> ListaAsistenciaCodigo(Asistencias pro)
        //{
        //    try
        //    {
        //        return dao.find(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<usp_asistencias_oficial_Result> ListaAsistenciaOficial(usp_asistencias_oficial_Result pro)
        //{
        //    try
        //    {
        //        return dao.find2(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public usp_asistencias_datos_codigo_Result Leer_asistencia_cabecera(Asistencias pro)
        //{
        //    try
        //    {
        //        return dao.Leer_asistencia_cabecera(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}




        //public List<usp_asistencias_listar_all_Result> ListarAll2()
        //{
        //    try
        //    {
        //        return dao.readAll2();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void RegistrarListaAsistentes(string codigo , List<Asistencias> pro, bool Esnuevo)
        //{
        //    try
        //    {
        //       dao.RegistrarListaAsistentes(codigo, pro, Esnuevo);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}
