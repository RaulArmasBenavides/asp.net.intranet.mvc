using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class ActividadBll
    {
        ActividadDAO dao;
        public ActividadBll()
        {
            dao = new ActividadDAO();
        }

        public void actividadeAdicionar(Actividad pro)
        {
            try
            {
                dao.Create(pro);
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
                dao.Update(pro);
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
                dao.Delete(pro);
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

        public List<Actividad> ActividadListar()
        {
            try
            {
                return dao.ReadAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
