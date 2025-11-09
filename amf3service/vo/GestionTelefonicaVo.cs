using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.Vo;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class GestionTelefonicaVo
    {
        public double GteNcodigo { get; set; }
        public double CarNcodigo { get; set; }
        public CargueTelefonoVo RcargueTelefono { get; set; }        
        public MotTelefonicosVo TmotTelefonicos { get; set; }                
        public string AudCusuario { get; set; }
        public DateTime AudFfecha { get; set; }
        public string AudCestado { get; set; }
        public DateTime GteFfechaInicial { get; set; }
        public DateTime GteFfechaFinal { get; set; }
        public string GteCobservacion { get; set; }
        public double? CitNcodigo { get; set; }

        public GestionTelefonicaVo()
        {
            RcargueTelefono = new CargueTelefonoVo();
            TmotTelefonicos = new MotTelefonicosVo();
        }

    }



    public class GestionTelefonicaFactory : FactoryVoBase
    {
        public static IList<GestionTelefonicaVo> FromList(IList<TgestionTelefonica> items)
        {
            var lista = new List<GestionTelefonicaVo>();
            foreach (var item in items)
            {
                lista.Add(ToVo(item));
            }
            return lista;
        }

        public static GestionTelefonicaVo ToVo(TgestionTelefonica item)
        {
            var elemento = new GestionTelefonicaVo()
                {
                    GteNcodigo = item.GteNcodigo,
                    CarNcodigo = item.CarNcodigo,
                    RcargueTelefono = CargueTelefonoFactory.ToVo(item.RcargueTelefono),
                    TmotTelefonicos = MotTelefonicosFactory.ToVo(item.TmotTelefonicos),
                    AudCusuario = item.AudCusuario,
                    AudFfecha = item.AudFfecha,
                    AudCestado = item.AudCestado,
                    GteFfechaInicial = item.GteFfechaInicial,
                    GteFfechaFinal = item.GteFfechaFinal,
                    GteCobservacion = item.GteCobservacion,
                    CitNcodigo = item.CitNcodigo
                };
            return elemento;
        }

        public static TgestionTelefonica ToDao(GestionTelefonicaVo item)
        {
            var elemento = new TgestionTelefonica()
            {
                GteNcodigo = item.GteNcodigo,
                CarNcodigo = item.CarNcodigo,
                RcargueTelefono = CargueTelefonoFactory.ToDao(item.RcargueTelefono),
                TmotTelefonicos = MotTelefonicosFactory.ToDao(item.TmotTelefonicos),
                AudCusuario = item.AudCusuario,
                AudFfecha = item.AudFfecha,
                AudCestado = item.AudCestado,
                GteFfechaInicial = item.GteFfechaInicial,
                GteFfechaFinal = item.GteFfechaFinal,
                GteCobservacion = item.GteCobservacion,
                CitNcodigo = item.CitNcodigo
            };
            return elemento;
        }
    }
}
