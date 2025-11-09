using System.Collections;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using FluorineFx.Context;
using FluorineFx.Security;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.amf3service.cl;

namespace Reines.dmsflex.amf3service
{

    public class LoginCommand : GenericLoginCommand 
    {

        private UsuarioBll _controller;
        private UsuarioBll Controller
        {
            get
            {
                if (_controller != null)
                {
                    return _controller;
                }
                _controller = new UsuarioBll();
                return _controller;
            }
        }

        public override void Start()
        {
            //NA 
        }

        public override void Stop()
        {
            //NA 
        } 


        public override IPrincipal DoAuthentication(string username, Hashtable credentials)
        {
            SessionFactory.InfoLog("DoAuthentication" +username +  " preLogin");
            var mensaje = "Usuario no valido";
            var startTime = DateTime.Now;            
            var roll = string.Empty;
            var password = credentials["password"] as string;
            mensaje = Controller.Login(username.ToUpper(), password, out roll);
            if (mensaje.Length == 0)
            {                                
                var roles = new string[3];
                roles = new string[] {"admin", "privilegeduser", "users"};
                //roles[0] = roll; 
                var identity = new GenericIdentity(username, "web");
                var principal = new GenericPrincipal(identity, roles);
                return principal;
            }            
            return null;
        }


        public override bool DoAuthorization(IPrincipal principal, IList roles)
        {
            return roles.Cast<string>().Any(role => principal.IsInRole(role));
        }


        public override bool Logout(IPrincipal principal)
        {
            var startTime = DateTime.Now;            
            if (principal.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                if (principal.Identity.Name != null && FluorineContext.Current.Session.SessionID != null)
                {
                    Controller.RegistraSalida(principal.Identity.Name.ToUpper(), HttpContext.Current.Request.UserHostAddress);
                    //Controller.UpdateSession(principal.Identity.Name, FluorineContext.Current.Session.SessionID, 0, 0, 0);
                    SessionFactory.InfoLog(startTime, SessionFactory.Tipo.Logout, "clientes.Logout", "usuario:" + principal.Identity.Name);                    
                }  
            }
            return true;
        }

        public bool Logout()
        {            
            FormsAuthentication.SignOut();                                    
            return true;
        }

        
    }
}