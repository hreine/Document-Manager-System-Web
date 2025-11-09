using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.maestros;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.BLL.mes
{
    public class ParametrosBll : IDisposable
    {



        public IList<Pcalendario> SelectAllFechas(double sedNcodigo, double ciuNcodigo)
        {
            var obj = new JornadaDao();
            return obj.SelectAllFechas(sedNcodigo, ciuNcodigo);
        }

        public IList<Pcalendario> SelectAllFechas(double ciuNcodigo)
        {
            var obj = new JornadaDao();
            return obj.SelectAllFechas(ciuNcodigo);
        }


        public IList<Pjornada> SelectAllJornadas(Pcalendario pcalendario, double ciuNcodigo)
        {
            var obj = new JornadaDao();
            return obj.SelectAllJornadas(pcalendario, ciuNcodigo);
        }

        public IList<Pjornada> SelectAllJornadas()
        {
            var obj = new JornadaDao();
            return obj.SelectAllJornadas();
        }


        public IList<TmotTelefonicos> SelectMasterMotTelefonicos()
        {
            var obj = new MotTelefonicosDao();
            return obj.SelectMasterMotTelefonicos();
        }

        public IList<TmotTelefonicos> SelectMotTelefonicos(double motNmaster)
        {
            var obj = new MotTelefonicosDao();
            return obj.SelectMotTelefonicos(motNmaster);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        public IList<Tnegocio> SelectAllNegocios()
        {
            var obj = new NegocioDao();
            return obj.SelectNegocios();
        }

        public IList<Tnegocio> SelectAllNegocios(int negNcodigo)
        {
            var obj = new NegocioDao();
            return obj.SelectNegocios(negNcodigo);
        }

        

        public IList<Pciudad> SelectAllCiudades()
        {
            var obj = new CiudadDao();
            return obj.SelectCiudades();
        }
    }
}
