using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class CargueVo
    {
        public CargueVo()
        {
            Torden = new OrdenVo();
            RcargueDirecciones = new List<CargueDireccionVo>();
            RcargueTelefonos = new List<CargueTelefonoVo>();
            RcargueGestiones = new List<CargueGestionVo>();
            RcargueDocumentos = new List<CargueDocumentoVo>();
            TgestionesTelefonicas = new List<GestionTelefonicaVo>();
            RcargueMedios = new List<CargueMedioVo>();
            Tcitas = new List<CitaVo>();            
        }

        public double CarNcodigo { get; set; }
        public OrdenVo Torden { get; set; }
        public string AudCusuario { get; set; }
        public string AudCestado { get; set; }
        public DateTime AudFfecha { get; set; }
        public double CarNconsecutivo { get; set; }
        public DateTime CarFenvio { get; set; }
        public string CarCidentificacion { get; set; }
        public double? ParNtipoid { get; set; }
        public string CarCnombre1 { get; set; }
        public string CarCnombre2 { get; set; }
        public string CarCapellido1 { get; set; }
        public string CarCapellido2 { get; set; }
        public string CarCnombre { get; set; }
        public string CarCtelefono1 { get; set; }
        public string CarCtelefono2 { get; set; }
        public string CarCtelefono3 { get; set; }
        public string CarCtelefono4 { get; set; }
        public string CarCtelefono5 { get; set; }
        public string CarCtelefono6 { get; set; }
        public string CarCtelefono7 { get; set; }
        public string CarCtelefono8 { get; set; }
        public string CarCtelefono9 { get; set; }
        public string CarCtelefono10 { get; set; }
        public string CarCdireccion1 { get; set; }
        public string CarCdireccion2 { get; set; }
        public string CarCdireccion3 { get; set; }
        public string CarCdireccion4 { get; set; }
        public string CarCdireccion5 { get; set; }
        public string CarCdireccion6 { get; set; }
        public string CarCdireccion7 { get; set; }
        public string CarCdireccion8 { get; set; }
        public string CarCdireccion9 { get; set; }
        public string CarCdireccion10 { get; set; }
        public double? CarCciudad1 { get; set; }
        public double? CarCciudad2 { get; set; }
        public double? CarCciudad3 { get; set; }
        public double? CarCciudad4 { get; set; }
        public double? CarCciudad5 { get; set; }
        public double? CarCciudad6 { get; set; }
        public double? CarCciudad7 { get; set; }
        public double? CarCciudad8 { get; set; }
        public double? CarCciudad9 { get; set; }
        public double? CarCciudad10 { get; set; }
        public string CarCnomCiudad1 { get; set; }
        public string CarCnomCiudad2 { get; set; }
        public string CarCnomCiudad3 { get; set; }
        public string CarCnomCiudad4 { get; set; }
        public string CarCnomCiudad5 { get; set; }
        public string CarCnomCiudad6 { get; set; }
        public string CarCnomCiudad7 { get; set; }
        public string CarCnomCiudad8 { get; set; }
        public string CarCnomCiudad9 { get; set; }
        public string CarCnomCiudad10 { get; set; }
        public string CarCcodSucursal { get; set; }
        public string CarCnomSucursal { get; set; }
        public string CarCestado { get; set; }
        public string UsuCasociacion { get; set; }
        public DateTime? CarFasociacion { get; set; }
        public string CarCasociacion { get; set; }
        public double? CiuNcodigo { get; set; }
        public string CarCtelext1 { get; set; }
        public string CarCtelext2 { get; set; }
        public string CarCtelext3 { get; set; }
        public string CarCtelext4 { get; set; }
        public string CarCtelext5 { get; set; }
        public string CarCtelext6 { get; set; }
        public string CarCtelext7 { get; set; }
        public string CarCtelext8 { get; set; }
        public string CarCtelext9 { get; set; }
        public string CarCtelext10 { get; set; }
        public string CarCperfilDoc { get; set; }
        public string CarCemision { get; set; }
        /* Listas */
        public IList<CargueDocumentoVo> RcargueDocumentos;
        public IList<CargueDireccionVo> RcargueDirecciones;
        public IList<CargueTelefonoVo> RcargueTelefonos;
        public IList<CargueGestionVo> RcargueGestiones;
        public IList<GestionTelefonicaVo> TgestionesTelefonicas;
        public IList<CargueMedioVo> RcargueMedios;
        public IList<CitaVo> Tcitas;
    }

    public class CargueFactory : FactoryVoBase
    {
        public static List<CargueVo> FromList(List<Tcargue> items)
        {
            var registros = new List<CargueVo>();
            foreach (Tcargue item in items)
            {
                var registro = ToVo(item);
                registros.Add(registro);
            }
            return registros;
        }

        public static CargueVo ToVo(Tcargue item)
        {
            var registro = new CargueVo
                {
                    CarNcodigo = item.CarNcodigo,
                    Torden = OrdenFactory.ToVo(item.Torden),
                    AudCusuario = item.AudCusuario,
                    AudCestado = item.AudCestado,
                    AudFfecha = item.AudFfecha,
                    CarNconsecutivo = item.CarNconsecutivo,
                    CarFenvio = item.CarFenvio,
                    CarCidentificacion = item.CarCidentificacion,
                    ParNtipoid = item.ParNtipoid,
                    CarCnombre1 = item.CarCnombre1,
                    CarCnombre2 = item.CarCnombre2,
                    CarCapellido1 = item.CarCapellido1,
                    CarCapellido2 = item.CarCapellido2,
                    CarCnombre = item.CarCnombre,
                    CarCtelefono1 = item.CarCtelefono1,
                    CarCtelefono2 = item.CarCtelefono2,
                    CarCtelefono3 = item.CarCtelefono3,
                    CarCtelefono4 = item.CarCtelefono4,
                    CarCtelefono5 = item.CarCtelefono5,
                    CarCtelefono6 = item.CarCtelefono6,
                    CarCtelefono7 = item.CarCtelefono7,
                    CarCtelefono8 = item.CarCtelefono8,
                    CarCtelefono9 = item.CarCtelefono9,
                    CarCtelefono10 = item.CarCtelefono10,
                    CarCdireccion1 = item.CarCdireccion1,
                    CarCdireccion2 = item.CarCdireccion2,
                    CarCdireccion3 = item.CarCdireccion3,
                    CarCdireccion4 = item.CarCdireccion4,
                    CarCdireccion5 = item.CarCdireccion5,
                    CarCdireccion6 = item.CarCdireccion6,
                    CarCdireccion7 = item.CarCdireccion7,
                    CarCdireccion8 = item.CarCdireccion8,
                    CarCdireccion9 = item.CarCdireccion9,
                    CarCdireccion10 = item.CarCdireccion10,
                    CarCciudad1 = item.CarCciudad1,
                    CarCciudad2 = item.CarCciudad2,
                    CarCciudad3 = item.CarCciudad3,
                    CarCciudad4 = item.CarCciudad4,
                    CarCciudad5 = item.CarCciudad5,
                    CarCciudad6 = item.CarCciudad6,
                    CarCciudad7 = item.CarCciudad7,
                    CarCciudad8 = item.CarCciudad8,
                    CarCciudad9 = item.CarCciudad9,
                    CarCciudad10 = item.CarCciudad10,
                    CarCnomCiudad1 = item.CarCnomCiudad1,
                    CarCnomCiudad2 = item.CarCnomCiudad2,
                    CarCnomCiudad3 = item.CarCnomCiudad3,
                    CarCnomCiudad4 = item.CarCnomCiudad4,
                    CarCnomCiudad5 = item.CarCnomCiudad5,
                    CarCnomCiudad6 = item.CarCnomCiudad6,
                    CarCnomCiudad7 = item.CarCnomCiudad7,
                    CarCnomCiudad8 = item.CarCnomCiudad8,
                    CarCnomCiudad9 = item.CarCnomCiudad9,
                    CarCnomCiudad10 = item.CarCnomCiudad10,
                    CarCcodSucursal = item.CarCcodSucursal,
                    CarCnomSucursal = item.CarCnomSucursal,
                    CarCestado = item.CarCestado,
                    UsuCasociacion = item.UsuCasociacion,
                    CarFasociacion = item.CarFasociacion,
                    CarCasociacion = item.CarCasociacion,
                    CiuNcodigo = item.CiuNcodigo,
                    CarCtelext1 = item.CarCtelext1,
                    CarCtelext2 = item.CarCtelext2,
                    CarCtelext3 = item.CarCtelext3,
                    CarCtelext4 = item.CarCtelext4,
                    CarCtelext5 = item.CarCtelext5,
                    CarCtelext6 = item.CarCtelext6,
                    CarCtelext7 = item.CarCtelext7,
                    CarCtelext8 = item.CarCtelext8,
                    CarCtelext9 = item.CarCtelext9,
                    CarCtelext10 = item.CarCtelext10,
                    CarCperfilDoc = item.CarCperfilDoc,
                    CarCemision = item.CarCemision,
                    RcargueDirecciones = CargueDireccionFactory.ListtoList(item.RcargueDirecciones),
                    RcargueTelefonos = CargueTelefonoFactory.ListtoList(item.RcargueTelefonos),
                    RcargueGestiones = CargueGestionFactory.ListtoList(item.RcargueGestiones),
                    RcargueDocumentos = CargueDocumentoFactory.ListtoList(item.RcargueDocumentos),
                    TgestionesTelefonicas = GestionTelefonicaFactory.FromList(item.TgestionesTelefonicas),
                    RcargueMedios = CargueMedioFactory.FromList(item.RcargueMedios),
                    Tcitas = CitaFactory.ListtoList(item.Tcitas)    
                };            
            return registro;
        }

    }
}
