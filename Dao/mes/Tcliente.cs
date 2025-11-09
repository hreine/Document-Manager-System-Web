using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tcliente {
        public Tcliente() { }
        public virtual double CliNcodigo { get; set; }
        public virtual Pciudad Pciudad { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string CliCrazonSocial { get; set; }
        public virtual double CliCidentificacion { get; set; }
        public virtual double CliNdigitoVerificacion { get; set; }
        public virtual string CliCsigla { get; set; }
        public virtual string CliCdireccion { get; set; }
        public virtual double CliCtelefono { get; set; }
        public virtual string CliCsecuencia { get; set; }
    }
}
