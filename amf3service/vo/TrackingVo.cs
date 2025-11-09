using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class TrackingVo
    {
        public double TrkNcodigo;
        public string AudCusuario;
        public DateTime AudFfecha;
        public string AudCestado;
        public string TrkCdescripcion;
        public string TrkCfinal;
        public string TrkCaccion;

        public TrackingVo()
        {

        }

        public TrackingVo(Ttracking item)
        {
            TrkNcodigo = item.TrkNcodigo;
            AudCusuario = item.AudCusuario;
            AudFfecha = item.AudFfecha;
            AudCestado = item.AudCestado;
            TrkCdescripcion = item.TrkCdescripcion;
            TrkCfinal = item.TrkCfinal;
            TrkCaccion = item.TrkCaccion;
        }

    }

    public class TrackingFactory : FactoryVoBase
    {
        public static List<TrackingVo> FromList(List<Ttracking> items)
        {
            var lista = new List<TrackingVo>();
            foreach (Ttracking item in items)
            {
                var elemento = ToVo(item);
                lista.Add(elemento);
            }
            return lista;
        }

        public static TrackingVo ToVo(Ttracking item)
        {
            var estado = new TrackingVo(item);        
            return estado;
        }
    }

}
