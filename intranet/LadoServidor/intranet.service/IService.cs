using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intranet.service
{
    public interface IService<T>
    {
        //definir las firmas
        void create(T o);
        void update(T o);
        void delete(T o);
        T find(T o);
        T findForId(int o);
        List<T> readAll(int skip , int limit);
    }
}
