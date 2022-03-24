using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using intranet.entity;
using intranet.dataaccess;

namespace intranet.business
{
    public class ListaEquiposBll
    {
        ListaEquiposDAO dao = new ListaEquiposDAO();


        public ListaEquipos ListaEquipoCodigo(ListaEquipos pro)
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

        //public void RegistrarListaEquipo(string codigo, List<ListaEquipos> pro, bool EsNuevo)
        //{
        //    try
        //    {
        //        dao.RegistrarListaEquipos(codigo, pro, EsNuevo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public List<ListaEquipos> ListarAll2()
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

    }
}
