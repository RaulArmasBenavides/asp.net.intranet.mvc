using intranet.service;

namespace intranet.dataaccess.Factory
{
    public abstract class DataAccessFactory
    {
        public static IAlumnoDataAccess GetProductDataAccessObj()
        {
            return new AlumnoDAO();
        }

        public static IAlumnoDataAccess GetProductDataAccessObj2()
        {
            return new ProductoTestDao();
        }
    }
}