using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class TcitaPrevia {
        private Pciudad _pciudad;
        public virtual double CprNcodigo { get; set; }
        public virtual Tnegocio Tnegocio { get; set; }
        public virtual Pjornada Pjornada { get; set; }
        public virtual PestCita PestCita { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string CprCcedula { get; set; }
        public virtual string CprCnmbtit { get; set; }
        public virtual string CprCtelefono { get; set; }
        public virtual double CprNdireccion { get; set; }        
        public virtual Pciudad Pciudad
        {
            get { return _pciudad ?? (_pciudad = new Pciudad()); }
            set
            {
                _pciudad = value;
                //_pciudad = ClaseBase.Contexto.Get<Pciudad>(_pciudad.CiuNcodigo);
            }
        }
        public virtual DateTime CprFfecha { get; set; }
        public virtual string CprCobservacion { get; set; }
    }
}
