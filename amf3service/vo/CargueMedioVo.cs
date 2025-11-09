using System.Collections.Generic;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class CargueMedioVo
    {
        public double RcmNcodigo { get; set; }
        public string AudCusuario { get; set; }
        public string AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public double CarNcodigo { get; set; }
        public MedioVo Tmedio { get; set; }
        public string RcmCasociacion { get; set; }
        public string RcmCestado { get; set; }
        public string RcmScrach { get; set; }
        public double CarNcodigoOrigen { get; set; }
        public double? RcmNmaster { get; set; }
        public double? CrdNcodigo { get; set; }
        public string RcmBasociacion { get; set; }
    }


    public class CargueMedioFactory : FactoryVoBase
    {
        public static List<CargueMedioVo> FromList(IList<RcargueMedio> items)
        {
            var lista = new List<CargueMedioVo>();
            foreach (RcargueMedio item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CargueMedioVo ToVo(RcargueMedio item)
        {
            var elemento = new CargueMedioVo()
            {
                RcmNcodigo = item.RcmNcodigo,                
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                CarNcodigo = item.CarNcodigo,
                Tmedio = MedioFactory.ToVo(item.Tmedio),
                RcmCasociacion = item.RcmCasociacion,
                RcmCestado = item.RcmCestado,
                RcmScrach = item.RcmScrach,
                CarNcodigoOrigen = item.CarNcodigoOrigen,
                RcmNmaster = item.RcmNmaster,
                CrdNcodigo = item.CrdNcodigo,
                RcmBasociacion = item.RcmBasociacion
            };
            return elemento;
        }

        public static RcargueMedio ToDao(CargueMedioVo item)
        {
            var elemento = new RcargueMedio()
            {
                RcmNcodigo = item.RcmNcodigo,
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                CarNcodigo = item.CarNcodigo,
                Tmedio = MedioFactory.ToDao(item.Tmedio),
                RcmCasociacion = item.RcmCasociacion,
                RcmCestado = item.RcmCestado,
                RcmScrach = item.RcmScrach,
                CarNcodigoOrigen = item.CarNcodigoOrigen,
                RcmNmaster = item.RcmNmaster,
                CrdNcodigo = item.CrdNcodigo,
                RcmBasociacion = item.RcmBasociacion
            };
            return elemento;
        }
    }

}
