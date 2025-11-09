using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class EstadoCitaVo 
    {
        public double EtcNcodigo { get; set; }
        public string EtcCnombre { get; set; }
    }

    public class EstadoCitaFactory : FactoryVoBase
    {
        public static List<EstadoCitaVo> FromList(IList<PestCita> items)
        {
            var lista = new List<EstadoCitaVo>();
            foreach (PestCita item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static EstadoCitaVo ToVo(PestCita item)
        {
            var elemento = new EstadoCitaVo();
            CopyProperties(item, elemento);
            return elemento;
        }

        public static PestCita ToDao(EstadoCitaVo item)
        {
            var elemento = new PestCita();
            CopyProperties(item, elemento);
            return elemento;
        }
    }

}
