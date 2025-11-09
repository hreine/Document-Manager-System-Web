using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Ttracking {
        public Ttracking() {			
        }
        public virtual double TrkNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string TrkCdescripcion { get; set; }
        public virtual string TrkCfinal { get; set; }
        public virtual string TrkCaccion { get; set; }        
    }
}
