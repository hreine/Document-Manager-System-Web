using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class CargueDocumentoVo
    {
        public double CrdNcodigo { get; set; }       
        public DocumentoVo Tdocumento { get; set; }
        public  string AudCusuario { get; set; }
        public  DateTime AudFfecha { get; set; }
        public  string AudCestado { get; set; }
        public  string CrdCasociacion { get; set; }
        public  string CrdCestado { get; set; }
        public  string CrdCvista { get; set; }
        public  string CrdCreporte { get; set; }
        public  int? CrdNorden { get; set; }
        public  double? CarNcodigoOrigen { get; set; }
        public  string CrdCdescripcion { get; set; }
    }

    public class CargueDocumentoFactory : FactoryVoBase
    {

        public static List<CargueDocumentoVo> FromList(IList<RcargueDocumentos> items)
        {
            var lista = new List<CargueDocumentoVo>();
            foreach (RcargueDocumentos item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CargueDocumentoVo ToVo(RcargueDocumentos item)
        {
            var elemento = new CargueDocumentoVo()
                {
                    CrdNcodigo = item.CrdNcodigo,
                    Tdocumento= DocumentosFactory.ToVo(item.Tdocumento),
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    CrdCasociacion = item.CrdCasociacion,
                    CrdCestado = item.CrdCestado,
                    CrdCvista = item.CrdCvista,
                    CrdCreporte = item.CrdCreporte,
                    CrdNorden = item.CrdNorden,
                    CarNcodigoOrigen = item.CarNcodigoOrigen,
                    CrdCdescripcion = item.CrdCdescripcion
                };
            return elemento;
        }

        public static IList<CargueDocumentoVo> ListtoList(IList<RcargueDocumentos> rcargueDirecciones)
        {
            var items = new List<CargueDocumentoVo>();
            foreach (RcargueDocumentos rcargueDireccion in rcargueDirecciones)
            {
                items.Add(ToVo(rcargueDireccion));
            }
            return items;
        }

        public static RcargueDocumentos ToDao(CargueDocumentoVo item)
        {
            var elemento = new RcargueDocumentos()
                {
                    CrdNcodigo = item.CrdNcodigo,
                    Tdocumento = DocumentosFactory.ToDao(item.Tdocumento),
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    CrdCasociacion = item.CrdCasociacion,
                    CrdCestado = item.CrdCestado,
                    CrdCvista = item.CrdCvista,
                    CrdCreporte = item.CrdCreporte,
                    CrdNorden = item.CrdNorden,
                    CarNcodigoOrigen = item.CarNcodigoOrigen,
                    CrdCdescripcion = item.CrdCdescripcion
                };
            return elemento;
        }
    
    }

}
