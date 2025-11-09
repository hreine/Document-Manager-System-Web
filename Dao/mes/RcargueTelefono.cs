using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class RcargueTelefono {
        public RcargueTelefono() { }
        public virtual double RctNcodigo { get; set; }
        public virtual Pciudad Pciudad { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual double CarNcodigo { get; set; }
        public virtual string RctCtelefono { get; set; }
        public virtual string RctCextension { get; set; }
        public virtual double? RctNtipotel { get; set; }
        public virtual double? RctNcountGestion { get; set; }
        public virtual double? RctNcountVirtualgestion { get; set; }
        public virtual double? RctNcontactos { get; set; }
        public virtual string RctCestado { get; set; }
    }
}
