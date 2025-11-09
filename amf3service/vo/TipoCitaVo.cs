using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class TipoCitaVo
    {
        public double TciNcodigo { get; set; }
        public string TciCnombre { get; set; }
    }

    public class TipoCitaFactory : FactoryVoBase
    {
        public static List<TipoCitaVo> FromList(IList<PtipoCita> items)
        {
            var lista = new List<TipoCitaVo>();
            foreach (PtipoCita item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static TipoCitaVo ToVo(PtipoCita item)
        {
            var elemento = new TipoCitaVo();
            CopyProperties(item, elemento);
            return elemento;
        }

        public static PtipoCita ToDao(TipoCitaVo item)
        {
            var elemento = new PtipoCita();
            CopyProperties(item, elemento);
            return elemento;
        }
    }


}
