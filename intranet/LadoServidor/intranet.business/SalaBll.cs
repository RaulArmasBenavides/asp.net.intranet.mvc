using System.Collections.Generic;
using System.Data.SqlClient;
using intranet.dataaccess;
using intranet.entity;

namespace intranet.business
{
    public class SalaBll
    {

        //variable de la clase SalaDAO
        SalaDAO dao;

        public SalaBll()
        {
            dao = new SalaDAO();
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
