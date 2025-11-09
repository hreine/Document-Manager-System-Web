using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class DepartamentoVo
    {
        public double DepNcodigo { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public string AudFfecha { get; set; }
        public string DepCnombre { get; set; }
        public string DepCcodigoDane { get; set; }
    }

    public class DepartamentoFactory : FactoryVoBase
    {

        public static List<DepartamentoVo> FromList(IList<Pdepartamento> items)
        {
            var lista = new List<DepartamentoVo>();
            foreach (Pdepartamento item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static DepartamentoVo ToVo(Pdepartamento item)
        {
            var elemento = new DepartamentoVo();
            CopyProperties(item, elemento);            
            return elemento;
        }

        public static Pdepartamento ToDao(DepartamentoVo item)
        {
            var elemento = new Pdepartamento();
            CopyProperties(item, elemento);
            return elemento;
        }
    }


}
