using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class TestadoGestion {
        public TestadoGestion() {			
        }
        public virtual string EgCcodigo { get; set; }
        public virtual string EgCdescripcion { get; set; }
        public virtual string EgCagendamiento { get; set; }
        public virtual string EgCnotas { get; set; }
        public virtual string EgCcitasxcargue { get; set; }
        public virtual string EgCremision { get; set; }
        public virtual string EgCcorrecdatos { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string EgCcodmaster { get; set; }        
    }
}
