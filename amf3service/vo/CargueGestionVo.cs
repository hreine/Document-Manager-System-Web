using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class CargueGestionVo
    {
        public double CrgNcodigo { get; set; }
        public TrackingVo Ttracking { get; set; }
        public double CarNcodigo { get; set; }
        public string AudCusuario { get; set; }
        public DateTime AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public string UsuCcodigo { get; set; }
        public string PrgCobservacion { get; set; }
        public double? ManNcodigo { get; set; }
        public double? GetNcodigo { get; set; }
        public double? RemNcodigo { get; set; }


        public CargueGestionVo()
        {
            //
        }

        public CargueGestionVo(RcargueGestion item)
        {
            CrgNcodigo = item.CrgNcodigo;
            Ttracking = new TrackingVo(item.Ttracking);
            CarNcodigo = item.CarNcodigo;
            AudCusuario = item.AudCusuario;
            AudFfecha = item.AudFfecha;
            AudCestado = item.AudCestado;
            UsuCcodigo = item.UsuCcodigo;
            PrgCobservacion = item.PrgCobservacion;
            ManNcodigo = item.CrgNcodigo;
            GetNcodigo = item.CrgNcodigo;
            RemNcodigo = item.CrgNcodigo;
        }

    }

    public class CargueGestionFactory : FactoryVoBase
    {
        public static List<CargueGestionVo> FromList(IList<RcargueGestion> items)
        {
            var lista = new List<CargueGestionVo>();
            foreach (var item in items)
            {
                lista.Add(new CargueGestionVo(item));
            }
            return lista;
        }

        public static IList<CargueGestionVo> ListtoList(IList<RcargueGestion> rcargueGestion)
        {
            var items = new List<CargueGestionVo>();
            foreach (var elemento in rcargueGestion)
            {
                items.Add(new CargueGestionVo(elemento));
            }
            return items;
        }

    }

}
