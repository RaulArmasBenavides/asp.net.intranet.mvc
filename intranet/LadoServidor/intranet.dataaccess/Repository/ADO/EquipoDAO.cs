using intranet.dataaccess.Repository.IRepository;
using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace intranet.dataaccess
{
    public class EquipoDAO : IRepository<Equipo>
    {
 
        public void Create(Equipo o)
        {
            throw new NotImplementedException();
        }

        public void Delete(Equipo o)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }





        // public usp_equipo_listar_all_Result find(usp_equipo_listar_all_Result t)
        //{
        //     usp_equipo_listar_all_Result dato = null;
        //     var pro = e.usp_equipo_datos(t.idEquipo);
        //     foreach (var item in pro)
        //     {
        //         dato = new usp_equipo_listar_all_Result()
        //         {
        //             idEquipo = item.idEquipo,
        //             Nombre = item.Nombre,
        //             SO = item.SO,
        //             RAM = item.RAM,
        //             Procesador= item.Procesador,
        //             TarjetaMadre = item.TarjetaMadre
        //         };
        //     }
        //     return dato;
        // }
        public Equipo Find(Equipo o)
        {
            throw new NotImplementedException();
        }

        public Equipo FindById(int o)
        {
            throw new NotImplementedException();
        }

        public List<Equipo> ReadAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo o)
        {
            throw new NotImplementedException();
        }

    }
}
