using System;
using System.Collections.Generic;
using intranet.entity;
using intranet.business;
using System.ServiceModel;

namespace intranet.ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WCFIntranet : IWCFIntranet
    {
        public void AlumnoActualizar(Alumno emp)
        {
            throw new NotImplementedException();
        }

        public void AlumnoAdicionar(Alumno data)
        {
            try
            {
                AlumnoBll b = new AlumnoBll();
                b.AlumnoAdicionar(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
  
        }

        public Alumno AlumnoBuscar(int alu)
        {
            AlumnoBll b = new AlumnoBll();
            return b.AlumnoBuscar(alu);
        }

        public void AlumnoEliminar(int emp)
        {
            throw new NotImplementedException();
        }

        public List<Alumno> AlumnoListar()
        {
            AlumnoBll b = new AlumnoBll();
            return b.AlumnoListar();
        }

        public List<Curso> CursoListar()
        {
            Cursobll b = new Cursobll();
            return b.CursoListar();
        }
        

        #region Gestión de asistencias
        public void AsistenciaAdicionar(Asistencia asis)
        {
            try
            {
                AsistenciasBll b = new AsistenciasBll();
                b.AsistenciaAdicionar(asis);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Mòdulo de Congreso
        public void ParticipanteActualizar(Participante emp)
        {
            throw new NotImplementedException();
        }

        public void ParticipanteAdicionar(Participante emp)
        {
            throw new NotImplementedException();
        }

        public Alumno ParticipanteBuscar(int emp)
        {
            throw new NotImplementedException();
        }

        public void ParticipanteEliminar(int emp)
        {
            throw new NotImplementedException();
        }

        public List<Participante> ParticipanteListar()
        {
            ParticipanteBll b = new ParticipanteBll();
            return b.ParticipanteListar();
        }


        #endregion

        #region Sede

 
        public void SedeActualizar(Sede sed)
        {
            SedeBll b = new SedeBll();
            b.SedeActualizar(sed);  
        }

        public void SedeAdicionar(Sede sed)
        {
            SedeBll b = new SedeBll();
            b.SedeAdicionar(sed);
        }

        public Sede SedeBuscar(int id)
        {
            throw new NotImplementedException();
        }

        public void SedeEliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sede> SedesListar()
        {
            SedeBll b = new SedeBll();
            return b.SedesListar();
        }


        #endregion


        public bool Validarusuario(Usuario us)
        {
            UsuarioBll u = new UsuarioBll();
            return u.validarusuario(us);
        }





    }
}
