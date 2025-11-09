using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    
    public class CitaPreviaVo
    {
        public double CprNcodigo;
        public NegocioVo Tnegocio;
        public JornadaVo Pjornada;
        public EstadoCitaVo PestCita;
        public DateTime AudFfecha;
        public CiudadVo Pciudad;
        public string AudCestado;
        public string AudCusuario;
        public string CprCcedula;
        public string CprCnmbtit;
        public string CprCtelefono;
        public double CprNdireccion;        
        public DateTime CprFfecha;
        public string CprCobservacion;
    }

    public class CitaPreviaFactory : FactoryVoBase
    {

        public static List<CitaPreviaVo> FromList(IList<TcitaPrevia> items)
        {
            var lista = new List<CitaPreviaVo>();
            foreach (TcitaPrevia item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CitaPreviaVo ToVo(TcitaPrevia item)
        {
            var elemento = new CitaPreviaVo()
            {
                CprNcodigo = item.CprNcodigo,                
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CprCcedula = item.CprCcedula,
                CprCnmbtit = item.CprCnmbtit,
                CprCtelefono = item.CprCtelefono,
                CprNdireccion = item.CprNdireccion,                
                CprFfecha = item.CprFfecha,
                CprCobservacion = item.CprCobservacion
            };
            elemento.Pciudad = CiudadFactory.ToVo(item.Pciudad);
            elemento.PestCita = EstadoCitaFactory.ToVo(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToVo(item.Pjornada);
            elemento.Tnegocio = NegocioFactory.ToVo(item.Tnegocio);
            return elemento;
        }


        public static TcitaPrevia ToDao(CitaPreviaVo item)
        {
            var elemento = new TcitaPrevia()
            {
                CprNcodigo = item.CprNcodigo,
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CprCcedula = item.CprCcedula,
                CprCnmbtit = item.CprCnmbtit,
                CprCtelefono = item.CprCtelefono,
                CprNdireccion = item.CprNdireccion,
                CprFfecha = item.CprFfecha,
                CprCobservacion = item.CprCobservacion
            };
            elemento.Pciudad = CiudadFactory.ToDao(item.Pciudad);
            elemento.PestCita = EstadoCitaFactory.ToDao(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToDao(item.Pjornada);
            elemento.Tnegocio = NegocioFactory.ToDao(item.Tnegocio);
            return elemento;
        }

        public static IList<CitaPreviaVo> ListtoList(IList<TcitaPrevia> tcitas)
        {
            var items = new List<CitaPreviaVo>();
            foreach (TcitaPrevia tcita in tcitas)
            {
                items.Add(ToVo(tcita));
            }
            return items;
        }
    }


}
