using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class SedeVo
    {
        public double SedNcodigo { get; set; }
        public DateTime? CreFfecha { get; set; }
        public double? SedNcodpadre { get; set; }
        public CiudadVo Pciudad;
        public string OfiCcodOficina { get; set; }
        public string SedCpiso { get; set; }
        public string AudCusuario { get; set; }
        public string SedCprincipal { get; set; }
        public double? CreNconsecutivo { get; set; }
        public ClienteVo Tcliente;
        public string SedCnombre { get; set; }
        public string SedCtelefono { get; set; }
        public string SedCdireccion { get; set; }
        public string SedCoficina { get; set; }
        public string AudCestado { get; set; }
        public string CreCusuario { get; set; }
        public DateTime AudFfecha { get; set; }

        public SedeVo(Tsede item)
        {
            SedNcodigo = item.SedNcodigo;
            CreFfecha = item.CreFfecha;
            SedNcodpadre = item.SedNcodpadre;
            Pciudad = CiudadFactory.ToVo(item.Pciudad);
            OfiCcodOficina = item.OfiCcodOficina;
            SedCpiso = item.SedCpiso;
            AudCusuario = item.AudCusuario;
            SedCprincipal = item.SedCprincipal;
            CreNconsecutivo = item.CreNconsecutivo;
            Tcliente = ClienteFactory.ToVo(item.Tcliente);
            SedCnombre = item.SedCnombre;
            SedCtelefono = item.SedCtelefono;
            SedCdireccion = item.SedCdireccion;
            SedCoficina = item.SedCoficina;
            AudCestado = item.AudCestado;
            CreCusuario = item.CreCusuario;
            AudFfecha = item.AudFfecha;
        }
    }

    public class SedeFactory : FactoryVoBase
    {
        public static List<SedeVo> FromList(IList<Tsede> items)
        {
            var lista = new List<SedeVo>();
            foreach (var item in items)
            {                
                lista.Add(new SedeVo(item));
            }
            return lista;
        }

        public static SedeVo ToVo(Tsede item)
        {
            var elemento = new SedeVo(item);
            return elemento;
        }

        public static Tsede ToDao(SedeVo item)
        {
            var elemento = new Tsede()
                {
                    SedNcodigo = item.SedNcodigo,
                    CreFfecha = item.CreFfecha,
                    SedNcodpadre = item.SedNcodpadre,
                    Pciudad = CiudadFactory.ToDao(item.Pciudad),
                    OfiCcodOficina = item.OfiCcodOficina,
                    SedCpiso = item.SedCpiso,
                    AudCusuario = item.AudCusuario,
                    SedCprincipal = item.SedCprincipal,
                    CreNconsecutivo = item.CreNconsecutivo,
                    Tcliente = ClienteFactory.ToDao(item.Tcliente),
                    SedCnombre = item.SedCnombre,
                    SedCtelefono = item.SedCtelefono,
                    SedCdireccion = item.SedCdireccion,
                    SedCoficina = item.SedCoficina,
                    AudCestado = item.AudCestado,
                    CreCusuario = item.CreCusuario,
                    AudFfecha = item.AudFfecha
                };
            return elemento;
        }
    }

}
