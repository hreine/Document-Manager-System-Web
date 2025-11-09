using System;
using System.Text;
using System.Collections.Generic;
using Reines.Vo;


namespace Reines.dmsflex.Dao.mes {
    
    public class RcargueMedio {
        private Tmedio _tmedio;
        public virtual double RcmNcodigo { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual double CarNcodigo { get; set; }
        public virtual Tmedio Tmedio
        {
            get { return _tmedio ?? (_tmedio= new Tmedio()); }
            set { _tmedio = value; }
        }
        //public virtual double MedNcodigo { get; set; }
        public virtual string RcmCasociacion { get; set; }
        public virtual string RcmCestado { get; set; }
        public virtual string RcmScrach { get; set; }
        public virtual double CarNcodigoOrigen { get; set; }
        public virtual double? RcmNmaster { get; set; }
        public virtual double? CrdNcodigo { get; set; }
        public virtual string RcmBasociacion { get; set; }       
    }


   

}
