using iintranet.dataaccess;
using intranet.dataaccess.Factory;
using intranet.entity;
using intranet.service;
using System.Collections.Generic;

namespace intranet.business
{
    public class AlumnoBll
    {
        private readonly IAlumnoDataAccess _AluDataAccess;
        public AlumnoBll()
        {
            _AluDataAccess = DataAccessFactory.GetProductDataAccessObj();
        }

        public void AlumnoAdicionar(Alumno pro)
        {
            _AluDataAccess.create(pro);
        }

        public void AlumnoActualizar(Alumno pro)
        {
            _AluDataAccess.update(pro);
        }

        //public void AlumnoEliminar(Alumno pro)
        //{
        //    _AluDataAccess.delete(pro);
        //}
        public bool AlumnoEliminar2(int id)
        {
            bool result = false;
            try
            {
                _AluDataAccess.delete(id);
                result = true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Alumno> AlumnoListar()
        {
            return _AluDataAccess.readAll();
        }

        public Alumno AlumnoBuscar(int id)
        {
            return _AluDataAccess.findForId(id);
        }

    }
}
