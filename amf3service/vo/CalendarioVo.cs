using System;
using System.Collections.Generic;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class CalendarioVo
    {
        public double CalNcodigo;
        public DateTime CalFfecha;
        public string CalCobservacion;
    }

    public class CalendarioFactory : FactoryVoBase
    {

        public static List<CalendarioVo> FromList(IList<Pcalendario> items)
        {
            var lista = new List<CalendarioVo>();
            foreach (Pcalendario item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CalendarioVo ToVo(Pcalendario item)
        {
            var elemento = new CalendarioVo();
            elemento.CalNcodigo = item.CalNcodigo;
            elemento.CalFfecha = item.CalFfecha;
            elemento.CalCobservacion = item.CalCobservacion;            
            return elemento;
        }

        public static Pcalendario ToDao(CalendarioVo item)
        {
            var elemento = new Pcalendario();
            elemento.CalNcodigo = item.CalNcodigo;
            elemento.CalFfecha = item.CalFfecha;
            elemento.CalCobservacion = item.CalCobservacion;
            return elemento;
        }
    }

}
