using System;
using System.Text;
using System.Collections.Generic;



namespace Reines.dmsflex.Dao.mes {

    public class Tproducto 
    {
        //private Tcargue _tcargue;
        private TestadoGestion _testadoGestion;
        private Ttracking _ttracking;
        private Pciudad _pciudadEntrega;
        private Tsede _tsede;

        public virtual double ProNcodigo { get; set; }
        public virtual Tcargue Tcargue { get; set; }
        /*
        {
            get { return _tcargue ?? (_tcargue = new Tcargue());}
            set
            {
                _tcargue = value;
                if (value != null) _tcargue = ClaseBase.Contexto.Get<Tcargue>(_tcargue.CarNcodigo);
            }
        }
        */
        public virtual TestadoGestion TestadoGestion
        {
            get { return _testadoGestion??(_testadoGestion = new TestadoGestion()); }
            set { _testadoGestion = value;
            if (value != null) _testadoGestion = ClaseBase.Contexto.Get<TestadoGestion>(_testadoGestion.EgCcodigo);                
            }
        }

        public virtual Ttracking Ttracking
        {
            get { return _ttracking ?? (_ttracking = new Ttracking()); }
            set
            {
                _ttracking = value;
                if (value != null) _ttracking = ClaseBase.Contexto.Get<Ttracking>(_ttracking.TrkNcodigo);
            }
        }

        public virtual string AudCusuario { get; set;}
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set;}
        public virtual double? CitNcodigo { get; set; }
        public virtual string ProCdescuelgue { get; set;}
        public virtual string ProCguia { get; set; }
        //public virtual double? SedNactual { get; set; }
        //public virtual double? CiuNentrega { get; set; }

        public virtual Tsede TsedeActual
        {
            get
            {
                if (_tsede == null)
                {
                    _tsede = new Tsede();
                    return _tsede;
                }
                else
                {
                    return _tsede;
                }
            }
            set
            {
                _tsede = value;
                _tsede = ClaseBase.Contexto.Get<Tsede>(_tsede.SedNcodigo);
            }
        }
        public virtual Pciudad PciudadEntrega
        {
            get { return _pciudadEntrega ?? (_pciudadEntrega = new Pciudad()); }
            set
            {
                _pciudadEntrega = value;
                _pciudadEntrega = ClaseBase.Contexto.Get<Pciudad>(_pciudadEntrega.CiuNcodigo);
            }
        }

        public virtual double? GteNcodigo { get; set; }
        public virtual double? MadNcodigo { get; set; }

    }
}
