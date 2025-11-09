using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tdocumento {
        public Tdocumento() { }
        public virtual double DocNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string DocCnombre { get; set; }
        public virtual string DocCvalhomologa { get; set; }
        public virtual string DocCobservacion { get; set; }
        public virtual int? DocNpaginas { get; set; }
        public virtual string DocCtipo { get; set; }
        public virtual bool DocBvisenctr { get; set; }
        public virtual int? DocNorden { get; set; }
        public virtual double? MedNcodigo { get; set; }
    }
}
