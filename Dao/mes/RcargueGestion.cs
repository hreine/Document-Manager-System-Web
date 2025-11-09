using System;
using System.Text;
using System.Collections.Generic;



namespace Reines.dmsflex.Dao.mes {
    
    public class RcargueGestion {
        public virtual double CrgNcodigo { get; set; }
        public virtual Ttracking Ttracking { get; set; }
        public virtual double CarNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string UsuCcodigo { get; set; }
        public virtual string PrgCobservacion { get; set; }
        public virtual double? ManNcodigo { get; set; }
        public virtual double? GetNcodigo { get; set; }
        public virtual double? RemNcodigo { get; set; }
    }



}
