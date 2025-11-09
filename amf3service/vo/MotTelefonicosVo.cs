using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class MotTelefonicosVo
    {
        public double MotNcodigo { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public DateTime AudFfecha { get; set; }
        public double MotNmaster { get; set; }
        public string MotCdescripcion { get; set; }
        public string MotCagendamiento { get; set; }

        public MotTelefonicosVo()
        {
            //
        }

        public MotTelefonicosVo(TmotTelefonicos item)
        {
           MotNcodigo =item.MotNcodigo;
           AudCusuario = item.AudCusuario;
           AudCestado = item.AudCestado;
           AudFfecha = item.AudFfecha;
           MotNmaster = item.MotNmaster;
           MotCdescripcion = item.MotCdescripcion;
           MotCagendamiento = item.MotCagendamiento;
        }
    }


    public class MotTelefonicosFactory : FactoryVoBase
    {
        public static List<MotTelefonicosVo> FromList(IList<TmotTelefonicos> items)
        {
            var lista = new List<MotTelefonicosVo>();
            foreach (var item in items)
            {
                lista.Add(new MotTelefonicosVo(item));
            }
            return lista;
        }

        public static MotTelefonicosVo ToVo(TmotTelefonicos item)
        {
            var elemento = new MotTelefonicosVo();
            CopyProperties(item, elemento);
            return elemento;
        }

        public static TmotTelefonicos ToDao(MotTelefonicosVo item)
        {
            var elemento = new TmotTelefonicos();
            CopyProperties(item, elemento);
            return elemento;
        }
    }


}
