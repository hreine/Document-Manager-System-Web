using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;
using Reines.dmsflex.amf3service.vo;

namespace Reines.dmsflex.amf3service.vo
{
    public class OrdenVo
    {
        public double OrdNcodigo { get; set; }       
        public  NegocioVo Tnegocio { get; set;}
        public  SedeVo Tsede { get; set; }        
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public DateTime AudFfecha { get; set; }
        public string OrdCarchivo { get; set; }
    }


    public class OrdenFactory : FactoryVoBase
    {
        public static List<OrdenVo> FromList(List<Torden> items)
        {
            var lista = new List<OrdenVo>();
            foreach (Torden item in items)
            {
                var estado = ToVo(item);
                lista.Add(estado);
            }
            return lista;
        }

        public static OrdenVo ToVo(Torden item)
        {
            var elemento = new OrdenVo
                {
                    OrdNcodigo = item.OrdNcodigo,                    
                    Tnegocio = NegocioFactory.ToVo(item.Tnegocio),
                    Tsede = new SedeVo(item.Tsede),
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    OrdCarchivo = item.OrdCarchivo
                };
            return elemento;
        }

    }
}
