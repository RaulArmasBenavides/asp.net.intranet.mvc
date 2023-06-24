using intranet.dataaccess;
using intranet.entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace intranet.business
{
    public class ParticipanteBll
    {
        ParticipanteDAO dao;
        public ParticipanteBll()
        {
            dao = new ParticipanteDAO();
        }

        public void ParticipanteAdicionar(Participante pro)
        {
            try
            {
                dao.Create(pro);
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
                dao.Update(pro);
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
                dao.Delete(pro);
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
                return dao.Find(pro);
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
                return dao.ReadAll();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}