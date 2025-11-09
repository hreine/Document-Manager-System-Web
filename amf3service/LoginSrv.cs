using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.Dao.mes;
using Reines.dmsflex.amf3service.cl;
using Reines.dmsflex.amf3service.vo;
using FluorineFx;
using FluorineFx.Context;

namespace Reines.dmsflex.amf3service
{


    /// <summary>
    /// MyLoginService is used to force setCredentials sending out credentials
    /// For Flash this is also used to log out.
    /// </summary>
    [RemotingService]
    public class LoginSrv
    {
        
        public string Echo(string name)
        {
            return "Hola " + name;
        }

        public string Kyloader()
        {
            return "01020304050708090a0b0c0d0e0f0010";
        }
        
        public SesionVo Login(string timezoneName)
        {            
            return GetSesion(FluorineContext.Current.User.Identity.Name, timezoneName);
        }
        
        public SesionVo GetSession()
        {
            return SessionFactory.GetSession();
        }

        public bool CambioPassword(string password, string newpassword)
        {            
            SessionFactory.GetSession();
            if (FluorineContext.Current.Session["sesion"] != null)
            {
                var usuarioctr = new UsuarioBll();
                return usuarioctr.PassChange(FluorineContext.Current.User.Identity.Name, password, newpassword);
            }                        
            throw new SecurityException("Un acceso no autorizado ha sido detectado/nSu ip ha sido registrada");            
        }

        private string FillMenu(string usuCcodigo,double cliNcodigo)
        {
                var usuarioctr = new UsuarioBll();
                var mixml = new StringBuilder();            
                mixml.Append("<aplicacion nombre = \"DMS Web\" >");                
                List<Pmenu> categorias = usuarioctr.Getcategorias(usuCcodigo.ToUpper());
                foreach (var categoria in categorias)
                        {
                            var opciones = usuarioctr.GetOpcionesxCategorias(usuCcodigo.ToUpper(), cliNcodigo, categoria.MenCcategoria);
                            if (opciones.Count <= 0) continue;
                            mixml.Append("<grupo nombre=\"" + categoria.MenCcategoria + "\" >");
                            foreach (var hijo in opciones)
                            {
                                mixml.Append("<modulo nombre=\"" + hijo.MenCdescripcion + "\" codigo=\"" + hijo.MenNcodigo +
                                             "\" data=\"" + hijo.MenCnombre + "\" icon=\"" + "preagenda_icon" + "\"/>");
                            }
                            mixml.Append("</grupo>");
                        }
                    mixml.Append("</aplicacion>");                
                return mixml.ToString();                  
        }
        

        /*
         <mx:XML id="appMenu">
        <root>
            <menuitem label="Add Window" action="addWindow"/>
            <menuitem label="Add Window with Menu" action="addWindowMenu"/>
            <menuitem label="Add Area Chart" action="addArea"/>
            <menuitem label="Add Clumn Chart" action="addColumn"/>
            <menuitem label="Add Pie Chart" action="addPie"/>
            <menuitem type="separator"/> 
            <menuitem label="Context Functions">
                <menuitem label="Title" action="title"/>
                <menuitem label="Title Fill" action="titleFill"/>
                <menuitem label="Cascade" action="cascade"/>
                <menuitem label="Restore all" action="restoreAll"/>
                <menuitem label="Minimize All" action="minimizeAll"/>
                <menuitem label="Close All" action="closeAll"/>                
            </menuitem>
            <menuitem label="Config">
                <menuitem label="Top" action="barTop"/>
                <menuitem label="Bottom" action="barBottom"/>
                <menuitem label="Confirm Close" type="check" toggled="false" action="confirmClose"/>
                <menuitem label="Application Context Menu" type="check" toggled="true" action="applicationCM"/>
                <menuitem label="Window Context Menu" type="check" toggled="true" action="windowCM"/>
            </menuitem>
            <menuitem label="Styles">
                <menuitem label="Default" action="defaultStyle"/>
                <menuitem label="Windowx XP" action="xpStyle"/>
                <menuitem label="Mac OS9" action="macStyle"/>
            </menuitem>
            <menuitem label="Effects">
                <menuitem label="Default" action="deafultEffects"/>
                <menuitem label="Vista" action="vistaEffects"/>
                <menuitem label="Linear" action="linearEffects"/>
            </menuitem>                                                
        </root>
    </mx:XML>
         
         */

        /*
        private string FillXmlMenu(string usuCcodigo,decimal cliNcodigo)
        {
            var mixml = new StringBuilder();
            mixml.Append(" <root>");
            var padres = Controllermen.FetchPadres(usuCcodigo.ToUpper());
            foreach (var padre in padres)
            {
                var hijos = Controllermen.FetchPermitidosByPadre2(usuCcodigo.ToUpper(), cliNcodigo, padre.MEN_NCODIGO);
                if (hijos.Count <= 0) continue;
                mixml.Append("<menuitem label=\"" + padre.MEN_CNOMBRE + "\" >");
                foreach (var hijo in hijos)
                {
                    mixml.Append("<menuitem label=\"" + hijo.MEN_CNOMBRE + 
                                 "\" action=\"" + hijo.MEN_CCLASE + "\" icon=\"" + hijo.MEN_CIMAGEN + "\"/>");
                }
                mixml.Append("</grupo>");
            }
            mixml.Append("</root>");
            return mixml.ToString();
        }*/
        

