using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using FluorineFx;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.amf3service.cl;
using Reines.dmsflex.amf3service.vo;

namespace Reines.dmsflex.amf3service
{

    [RemotingService]
    public class BeforeDateSrv 
    {

        public string Echo(string name)
        {
            return "Before Date Manager" + name;
        }

        public IList<CitaPreviaVo> ListaCitaPrevias()
        {
            var sesionVo = SessionFactory.GetSession();
            var bll = new CitaPreviaBll();
            var lista = bll.SelectAllCitaPrevia();
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "BeforeDateSrv.ListaCitaPrevias", "usuario:" + sesionVo.Usuario); 
            return CitaPreviaFactory.FromList(lista);
        }

        public IList<NegocioVo> ListaNegocios()
        {
            var negociosBll = new ParametrosBll();
            var negocios = negociosBll.SelectAllNegocios();
            return NegocioFactory.FromList(negocios);
        }

        public IList<CiudadVo> ListaCiudades()
        {
            var ciudadBll = new ParametrosBll();
            var ciudades = ciudadBll.SelectAllCiudades();
            return CiudadFactory.FromList(ciudades);
        }

        public IList<CalendarioVo> ListaFechas(double ciuNcodigo)
        {
            var sesionVo = SessionFactory.GetSession();
            if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
            var calendarioBll = new ParametrosBll();
            var calendario = calendarioBll.SelectAllFechas(1,ciuNcodigo);
            return CalendarioFactory.FromList(calendario);
        }

        public IList<JornadaVo> ListaJornadas(CalendarioVo calendarioVo, double ciuNcodigo)
        {
            var sesionVo = SessionFactory.GetSession();
            if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
            var jornadaBll = new ParametrosBll();
            var jornadas = jornadaBll.SelectAllJornadas(CalendarioFactory.ToDao(calendarioVo), ciuNcodigo);
            return JornadaFactory.FromList(jornadas);
        }

        public int GuardaCitaPrevia(CitaPreviaVo citaPreviaVo,string citCfecha)
        {
            var sesionVo = SessionFactory.GetSession();
            citaPreviaVo.AudCusuario = sesionVo.Usuario;
            var citaPreviaBll = new CitaPreviaBll();
            citaPreviaVo.CprFfecha = DateTime.ParseExact(citCfecha, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "BeforeDateSrv.GuardaCitaPrevia", "usuario:" + sesionVo.Usuario); 
            return citaPreviaBll.GuardaCitaPrevia(CitaPreviaFactory.ToDao(citaPreviaVo));
        }

        public int CancelaCitaPrevia(CitaPreviaVo citaPreviaVo)
        {
            var sesionVo = SessionFactory.GetSession();
            citaPreviaVo.AudCusuario = sesionVo.Usuario;
            var citaPreviaBll = new CitaPreviaBll();            
            citaPreviaBll.CancelaCitaPrevia(CitaPreviaFactory.ToDao(citaPreviaVo));
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "BeforeDateSrv.CancelaCitaPrevia", "usuario:" + sesionVo.Usuario); 
            return 1;
        }
        
    }
}
