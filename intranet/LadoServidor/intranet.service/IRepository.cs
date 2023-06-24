using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.service
{
    public interface IRepository<T>
    {
        void Create(T o);
        void Update(T o);
        void Delete(T o);
        T Find(T o);
        T findForId(int o);
        List<T> ReadAll(int skip , int limit);
    }
}
