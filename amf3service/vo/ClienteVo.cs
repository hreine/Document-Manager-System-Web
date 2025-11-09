using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class ClienteVo
    {
        public double CliNcodigo { get; set; }
        public CiudadVo Pciudad { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public  DateTime AudFfecha { get; set; }
        public string CliCrazonSocial { get; set; }
        public double CliCidentificacion { get; set; }
        public double CliNdigitoVerificacion { get; set; }
        public string CliCsigla { get; set; }
        public string CliCdireccion { get; set; }
        public double CliCtelefono { get; set; }
        public string CliCsecuencia { get; set; }
    }


    public class ClienteFactory : FactoryVoBase
    {
        public static List<ClienteVo> FromList(IList<Tcliente> items)
        {
            var lista = new List<ClienteVo>();
            foreach (var item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static ClienteVo ToVo(Tcliente item)
        {
            var elemento = new ClienteVo()
                {
                    CliNcodigo = item.CliNcodigo,
                    Pciudad = CiudadFactory.ToVo(item.Pciudad),
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    CliCrazonSocial = item.CliCrazonSocial,
                    CliCidentificacion = item.CliCidentificacion,
                    CliNdigitoVerificacion = item.CliNdigitoVerificacion,
                    CliCsigla = item.CliCsigla,
                    CliCdireccion = item.CliCdireccion,
                    CliCtelefono = item.CliNcodigo,
                    CliCsecuencia = item.CliCsecuencia
                };            
            return elemento;
        }

        public static Tcliente ToDao(ClienteVo item)
        {
            var elemento = new Tcliente()
            {
                CliNcodigo = item.CliNcodigo,
                Pciudad = CiudadFactory.ToDao(item.Pciudad),
                AudCusuario = item.AudCusuario,
                AudCestado = item.AudCestado,
                AudFfecha = item.AudFfecha,
                CliCrazonSocial = item.CliCrazonSocial,
                CliCidentificacion = item.CliCidentificacion,
                CliNdigitoVerificacion = item.CliNdigitoVerificacion,
                CliCsigla = item.CliCsigla,
                CliCdireccion = item.CliCdireccion,
                CliCtelefono = item.CliNcodigo,
                CliCsecuencia = item.CliCsecuencia
            };
            return elemento;
        }
    }

}
