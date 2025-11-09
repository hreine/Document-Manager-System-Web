using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class DocumentoVo
    {
        public double DocNcodigo { get; set; }
        public string AudCusuario { get; set; }
        public string AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public string DocCnombre { get; set; }
        public string DocCvalhomologa { get; set; }
        public string DocCobservacion { get; set; }
        public int? DocNpaginas { get; set; }
        public string DocCtipo { get; set; }
        public bool DocBvisenctr { get; set; }
        public int? DocNorden { get; set; }
        public double? MedNcodigo { get; set; }
    }


    public class DocumentosFactory : FactoryVoBase
    {

        public static List<DocumentoVo> FromList(IList<Tdocumento> items)
        {
            var lista = new List<DocumentoVo>();
            foreach (Tdocumento item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static DocumentoVo ToVo(Tdocumento item)
        {
            var elemento = new DocumentoVo();
            CopyProperties(item, elemento);
            return elemento;
        }

        public static Tdocumento ToDao(DocumentoVo item)
        {
            var elemento = new Tdocumento();
            CopyProperties(item, elemento);
            return elemento;
        }
    }

}
