using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class ProductoVo 
    {

        private CargueVo _tcargue;
        private EstadoGestionVo _testadoGestion;
        private TrackingVo _ttracking;

        public  double ProNcodigo { get; set; }
        public CargueVo Tcargue
        {
            get { return _tcargue ?? (_tcargue = new CargueVo()); }
            set
            {
                _tcargue = value;                
            }
        }

        public EstadoGestionVo TestadoGestion
        {
            get { return _testadoGestion ?? (_testadoGestion = new EstadoGestionVo()); }
            set
            {
                _testadoGestion = value;
            }
        }

        public TrackingVo Ttracking
        {
            get { return _ttracking ?? (_ttracking = new TrackingVo()); }
            set
            {
                _ttracking = value;
            }
        }
        public  string AudCusuario { get; set; }
        public  DateTime AudFfecha { get; set; }
        public  string AudCestado { get; set; }
        public  double? CitNcodigo { get; set; }
        public  string ProCdescuelgue { get; set; }
        public  string ProCguia { get; set; }
        public  SedeVo TsedeActual { get; set; }
        public  CiudadVo  PciudadEntrega { get; set; }

    }


    public class ProductoFactory : FactoryVoBase
    {
        public static IList<ProductoVo> FromList(IList<Tproducto> items)
        {
            var productos = new List<ProductoVo>();
            foreach (Tproducto item in items)
            {
                var producto = ToVo(item);
                productos.Add(producto);
            }
            return productos;
        }

        public static ProductoVo ToVo(Tproducto item)
        {
            var producto = new ProductoVo
                {
                    ProNcodigo = item.ProNcodigo,
                    Tcargue = CargueFactory.ToVo(item.Tcargue),
                    TestadoGestion = EstadoGestionFactory.ToVo(item.TestadoGestion),
                    Ttracking = TrackingFactory.ToVo(item.Ttracking),
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    CitNcodigo = item.CitNcodigo,
                    ProCdescuelgue = item.ProCdescuelgue,
                    ProCguia = item.ProCguia,
                    TsedeActual = SedeFactory.ToVo(item.TsedeActual), //item.SedNactual,
                    PciudadEntrega = CiudadFactory.ToVo(item.PciudadEntrega)
                };
            return producto;
        }

        public static Tproducto ToDao(ProductoVo item)
        {
            var producto = new Tproducto
            {
                ProNcodigo = item.ProNcodigo,
                //Tcargue = CargueFactory.To(item.Tcargue),
                //TestadoGestion = EstadoGestionFactory.ToDao(item.TestadoGestion),
                //Ttracking = TrackingFactory.ToDao(item.Ttracking),
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CitNcodigo = item.CitNcodigo,
                ProCdescuelgue = item.ProCdescuelgue,
                ProCguia = item.ProCguia,
                TsedeActual = SedeFactory.ToDao(item.TsedeActual),
                PciudadEntrega = CiudadFactory.ToDao(item.PciudadEntrega)
            };
            return producto;
        }

    }

}
