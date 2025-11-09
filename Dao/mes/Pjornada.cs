using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Pjornada {
        public Pjornada() { }
        public virtual double JorNcodigo { get; set; }
        public virtual string JorCnombre { get; set; }
        public virtual DateTime JorDinicio { get; set; }
        public virtual DateTime JorDfin { get; set; }
        public virtual double? JorNcodmaster { get; set; }
    }
}
