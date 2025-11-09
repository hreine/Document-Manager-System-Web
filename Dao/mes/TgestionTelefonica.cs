using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    

    public class TgestionTelefonica {
        
        private RcargueTelefono _rcargueTelefono;
        private TmotTelefonicos _tmotTelefonicos;
        public virtual double GteNcodigo { get; set; }
        public virtual double CarNcodigo { get; set; }
        
        public virtual RcargueTelefono RcargueTelefono
        {
            get { return _rcargueTelefono ?? (_rcargueTelefono= new RcargueTelefono()); } 
            set { _rcargueTelefono = value; }
        }

        public virtual TmotTelefonicos TmotTelefonicos
        {
            get { return _tmotTelefonicos ?? (_tmotTelefonicos= new TmotTelefonicos());} 
            set { _tmotTelefonicos = value; }
        }

        public virtual string AudCusuario { get; set;}
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime GteFfechaInicial { get; set; }
        public virtual DateTime GteFfechaFinal { get; set; }
        public virtual string GteCobservacion { get; set;}
        public virtual double? CitNcodigo { get; set; }
    }
}
