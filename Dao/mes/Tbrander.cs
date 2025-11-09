using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tbrander {

        private Pciudad _pciudad;
        public virtual double BraNcodigo { get; set; }
        public virtual Tnegocio Tnegocio { get; set; }
        public virtual Pjornada Pjornada { get; set; }
        public virtual PestCita PestCita { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string BraCcedula { get; set; }
        public virtual string BraCnmbtit { get; set; }
        public virtual string BraCcelular { get; set; }
        public virtual string BraCtelefono { get; set; }
        public virtual string BraCdireccion { get; set; }        
        public virtual Pciudad Pciudad
        {
            get { return _pciudad ?? (_pciudad = new Pciudad()); }
            set
            {
                _pciudad = value;
                //_pciudad = ClaseBase.Contexto.Get<Pciudad>(_pciudad.CiuNcodigo);
            }
        }
        public virtual DateTime BraFfecha { get; set; }
        public virtual string BraCobservacion { get; set; }
        public virtual string BraCactividadEconomica { get; set; }
        public virtual string BraCconvenio { get; set; } 
    }
}
