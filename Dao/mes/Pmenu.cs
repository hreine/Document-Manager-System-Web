using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Pmenu {
        public Pmenu() { }
        public virtual double MenNcodigo { get; set; }
        public virtual string MenCnombre { get; set; }
        public virtual string MenCdescripcion { get; set; }
        public virtual string MenCtxtayuda { get; set; }
        public virtual string MenCcategoria { get; set; }
        public virtual string MenCtipo { get; set; }
    }
}
