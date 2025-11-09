using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Web;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.Dao;
using Reines.dmsflex.Dao.mes;
using Reines.dmsflex.amf3service.vo;
using FluorineFx.Context;
using log4net;
using Reines.Vo;

namespace Reines.dmsflex.amf3service.cl
{

    public class SessionFactory : FactoryVoBase
    {


        protected static readonly ILog ActivityLog = LogManager.GetLogger("Activity");

        public enum Tipo
        {
            Consulta,
            Actualizacion,
            Insercion,
            Descarga,
            Login,
            Intento,
            Logout
        } ;   

   
        public static void InfoLog(string info)
        {
            ActivityLog.Info(info);            
        }

        public static string StringArrayToText(string[] strArr)
        {
            var resultado = new StringBuilder();
            foreach (var s in strArr)
            {
                resultado.Append(s);
            }
            return resultado.ToString();            
        }


        public static void InfoLog(DateTime startTime,Tipo tip,string metodo,string descripcion)
        {
            var sesionVo = GetSession();
            try
            {
                var stopTime = DateTime.Now;
                var duration = stopTime - startTime;
                InfoLog("Pc*Usuario:" + sesionVo.IP + "*" + sesionVo.Usuario + "(" + sesionVo.NombreUsuario +"*"+sesionVo.NombreCliente+
                                       ");Tipo:" + tip + ";Metodo:" + metodo + ";" + descripcion + ";Ex. Time(ms):" +
                                       duration.TotalMilliseconds);
                //envia hilo                  
                //var controller = new Usuarioctr();
                //controller.SetLogConsultasHilo(sesionVo.Usuario, sesionVo.Cliente, sesionVo.IP, descripcion, "A", tip.ToString(), metodo);

            }
            catch (Exception)
            {
                //nada
            }
        }


        public static string GetUser()
        {
            char sep = '\\';
            char[] delimiterChars = {sep};                        
            if(HttpContext.Current.Request.LogonUserIdentity.Name.IndexOf(sep) > -1 )
            {
                var lista = HttpContext.Current.Request.LogonUserIdentity.Name.Split(delimiterChars);
                return lista[1];
            }
            return HttpContext.Current.Request.LogonUserIdentity.Name;
        }

        public static string GetToken()
        {
            return HttpContext.Current.Request.LogonUserIdentity.Token.ToString();
        }

        public static string GetDomain()
        {
            char sep = '\\';
            char[] delimiterChars = {sep};              
            if(HttpContext.Current.Request.LogonUserIdentity.Name.IndexOf(sep) > -1 )
            {
                var lista = HttpContext.Current.Request.LogonUserIdentity.Name.Split(delimiterChars);
                return lista[0];
            }
            return HttpContext.Current.Request.LogonUserIdentity.Name;
        }

        public static string GetIp()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static string GetNmbPc()
        {
            return HttpContext.Current.Request.UserHostName;
        }

        public static string GetNavegadorPc()
        {
            return HttpContext.Current.Request.UserAgent;
        }

        public static string GetOsPc()
        {               
            return HttpContext.Current.Request.Browser.Platform;
        }
        
        public static string InfoCliente()
        {
            return "Ip:" + GetIp() + " Puesto:" + GetNmbPc() + " Navegador:" + GetNavegadorPc() + " OS:" + GetOsPc();
        }

        public static SesionVo GetSession()
        {
            using (new UnitOfWorkScope(false))
            {
                SesionVo session = null;
                var objsession = FluorineContext.Current.Session["sesion"];
                if (objsession == null)
                {
                    if (FluorineContext.Current.User.Identity.Name != null)
                    {
                        session = GetSesion(FluorineContext.Current.User.Identity.Name, "GMT-05:00");
                        var usuarioctr = new UsuarioBll();
                        /*
                        if (!usuarioctr.Allowip(session.Cliente, session.IP))
                        {
                            throw new SecurityException(
                                "Su session ha caducado; debe volver a autenticarse en el sistema " + InfoCliente());
                        }
                        */
                        if (session.ServerTimeZone != session.ClientTimeZone)
                            throw new SecurityException(
                                "La configuracion actual de su zona horaria no es correcta;debe configurarla en " +
                                session.ServerTimeZone + InfoCliente());
                    }
                    else
                    {
                        throw new SecurityException(
                            "Su session ha caducado; debe volver a autenticarse en el sistema " +
                            InfoCliente());
                    }
                }
                else
                {
                    session = (SesionVo) objsession;
                }
                return session;
            }
        }

