using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.dataaccess.Repository.IRepository
{
    public interface IRepository<T>
    {
        void Create(T o);
        void Update(T o);
        //void Delete(T o);

        void Delete(int id);
        T Find(T o);
        T FindById(int o);
        List<T> ReadAll(int skip =0 , int limit=30);
    }
}
