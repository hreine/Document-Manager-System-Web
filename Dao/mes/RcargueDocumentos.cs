using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class RcargueDocumentos {
        public virtual double CrdNcodigo { get; set; }        
        public virtual double CarNcodigo { get; set; }
        public virtual Tdocumento Tdocumento { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string CrdCasociacion { get; set; }
        public virtual string CrdCestado { get; set; }
        public virtual string CrdCvista { get; set; }
        public virtual string CrdCreporte { get; set; }
        public virtual int? CrdNorden { get; set; }
        public virtual double? CarNcodigoOrigen { get; set; }
        public virtual string CrdCdescripcion { get; set; }
    }
}
