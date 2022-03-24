using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace intranet.dataaccess
{
    public class EquipoDAO : Service<Equipo>
    {
        // entidades  usando ENTITY FRAMEWORK
        //bdcongresoEntities e = new bdcongresoEntities();

        public void create(Equipo o)
        {
            throw new NotImplementedException();
        }

        //public void create(usp_equipo_listar_all_Result t)
        //{
        //    try
        //    {
        //        e.usp_registrar_Equipo(t.Nombre,t.SO,t.Procesador,t.RAM,t.TarjetaMadre);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void delete(Equipo o)
        {
            throw new NotImplementedException();
        }

        //public void delete(usp_equipo_listar_all_Result t)
        //{
        //    try
        //    {
        //        e.usp_eliminar_Equipo(t.idEquipo);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}



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
        public Equipo find(Equipo o)
        {
            throw new NotImplementedException();
        }
        public Equipo findForId(int o)
        {
            throw new NotImplementedException();
        }

        //public usp_equipo_listar_all_Result find_codigo(usp_equipo_listar_all_Result t)
        //{
        //    usp_equipo_listar_all_Result dato = null;
        //    var pro = e.usp_equipo_datos_codigo(t.Nombre);
        //    foreach (var item in pro)
        //    {
        //        dato = new usp_equipo_listar_all_Result()
        //        {
        //            idEquipo = item.idEquipo,
        //            Nombre = item.Nombre,
        //            SO = item.SO,
        //            RAM = item.RAM,
        //            Procesador = item.Procesador,
        //            TarjetaMadre = item.TarjetaMadre
        //        };
        //    }
        //    return dato;
        //}


  
        public void update(Equipo o)
        {
            throw new NotImplementedException();
        }

        //public void update(usp_equipo_listar_all_Result t)
        //{
        //    try
        //    {
        //        e.usp_actualizar_equipo(t.idEquipo,t.Nombre,t.SO,t.Procesador,t.RAM,t.TarjetaMadre);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        List<Equipo> Service<Equipo>.readAll()
        {
            throw new NotImplementedException();
        }
    }
}
