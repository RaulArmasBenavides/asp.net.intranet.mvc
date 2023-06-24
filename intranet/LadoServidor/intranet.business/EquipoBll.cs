using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class EquipoBll
    {
        EquipoDAO dao;
        public EquipoBll()
        {
            dao = new EquipoDAO();
        }
        public void EquipoAdicionar(Equipo pro)
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

        public void EquipoActualizar(Equipo pro)
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

        public void EquipoEliminar(Equipo pro)
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


        public Equipo EquipoBuscar(Equipo pro)
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
