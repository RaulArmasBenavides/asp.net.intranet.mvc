using System.Collections.Generic;
using intranet.entity;

namespace intranet.service
{
    public interface IUsuarioDataAccess
    {
        //definir las firmas
        void create(Alumno t);
        void update(Alumno t);
        void delete(Alumno t);
        Alumno findForId(Alumno t);
        Alumno findForId(int id);
        List<Alumno> readAll();
    }
}
