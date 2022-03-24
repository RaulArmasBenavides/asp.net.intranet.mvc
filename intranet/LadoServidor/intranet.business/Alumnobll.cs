using iintranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;

namespace intranet.business
{
    public class AlumnoBll
    { 
        //variable de la clase MODEL
        AlumnoDao dao;
        // constructor
        public AlumnoBll()
        {
            dao = new AlumnoDao();
        }

        // metodos de negocio
        public void AlumnoAdicionar(Alumno pro)
        {
            dao.create(pro);
        }

        public void AlumnoActualizar(Alumno pro)
        {
            dao.update(pro);
        }

        public void AlumnoEliminar(Alumno pro)
        {
            dao.delete(pro);
        }

        //public Alumno[] AlumnoListar()
        //{
        //    return dao.readAll();
        //}
        
        public List<Alumno> AlumnoListar()
        {
            return dao.readAll();
        }

        public Alumno AlumnoBuscar(int id)
        {
            return dao.findForId(id);
        }

    }
}
