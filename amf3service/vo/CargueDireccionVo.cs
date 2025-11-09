using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class CargueDireccionVo 
    {
        public CargueDireccionVo() 
        {
            Pciudad = new CiudadVo();
        }

        public   double RcdNcodigo { get; set; }
        public   CiudadVo Pciudad { get; set; }
        public   string AudCusuario { get; set; }
        public   DateTime AudFfecha { get; set; }
        public   string AudCestado { get; set; }
        public   double CarNcodigo { get; set; }
        public   string RcdCdireccion { get; set; }
        public   string RcdCbarrio { get; set; }
    }


    public class CargueDireccionFactory : FactoryVoBase
    {

        public static List<CargueDireccionVo> FromList(IList<RcargueDireccion> items)
        {
            var lista = new List<CargueDireccionVo>();
            foreach (RcargueDireccion item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CargueDireccionVo ToVo(RcargueDireccion item)
        {
            var elemento = new CargueDireccionVo(){
            
             RcdNcodigo = item.RcdNcodigo,
             AudCusuario = item.AudCusuario,
             AudFfecha = item.AudFfecha,
             AudCestado = item.AudCestado,
             CarNcodigo = item.CarNcodigo,
             RcdCdireccion = item.RcdCdireccion,
             RcdCbarrio = item.RcdCbarrio,
             Pciudad = CiudadFactory.ToVo(item.Pciudad)};            
            return elemento;
        }

        public static IList<CargueDireccionVo> ListtoList(IList<RcargueDireccion> rcargueDirecciones)
        {
            var items = new List<CargueDireccionVo>();
            foreach (RcargueDireccion rcargueDireccion in rcargueDirecciones)
            {
                items.Add(ToVo(rcargueDireccion));
            }
            return items;
        }

        public static RcargueDireccion ToDao(CargueDireccionVo item)
        {
            var elemento = new RcargueDireccion()
            {
                RcdNcodigo = item.RcdNcodigo,
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CarNcodigo = item.CarNcodigo,
                RcdCdireccion = item.RcdCdireccion,
                RcdCbarrio = item.RcdCbarrio,
                Pciudad = CiudadFactory.ToDao(item.Pciudad)
            };
            return elemento;
        }
    }


}
