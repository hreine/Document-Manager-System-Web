using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class TmotTelefonicos {
        public TmotTelefonicos() {
			
        }
        public virtual double MotNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual double MotNmaster { get; set; }
        public virtual string MotCdescripcion { get; set; }
        public virtual string MotCagendamiento { get; set; }        
    }
}
