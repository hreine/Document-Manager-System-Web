using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class RcargueDireccion {
        private Pciudad _pciudad;
        public RcargueDireccion() { }
        public virtual double RcdNcodigo { get; set; }
        public virtual Pciudad Pciudad
        {
            get { return _pciudad ?? (_pciudad = new Pciudad());}
            set
            {
                _pciudad = value;
                //_pciudad = ClaseBase.Contexto.Get<Pciudad>(_pciudad.CiuNcodigo);
            }
        }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual double CarNcodigo { get; set; }
        public virtual string RcdCdireccion { get; set; }
        public virtual string RcdCbarrio { get; set; }
    }
}
