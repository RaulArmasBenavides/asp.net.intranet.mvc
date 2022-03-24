using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class ActividadBll
    {
        //variable de la clase actividadeDAO
        ActividadDAO dao;
        //constructor
        public ActividadBll()
        {
            dao = new ActividadDAO();
        }

        //metodos de persistencia de datos en sqlserver
        public void actividadeAdicionar(Actividad pro)
        {
            try
            {
                dao.create(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void actividadeActualizar(Actividad pro)
        {
            try
            {
                dao.update(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void actividadeEliminar(Actividad pro)
        {
            try
            {
                dao.delete(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //public Actividad ActividadBuscar(Actividad pro)
        //{
        //    try
        //    {
        //        return dao.BuscarporFecha(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Actividad actividadeBuscarporFecha(Actividad pro)
        //{
        //    try
        //    {
        //        return dao.BuscarporFecha(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Actividad actividadeBuscarporDescripcion(Actividad pro)
        //{
        //    try
        //    {
        //        return dao.BuscarporDescripcion(pro);
        //    } 
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<Actividad> ActividadListar()
        {
            try
            {
                return dao.readAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
