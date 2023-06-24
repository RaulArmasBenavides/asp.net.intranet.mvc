using System.Collections.Generic;
using System.Data.SqlClient;
using intranet.dataaccess;
using intranet.dataaccess.Repository.IRepository;
using intranet.entity;

namespace intranet.business
{
    public class SedeBll
    {
        ISedeRepository dao;
        public SedeBll()
        {
            dao = new SedeDAO();
        }

        public void SedeAdicionar(Sede pro)
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

        public void SedeActualizar(Sede pro)
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

        public void SedeEliminar(Sede pro)
        {
            try
            {
                dao.Delete(pro.idsede);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public Sede SedeBuscar(Sede pro)
        {
            try
            {
                return dao.Find(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Sede> SedesListar()
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