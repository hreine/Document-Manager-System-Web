using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;


namespace Reines.dmsflex.amf3service.vo
{
    public class NegocioVo
    {
        public double NegNcodigo { get; set; }
        public ClienteVo Tcliente { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public string AudFfecha { get; set; }
        public string NegCnombre { get; set; }
    }


    public class NegocioFactory : FactoryVoBase
    {
        public static List<NegocioVo> FromList(IList<Tnegocio> items)
        {
            var lista = new List<NegocioVo>();
            foreach (var item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static NegocioVo ToVo(Tnegocio item)
        {
            var elemento = new NegocioVo()
                {
                    NegNcodigo = item.NegNcodigo,
                    Tcliente = ClienteFactory.ToVo(item.Tcliente),
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    NegCnombre = item.NegCnombre
                };            
            return elemento;
        }

        public static Tnegocio ToDao(NegocioVo item)
        {
            var elemento = new Tnegocio()
            {
                NegNcodigo = item.NegNcodigo,
                Tcliente = ClienteFactory.ToDao(item.Tcliente),
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                NegCnombre = item.NegCnombre
            };
            return elemento;
        }
    }


}
