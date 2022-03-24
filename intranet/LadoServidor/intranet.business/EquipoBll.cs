using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class EquipoBll
    {
        //variable de la clase EquipoDAO
        EquipoDAO dao;

        public EquipoBll()
        {
            dao = new EquipoDAO();
        }


        //metodos de persistencia de datos en sqlserver
        public void EquipoAdicionar(Equipo pro)
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

        public void EquipoActualizar(Equipo pro)
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

        public void EquipoEliminar(Equipo pro)
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


        public Equipo EquipoBuscar(Equipo pro)
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
        //public Equipo EquipoBuscar_Nombre(Equipo pro)
        //{
        //    try
        //    {
                
        //       // return dao.find_codigo(pro);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public List<Equipo> EquipoListar()
        //{
        //    try
        //    {
        //        return;
        //        //return dao.readAll();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
