using System.Collections.Generic;
using System.Data.SqlClient;
using intranet.dataaccess;
using intranet.entity;

namespace intranet.business
{
    public class SedeBll
    {

        //variable de la clase SalaDAO
        SedeDAO dao;

        public SedeBll()
        {
            dao = new SedeDAO();
        }


        //metodos de persistencia de datos en sqlserver
        public void SedeAdicionar(Sede pro)
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

        public void SedeActualizar(Sede pro)
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

        public void SedeEliminar(Sede pro)
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


        public Sede SedeBuscar(Sede pro)
        {
            try
            {
                return dao.find(pro);
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
                return dao.readAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        //metodos de persistencia de datos en sqlserver
        public void SalaAdicionar(Sala pro)
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

        public void SalaActualizar(Sala pro)
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

        public void SalaEliminar(Sala pro)
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


        public Sala SalaBuscarPorNombre(Sala pro)
        {
            try
            {
                return dao.findbyName(pro.nombre);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        public List<Sala> SalaListar()
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
