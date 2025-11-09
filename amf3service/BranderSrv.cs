using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FluorineFx;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.amf3service.cl;
using Reines.dmsflex.amf3service.vo;

namespace Reines.dmsflex.amf3service
{

    [RemotingService]
    public class BranderSrv
    {

        public string Echo(string name)
        {
            return "Before Date Manager" + name;
        }


        public IList<BranderVo> ListaBranders()
        {
            var sesionVo = SessionFactory.GetSession();
            var bll = new BrandersBll();
            var lista = bll.SelectAllBranders(2);
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "BranderSrv.ListaBranders", "usuario:" + sesionVo.Usuario);
            return BranderFactory.FromList(lista);
        }

        public IList<NegocioVo> ListaNegocios()
        {
            var negociosBll = new ParametrosBll();
            var negocios = negociosBll.SelectAllNegocios(2);
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
            var calendario = calendarioBll.SelectAllFechas(1, ciuNcodigo);
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

        public int GuardaBrander(BranderVo branderVo, string braCfecha)
        {
            var sesionVo = SessionFactory.GetSession();
            branderVo.AudCusuario = sesionVo.Usuario;
            var bll = new BrandersBll();
            branderVo.BraFfecha = DateTime.ParseExact(braCfecha, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "BranderSrv.GuardaBrander", "usuario:" + sesionVo.Usuario);
            return bll.GuardaBrander(BranderFactory.ToDao(branderVo));
        }

        public int CancelaBrander(BranderVo branderVo)
        {
            var sesionVo = SessionFactory.GetSession();
            branderVo.AudCusuario = sesionVo.Usuario;
            var bll = new BrandersBll();
            bll.CancelaBrander(BranderFactory.ToDao(branderVo));
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "BranderSrv.CancelaBrander", "usuario:" + sesionVo.Usuario);
            return 1;
        }
        

    }
}
