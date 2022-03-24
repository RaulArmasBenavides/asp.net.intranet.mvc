using intranet.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace intranet.ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWCFIntranet
    {

        // TODO: Add your service operations here
        #region Alumno
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Alumno/AlumnoListar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<Alumno> AlumnoListar();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Alumno/AlumnoAdicionar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AlumnoAdicionar(Alumno emp);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Alumno/AlumnoActualizar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AlumnoActualizar(Alumno emp);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Alumno/AlumnoEliminar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AlumnoEliminar(int emp);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Alumno/AlumnoBuscar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Alumno AlumnoBuscar(int emp);
        #endregion

        #region Sala

        [OperationContract]
        [WebInvoke(
         Method = "POST",
         UriTemplate = "/Sala/SalaBuscarPorNombre",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Sala SalaBuscarPorNombre(Sala pro);
        #endregion

        #region Curso
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Curso/CursoListar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<Curso> CursoListar();
        #endregion

        #region Docente

        #endregion

        #region Horarios

        #endregion

        #region Asistencias

        #endregion

        #region Sede
        [OperationContract]
        [WebInvoke(
           Method = "POST",
           UriTemplate = "/Sede/SedeListar",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<Sede> SedesListar();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Sede/SedeAdicionar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void SedeAdicionar(Sede sed);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Sede/SedeActualizar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void SedeActualizar(Sede sed);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Sede/SedeEliminar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void SedeEliminar(int id);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Sede/SedeBuscar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Sede SedeBuscar(int id);
        #endregion

        #region Gestión de asistencias 
        [OperationContract]
        [WebInvoke(
         Method = "POST",
         UriTemplate = "/Asistencias/AsistenciaAdicionar",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AsistenciaAdicionar(Asistencias emp);
        #endregion

        #region Módulo de congreso
        [OperationContract]
        [WebInvoke(
        Method = "POST",
        UriTemplate = "/Participante/ParticipanteListar",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<Participante> ParticipanteListar();

        [OperationContract]
        void ParticipanteAdicionar(Participante emp);

        [OperationContract]
        void ParticipanteActualizar(Participante emp);

        [OperationContract]
        void ParticipanteEliminar(int emp);

        [OperationContract]
        Alumno ParticipanteBuscar(int emp);
        #endregion



        #region Módulo de seguridad


        [OperationContract]
        [WebInvoke(
        Method = "POST",
        UriTemplate = "/Usuario/Validarusuario",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool Validarusuario(Usuario u);
        #endregion
    }

}