        public static void SetSession(SesionVo session)
        {
            if (session == null)
            {
                 FluorineContext.Current.Session["sesion"] = session;
            }
        }

        public static void SetExtension(int exttel)
        {
            var session = GetSession();
            session.Extension = exttel.ToString();
            SetSession(session);
        }

        public static string GetExtension()
        {
            var session = GetSession();
            return session.Extension;
        }

        /*
        public static SmartThreadPool GetSmartPool()
        {
            return ((SmartThreadPool)FluorineContext.Current.ApplicationState["smartPool"]);
        }


        public static WorkItemsGroup GetWorkItemsGroup()
        {
            return ((WorkItemsGroup)FluorineContext.Current.ApplicationState["WorkItemsGroup"]);
        }
        */

        private static SesionVo GetSesion(string usuario, string timezoneName)
        {
            var una = HttpRuntime.Cache;
            foreach (var cache in una)
            {
                if (cache is GenericPrincipal)
                {
                    var principal = cache as GenericPrincipal;
                    var nombre = principal.Identity.Name;
                }
            }
            var usuarioctr = new UsuarioBll();            
            var sesionVo = new SesionVo();            
            try
            {
                List<Tusuario> usuarios;                
                usuarios = usuarioctr.FetchByIdFormActive(usuario.ToUpper());
                
                if (usuarios.Count > 0)
                {                    
                    //var sede = usuarios[0].TSEDE;
                    //var ciudad = sede.CIU_NCODIGO;
                    //var nomCiudad = usuarios[0].TSEDE.PCIUDAD.CIU_CNOMBRE;
                    //var cliente = sede.CLI_NCODIGO;
                    /*
                    string nomCliente;
                    if (cliente == 0)
                    {                        
                        nomCliente =usuarios[0].TSEDE.TCLIENTE.CLI_CRAZON_SOCIAL;
                    }
                    else
                    {                        
                        nomCliente = usuarios[0].TSEDE.TCLIENTE.CLI_CRAZON_SOCIAL;
                    }
                    */
                    var sesionid = FluorineContext.Current.Session.SessionID;
                    var ip = HttpContext.Current.Request.UserHostAddress;

                    //var sessions = (IList<HttpSessionState>)FluorineContext.Current.ApplicationState["Sessions"];                    
                    var serverTimeZone = TimeZoneInfo.Local.DisplayName.Substring(1, 9).ToUpper().Trim() == "UTC-05:00" ? "GMT-05:00" : TimeZoneInfo.Local.DisplayName.Substring(1, 9).ToUpper().Trim();

                    sesionVo.IdSesion = sesionid;
                    sesionVo.IP = ip;
                    /*
                    sesionVo.Usuario = usuarios[0].USU_CCODIGO.ToUpper();
                    sesionVo.NombreUsuario = usuarios[0].USU_CNOMBRE_COMPLETO + "(" + timezoneName + ")";
                    sesionVo.Cliente = cliente;
                    sesionVo.NombreCliente = nomCliente;
                    sesionVo.Ciudad = ciudad;
                    sesionVo.NombreCiudad = nomCiudad;
                    sesionVo.Email = usuarios[0].USU_CEMAIL;
                    sesionVo.SedNcodigo = usuarios[0].SED_NCODIGO;
                    //sesionVo.NombreSede = sede.SED_CNOMBRE;
                    sesionVo.UsuCtgrol = usuarios[0].USU_CTGROL;
                    sesionVo.DpeNcodigo = usuarios[0].DPE_NCODIGO;
                    sesionVo.UsuCMenu = String.Empty;
                    sesionVo.ServerTimeZone = serverTimeZone.ToUpper().Trim();
                    sesionVo.ClientTimeZone = timezoneName.ToUpper().Trim();
                    sesionVo.UsuCobliga = usuarios[0].USU_CLOGDOMINIO == "S" ? "N" : usuarios[0].USU_COBLIGA;
                    sesionVo.Timeout = usuarios[0].USU_NTIMEOUT == 0 ? 5 : usuarios[0].USU_NTIMEOUT;
                    FluorineContext.Current.Session.Add("sesion", sesionVo);
                    */
                    return sesionVo;
                }
                throw new SecurityException("usuario no existe");
            }
            catch (Exception ex)
            {
                throw new SecurityException("Error: " + ex.Message);
            }
        }


    }
}
