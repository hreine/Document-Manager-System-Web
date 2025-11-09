using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tmedio {
        public Tmedio() { }
        public virtual double MedNcodigo { get; set; }
        //public virtual Tnegocio Tnegocio { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string MedCnombre { get; set; }
        public virtual string MedCvalhomologa { get; set; }
        public virtual string MedCasignacion { get; set; }
        public virtual double? MedNmaster { get; set; }
        public virtual string MedCregex { get; set; }
        public virtual string MedCencript { get; set; }
        public virtual string MedBpubkey { get; set; }
        public virtual string MmdNcodigo { get; set; }
    }
}
