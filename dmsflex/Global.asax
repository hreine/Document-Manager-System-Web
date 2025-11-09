<%@ Application Language="C#" %>
<%@ Import Namespace="FluorineFx.Context"%>


<script runat="server">

    
    void Application_Start(object sender, EventArgs e)
    {                      
        IList<HttpSessionState> sessions = new List<HttpSessionState>();
        Application.Add("Sessions", sessions);
    }


    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación        
        //((SmartThreadPool)Application["smartPool"]).Shutdown();                        
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado
    }

    void Session_Start(object sender, EventArgs e)
    {
        ((IList<HttpSessionState>)Application["Sessions"]).Add(Session);
    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera. 
        /*
        var objsessions = FluorineContext.Current.ApplicationState["Sessions"]??null;
        if (objsessions!=null)
        {
            var sessions = (IList<HttpSessionState>) objsessions;
            int posicion = 0;
            foreach (HttpSessionState item in sessions)
            {
                if (item.SessionID == Session.SessionID)
                {
                    sessions.RemoveAt(posicion);
                }
                posicion++;
            }
        }
        */
    }

        
    void Application_BeginRequest(object sender, EventArgs e)
    {
        /* Fix for the Flash Player Cookie bug in Non-IE browsers.
        * Since Flash Player always sends the IE cookies even in FireFox
        * we have to bypass the cookies by sending the values as part of the POST or GET
        * and overwrite the cookies with the passed in values.
        * 
        * The theory is that at this point (BeginRequest) the cookies have not been read by
        * the Session and Authentication logic and if we update the cookies here we'll get our
        * Session and Authentication restored correctly
        */
        /*
     
        //,no-store*/              
        try
        {
            string session_param_name = "ASPSESSID";
            string session_cookie_name = "ASP.NET_SESSIONID";

            if (HttpContext.Current.Request.Form[session_param_name] != null)
            {
                UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
            }
            else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
            {
                UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
            }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
            Response.Write("Error Initializing Session");
        }

        try
        {
            string auth_param_name = "AUTHID";
            string auth_cookie_name = FormsAuthentication.FormsCookieName;

            if (HttpContext.Current.Request.Form[auth_param_name] != null)
            {
                UpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
            }
            else if (HttpContext.Current.Request.QueryString[auth_param_name] != null)
            {
                UpdateCookie(auth_cookie_name, HttpContext.Current.Request.QueryString[auth_param_name]);
            }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
            Response.Write("Error Initializing Forms Authentication");
        }
    }
    
    void UpdateCookie(string cookie_name, string cookie_value)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        if (cookie == null)
        {
            cookie = new HttpCookie(cookie_name);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }
        cookie.Value = cookie_value;
        cookie.HttpOnly =true;
        HttpContext.Current.Request.Cookies.Set(cookie);
    }


    protected void Application_EndRequest()
    {
        // By default, IE renders pages on the intranet (same subnet) in compatibility mode.  
        // IE=edge forces IE to render in it's moststandard mode possible.  
        // IE8 Standards in IE8, IE9 Standardss in IE9, etc..
        //
        // Chrome=1 causes ChromeFrame to load, if installed.  This allows IE6 to use
        // a Chrome frame to render nicely.        
        Response.CacheControl = "no-cache";
        //Response.Headers.Add("X-Content-Type-Options", "nosniff");
        Response.AddHeader("X-Content-Type-Options", "nosniff");
        
    }
    
    
</script>
