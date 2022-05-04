using iintranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;

namespace intranet.business
{
    public class AlumnoBll
    { 
        AlumnoDao dao;
        public AlumnoBll()
        {
            dao = new AlumnoDao();
        }

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
