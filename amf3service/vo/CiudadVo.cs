using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class CiudadVo
    {
        public CiudadVo()
        {
            Pdepartamento = new DepartamentoVo();
        }

        public double CiuNcodigo { get; set; }
        public DepartamentoVo Pdepartamento { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public DateTime AudFfecha { get; set; }
        public string CiuCnombre { get; set; }
        public string CiuCsigla { get; set; }
        public string CiuCdane { get; set; }
        public double? CiuNcentro { get; set; }
    }


    public class CiudadFactory : FactoryVoBase
    {

        public static List<CiudadVo> FromList(IList<Pciudad> items)
        {
            var lista = new List<CiudadVo>();
            foreach (Pciudad item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CiudadVo ToVo(Pciudad item)
        {
            var elemento = new CiudadVo()
                {

                    CiuNcodigo = item.CiuNcodigo,
                    Pdepartamento = DepartamentoFactory.ToVo(item.Pdepartamento),
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    CiuCnombre = item.CiuCnombre,
                    CiuCsigla = item.CiuCsigla,
                    CiuCdane = item.CiuCdane,
                    CiuNcentro = item.CiuNcodigo
                };                        
            return elemento;
        }

        public static Pciudad ToDao(CiudadVo item)
        {
            var elemento = new Pciudad()
            {
                CiuNcodigo = item.CiuNcodigo,
                Pdepartamento = DepartamentoFactory.ToDao(item.Pdepartamento),
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                CiuCnombre = item.CiuCnombre,
                CiuCsigla = item.CiuCsigla,
                CiuCdane = item.CiuCdane,
                CiuNcentro = item.CiuNcodigo
            };
            return elemento;
        }
    }
}