        private SesionVo GetSesion(string usuario, string timezoneName)
        {
            SessionFactory.InfoLog("GetSesion" + usuario + " preLogin");
                var usuarioctr = new UsuarioBll();
                var sesionVo = new SesionVo();
                try
                {
                    var usuarios = usuarioctr.FetchByIdFormActive(usuario.ToUpper());
                    if (usuarios.Count > 0)
                    {                        

                        var ciudad = usuarios[0].Tsede.Pciudad.CiuNcodigo;
                        var nomCiudad = usuarios[0].Tsede.Pciudad.CiuCnombre;
                        var cliente = usuarios[0].Tsede.Tcliente.CliNcodigo;
                                           
                        var sesionid = FluorineContext.Current.Session.SessionID;
                        var ip = HttpContext.Current.Request.UserHostAddress;
                        //var sessions = (IList<HttpSessionState>)FluorineContext.Current.ApplicationState["Sessions"];                    
                        var serverTimeZone = TimeZoneInfo.Local.DisplayName.Substring(1, 9).ToUpper().Trim() ==
                                             "UTC-05:00"
                                                 ? "GMT-05:00"
                                                 : TimeZoneInfo.Local.DisplayName.Substring(1, 9).ToUpper().Trim();

                        sesionVo.IdSesion =  sesionid;
                        sesionVo.IP = ip;
                        
                        sesionVo.Usuario = usuarios[0].UsuCcodigo;
                        sesionVo.NombreUsuario = usuarios[0].UsuCnombre + " " + usuarios[0].UsuCapellido + "(" + timezoneName + ")";
                       
                        sesionVo.Cliente = cliente;
                        sesionVo.NombreCliente = usuarios[0].Tsede.Tcliente.CliCrazonSocial;
                        sesionVo.Ciudad = ciudad;
                        sesionVo.NombreCiudad = nomCiudad;
                        
                        sesionVo.Email = usuarios[0].UsuCemail;
                        sesionVo.SedNcodigo = usuarios[0].Tsede.SedNcodigo;
                        sesionVo.NombreSede = usuarios[0].Tsede.SedCnombre;

                        sesionVo.UsuCtgrol = "***";
                        sesionVo.DpeNcodigo = 0;
                        
                        sesionVo.UsuCMenu = FillMenu(sesionVo.Usuario, sesionVo.Cliente);
                        sesionVo.ServerTimeZone = serverTimeZone.ToUpper().Trim();
                        sesionVo.ClientTimeZone = timezoneName.ToUpper().Trim();

                        sesionVo.UsuCobliga = usuarios[0].UsuCobliga;
                        sesionVo.Timeout = usuarios[0].UsuNtimeout??10;
                        sesionVo.Password = Kyloader();
                                                
                        //usuarioctr.Setsession(sesionVo.Usuario, sesionid, 0, sesionVo.SedNcodigo, sesionVo.DpeNcodigo);

                        var usuFultimoCambio = usuarioctr.GetUltimaCambio(sesionVo.Usuario.ToUpper(), usuarioctr.VenceClave);
                        var tiemposincambio = (DateTime.Now - usuFultimoCambio);
                        if (tiemposincambio.Days >= (usuarioctr.VenceClave))
                        {
                            sesionVo.UsuCobliga = "S";
                        }
                        
                        usuarioctr.RegistraIngreso(sesionVo.Usuario, ip);
                        FluorineContext.Current.Session.Add("sesion", sesionVo);
                        SessionFactory.InfoLog("Pc*Usuario:" + sesionVo.IP + "*" + sesionVo.Usuario + "(" + sesionVo.NombreUsuario + ") Login");                                               
                        return sesionVo;
                    }
                    throw new SecurityException("usuario no existe");
                }
                catch (Exception ex)
                {
                    throw new SecurityException("Error: " + ex.Message);
                }
            
        }


        public bool Logout()
        {
            var una = HttpRuntime.Cache;
            foreach (var cache in una)
            {
                if (cache is GenericPrincipal)
                {
                    var principal = cache as GenericPrincipal;
                    if (principal.Identity.IsAuthenticated)
                        FormsAuthentication.SignOut();            
                }
            }
            
            return true;            
        }

        public IList<SesionVo> ListSesions()
        {
            var sessions = (IList<HttpSessionState>)FluorineContext.Current.ApplicationState["Sessions"];
            return sessions.Select(item => (SesionVo) item["sesion"]).Where(tempsesion => tempsesion != null).ToList();
        }


    }
}