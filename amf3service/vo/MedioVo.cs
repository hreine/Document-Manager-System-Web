using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class MedioVo
    {
        public double MedNcodigo { get; set; }
        //public NegocioVo Tnegocio { get; set; }
        public string AudCusuario { get; set; }
        public DateTime AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public string MedCnombre { get; set; }
        public string MedCvalhomologa { get; set; }
        public string MedCasignacion { get; set; }
        public double? MedNmaster { get; set; }
        public string MedCregex { get; set; }
        public string MedCencript { get; set; }
        public string MedBpubkey { get; set; }
    }

    public class MedioFactory : FactoryVoBase
    {

        public static List<MedioVo> FromList(IList<Tmedio> items)
        {
            var lista = new List<MedioVo>();
            foreach (Tmedio item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static MedioVo ToVo(Tmedio item)
        {
            var elemento = new MedioVo()
            {
                MedNcodigo = item.MedNcodigo,                
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                MedCnombre = item.MedCnombre,
                MedCvalhomologa = item.MedCvalhomologa,
                MedCasignacion = item.MedCasignacion,
                MedNmaster = item.MedNmaster,
                MedCregex = item.MedCregex,
                MedCencript = item.MedCencript,
                MedBpubkey = item.MedBpubkey
            };
            return elemento;
        }

        public static Tmedio ToDao(MedioVo item)
        {
            var elemento = new Tmedio()
            {
                MedNcodigo = item.MedNcodigo,
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                MedCnombre = item.MedCnombre,
                MedCvalhomologa = item.MedCvalhomologa,
                MedCasignacion = item.MedCasignacion,
                MedNmaster = item.MedNmaster,
                MedCregex = item.MedCregex,
                MedCencript = item.MedCencript,
                MedBpubkey = item.MedBpubkey
            };
            return elemento;
        }
    }

}
