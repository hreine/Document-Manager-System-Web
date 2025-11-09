using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Torden {
        /*
        private Tsede _tsede;
        private Tnegocio _tnegocio;
        */
        public Torden() { }
        public virtual double OrdNcodigo { get; set; }
        public virtual Tnegocio Tnegocio { get; set; }
        /*
        {
            get { return _tnegocio ?? (_tnegocio= new Tnegocio()); }
            set { _tnegocio = value; _tnegocio = ClaseBase.Contexto.Get<Tnegocio>(_tnegocio.NegNcodigo); }
        }*/

        public virtual Tsede Tsede { get; set; }
            /*
        {
            get { return _tsede??(_tsede = new Tsede()); }
            set { _tsede = value; _tsede = ClaseBase.Contexto.Get<Tsede>(_tsede.SedNcodigo); }
        }
            */
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string OrdCarchivo { get; set; }
    }
}
