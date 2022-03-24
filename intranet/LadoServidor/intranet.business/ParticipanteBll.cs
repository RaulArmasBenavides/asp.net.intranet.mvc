using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class ParticipanteBll
    {
        //variable de la clase ParticipanteDAO
        ParticipanteDAO dao;
        //constructor
        public ParticipanteBll()
        {
            dao = new ParticipanteDAO();
        }

        //metodos de persistencia de datos en sqlserver
        public void ParticipanteAdicionar(Participante pro)
        {
            try
            {
                dao.create(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ParticipanteActualizar(Participante pro)
        {
            try
            {
                dao.update(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ParticipanteEliminar(Participante pro)
        {
            try
            {
                dao.delete(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Participante ParticipanteBuscar(Participante pro)
        {
            try
            {
                return dao.find(pro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        public List<Participante> ParticipanteListar()
        {
            try
            {
                return dao.readAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //public List<Participante> ParticipanteAlumnoListar()
        //{
        //    try
        //    {
        //        return dao.readAlumnos();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<Participante> ParticipantePonenteListar()
        //{
        //    try
        //    {
        //        return dao.readPonentes();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<Participante> ParticipanteProfesionalListar()
        //{
        //    try
        //    {
        //        return dao.readProfesionales();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}




        /* 
        public List<usp_Proveedor_Listar_Result> ProveedorListar()
        {
            try
            {
                return dao.listaProveedores();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<usp_Categoria_Listar_Result> CategoriaListar()
        {
            try
            {
                return dao.listaCategoria();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        */
    }
}
