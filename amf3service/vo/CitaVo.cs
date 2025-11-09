using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class CitaVo
    {
        public CitaVo() 
        {            
            PestCita = new EstadoCitaVo();
            PtipoCita = new TipoCitaVo();
            RcargueDireccion = new CargueDireccionVo();
            RcargueTelefono = new CargueTelefonoVo();
            Pjornada = new JornadaVo();
        }

        public double CitNcodigo { get; set; }
        public double CarNcodigo { get; set; }
        public EstadoCitaVo PestCita { get; set; }
        public TipoCitaVo PtipoCita { get; set; }
        public CargueDireccionVo RcargueDireccion { get; set; }
        public CargueTelefonoVo RcargueTelefono { get; set; }
        public JornadaVo Pjornada { get; set; }
        public string AudCusuario { get; set; }
        public DateTime AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public DateTime CitFfecha { get; set; }
        public string CitCobservacion { get; set; }
        public DateTime CitFfechaCancela { get; set; }
        public string UsuCusuarioCancela { get; set; }
        public DateTime CitFfechaCrea { get; set; }
        public string CitCusuCrea { get; set; }
    }

    public class CitaFactory : FactoryVoBase
    {

        public static List<CitaVo> FromList(IList<Tcita> items)
        {
            var lista = new List<CitaVo>();
            foreach (Tcita item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static CitaVo ToVo(Tcita item)
        {
            var elemento = new CitaVo()
                {
                    CitNcodigo = item.CitNcodigo,
                    CarNcodigo = item.CarNcodigo,
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    CitFfecha = item.CitFfecha,
                    CitCobservacion = item.CitCobservacion,
                    CitFfechaCancela = item.CitFfechaCancela,
                    UsuCusuarioCancela = item.UsuCusuarioCancela,
                    CitFfechaCrea = item.CitFfechaCrea,
                    CitCusuCrea = item.CitCusuCrea
                };                        
            elemento.PestCita = EstadoCitaFactory.ToVo(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToVo(item.Pjornada);
            elemento.PtipoCita = TipoCitaFactory.ToVo(item.PtipoCita);
            elemento.RcargueDireccion = CargueDireccionFactory.ToVo(item.RcargueDireccion);
            elemento.RcargueTelefono = CargueTelefonoFactory.ToVo(item.RcargueTelefono);
            return elemento;
        }


        public static Tcita ToDao(CitaVo item)
        {
            var elemento = new Tcita()
            {
                CitNcodigo = item.CitNcodigo,
                CarNcodigo = item.CarNcodigo,
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                CitFfecha = item.CitFfecha,
                CitCobservacion = item.CitCobservacion,
                CitFfechaCancela = item.CitFfechaCancela,
                UsuCusuarioCancela = item.UsuCusuarioCancela,
                CitFfechaCrea = item.CitFfechaCrea,
                CitCusuCrea = item.CitCusuCrea
            };
            elemento.PestCita = EstadoCitaFactory.ToDao(item.PestCita);
            elemento.Pjornada = JornadaFactory.ToDao(item.Pjornada);
            elemento.PtipoCita = TipoCitaFactory.ToDao(item.PtipoCita);
            elemento.RcargueDireccion = CargueDireccionFactory.ToDao(item.RcargueDireccion);
            elemento.RcargueTelefono = CargueTelefonoFactory.ToDao(item.RcargueTelefono);
            return elemento;
        }

        public static IList<CitaVo> ListtoList(IList<Tcita> tcitas)
        {
            var items = new List<CitaVo>();
            foreach (Tcita tcita in tcitas)
            {
                items.Add(ToVo(tcita));
            }
            return items;
        }
    }

}
