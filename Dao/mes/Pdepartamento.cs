using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Pdepartamento {
        public Pdepartamento() { }
        public virtual double DepNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string AudFfecha { get; set; }
        public virtual string DepCnombre { get; set; }
        public virtual string DepCcodigoDane { get; set; }
    }
}
