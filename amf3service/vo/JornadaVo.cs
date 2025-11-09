using System;
using System.Collections.Generic;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class JornadaVo
    {
        public  double JorNcodigo { get; set; }
        public  string JorCnombre { get; set; }
        public  DateTime JorDinicio { get; set; }
        public  DateTime JorDfin { get; set; }
        public  double? JorNcodmaster { get; set; }
    }


    public class JornadaFactory : FactoryVoBase
    {
        public static List<JornadaVo> FromList(IList<Pjornada> items)
        {
            var lista = new List<JornadaVo>();
            foreach (Pjornada item in items)
            {                
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static JornadaVo ToVo(Pjornada item)
        {
            var elemento = new JornadaVo();            
            CopyProperties(item, elemento);
            return elemento;
        }

        public static Pjornada ToDao(JornadaVo item)
        {
            var elemento = new Pjornada();
            CopyProperties(item, elemento);
            return elemento;
        }
    }

}
