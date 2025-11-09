using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class EstadoGestionVo
    {
        public string EgCcodigo { get; set; }
        public string EgCdescripcion { get; set; }
        public string EgCagendamiento { get; set; }
        public string EgCnotas { get; set; }
        public string EgCcitasxcargue { get; set; }
        public string EgCremision { get; set; }
        public string EgCcorrecdatos { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public DateTime AudFfecha { get; set; }
        public string EgCcodmaster { get; set; }
    }


    public class EstadoGestionFactory : FactoryVoBase
    {
        public static List<EstadoGestionVo> FromList(List<TestadoGestion> items)
        {
            var estados = new List<EstadoGestionVo>();
            foreach (TestadoGestion item in items)
            {
                var estado = ToVo(item);
                estados.Add(estado);
            }
            return estados;
        }

        public static EstadoGestionVo ToVo(TestadoGestion item)
        {
            var estado = new EstadoGestionVo
                {
                    EgCcodigo = item.EgCcodigo,
                    EgCdescripcion = item.EgCdescripcion,
                    EgCagendamiento = item.EgCagendamiento,
                    EgCnotas = item.EgCnotas,
                    EgCcitasxcargue = item.EgCcitasxcargue,
                    EgCremision = item.EgCremision,
                    EgCcorrecdatos = item.EgCcorrecdatos,
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    EgCcodmaster = item.EgCcodmaster
                };
            return estado;
        }
    }
}