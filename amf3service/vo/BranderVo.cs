using System;
using System.Collections.Generic;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{

    public class BranderVo
    {
        public double BraNcodigo;
        public NegocioVo Tnegocio;
        public JornadaVo Pjornada;
        public EstadoCitaVo PestCita;
        public DateTime AudFfecha;
        public CiudadVo Pciudad;
        public string AudCestado;
        public string AudCusuario;
        public string BraCcedula;
        public string BraCnmbtit;
        public string BraCcelular;
        public string BraCtelefono;
        public string BraCdireccion;
        public DateTime BraFfecha;
        public string BraCobservacion;
        public string BraCactividadEconomica;
        public string BraCconvenio;
    }


    public class BranderFactory : FactoryVoBase
    {

        public static List<BranderVo> FromList(IList<Tbrander> items)
        {
            var lista = new List<BranderVo>();
            foreach (Tbrander item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static BranderVo ToVo(Tbrander item)
        {
            var elemento = new BranderVo()
            {
                BraNcodigo = item.BraNcodigo,
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                BraCcedula = item.BraCcedula,
                BraCnmbtit = item.BraCnmbtit,
                BraCtelefono = item.BraCtelefono,
                BraCcelular = item.BraCcelular,
                BraCdireccion = item.BraCdireccion,
                BraFfecha = item.BraFfecha,
                BraCobservacion = item.BraCobservacion,
                BraCactividadEconomica = item.BraCactividadEconomica,
                BraCconvenio = item.BraCconvenio
            };
            elemento.Pciudad = CiudadFactory.ToVo(item.Pciudad);
            elemento.PestCita = EstadoCitaFactory.ToVo(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToVo(item.Pjornada);
            elemento.Tnegocio = NegocioFactory.ToVo(item.Tnegocio);
            return elemento;
        }


        public static Tbrander ToDao(BranderVo item)
        {
            var elemento = new Tbrander()
            {
                BraNcodigo = item.BraNcodigo,
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                BraCcedula = item.BraCcedula,
                BraCnmbtit = item.BraCnmbtit,
                BraCtelefono = item.BraCtelefono,
                BraCcelular = item.BraCcelular,
                BraCdireccion = item.BraCdireccion,
                BraFfecha = item.BraFfecha,
                BraCobservacion = item.BraCobservacion,
                BraCactividadEconomica = item.BraCactividadEconomica,
                BraCconvenio = item.BraCconvenio
            };
            elemento.Pciudad = CiudadFactory.ToDao(item.Pciudad);
            elemento.PestCita = EstadoCitaFactory.ToDao(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToDao(item.Pjornada);
            elemento.Tnegocio = NegocioFactory.ToDao(item.Tnegocio);
            return elemento;
        }

        public static IList<BranderVo> ListtoList(IList<Tbrander> tcitas)
        {
            var items = new List<BranderVo>();
            foreach (Tbrander tcita in tcitas)
            {
                items.Add(ToVo(tcita));
            }
            return items;
        }
    }

}
