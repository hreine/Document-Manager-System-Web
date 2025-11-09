using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class CargueTelefonoVo
    {

        public CargueTelefonoVo()
        {
            Pciudad = new CiudadVo();
        }

        public double RctNcodigo { get; set; }
        public CiudadVo Pciudad { get; set; }
        public string AudCusuario { get; set; }
        public DateTime AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public double CarNcodigo { get; set; }
        public string RctCtelefono { get; set; }
        public string RctCextension { get; set; }
        public double? RctNtipotel { get; set; }
        public double? RctNcountGestion { get; set; }
        public double? RctNcountVirtualgestion { get; set; }
        public double? RctNcontactos { get; set; }
        public string RctCestado { get; set; }
    }

    public class CargueTelefonoFactory : FactoryVoBase
    {

        public static List<CargueTelefonoVo> FromList(IList<RcargueTelefono> items)
        {
            var lista = new List<CargueTelefonoVo>();
            foreach (RcargueTelefono item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CargueTelefonoVo ToVo(RcargueTelefono item)
        {
            var elemento = new CargueTelefonoVo()
                {
                    RctNcodigo = item.RctNcodigo,
                    Pciudad = CiudadFactory.ToVo(item.Pciudad),
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    CarNcodigo = item.CarNcodigo,
                    RctCtelefono = item.RctCtelefono,
                    RctCextension = item.RctCextension,
                    RctNtipotel = item.RctNtipotel,
                    RctNcountGestion = item.RctNcountGestion,
                    RctNcountVirtualgestion = item.RctNcountVirtualgestion,
                    RctNcontactos = item.RctNcontactos,
                    RctCestado = item.RctCestado
                };            
            return elemento;
        }

        public static IList<CargueTelefonoVo> ListtoList(IList<RcargueTelefono> rcargueTelefonos)
        {
            var items = new List<CargueTelefonoVo>();
            foreach (RcargueTelefono rcargueTelefono in rcargueTelefonos)
            {
                items.Add(ToVo(rcargueTelefono));
            }
            return items;
        }

        public static RcargueTelefono ToDao(CargueTelefonoVo item)
        {
            var elemento = new RcargueTelefono()
            {
                RctNcodigo = item.RctNcodigo,
                Pciudad = CiudadFactory.ToDao(item.Pciudad),
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CarNcodigo = item.CarNcodigo,
                RctCtelefono = item.RctCtelefono,
                RctCextension = item.RctCextension,
                RctNtipotel = item.RctNtipotel,
                RctNcountGestion = item.RctNcountGestion,
                RctNcountVirtualgestion = item.RctNcountVirtualgestion,
                RctNcontactos = item.RctNcontactos,
                RctCestado = item.RctCestado
            };
            return elemento;
        }
    }

}
