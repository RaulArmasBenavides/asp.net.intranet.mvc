using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class Cursobll
    {

        //variable de la clase MODEL
        CursoDAO dao;
        // constructor
        public Cursobll()
        {
            dao = new CursoDAO();
        }

        // metodos de negocio
        public void CursoAdicionar(Curso pro)
        {
            dao.create(pro);
        }

        public void CursoActualizar(Curso pro)
        {
            //dao.update(pro);
        }

        public void CursoEliminar(Curso pro)
        {
            //dao.delete(pro);
        }

   

        public List<Curso> CursoListar()
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

        public Curso CursoBuscar(int id)
        {
            return dao.findForId(id);
        }
    }
}
