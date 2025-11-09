using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tnegocio {
        //private Tcliente _tcliente;
        public Tnegocio() { }
        public virtual double NegNcodigo { get; set; }
        public virtual Tcliente Tcliente { get; set; }        
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string AudFfecha { get; set; }
        public virtual string NegCnombre { get; set; }
    }
}
