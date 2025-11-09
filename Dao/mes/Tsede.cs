using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes
{
    public class Tsede
    {
        public Tsede()
        {
            _tcliente = new Tcliente();
            _pciudad = new Pciudad();
        }

        private Tcliente _tcliente;
        private Pciudad _pciudad;

        public virtual double SedNcodigo { get; set; }
        public virtual DateTime? CreFfecha { get; set; }
        public virtual double? SedNcodpadre { get; set; }

        public virtual Pciudad Pciudad
        {
            get
            {
                if (_pciudad == null)
                {
                    _pciudad = new Pciudad();
                    return _pciudad;
                }
                else
                {
                    return _pciudad;
                }
            }
            set
            {
                _pciudad = value;
                _pciudad = ClaseBase.Contexto.Get<Pciudad>(_pciudad.CiuNcodigo);
            }
        }

        public virtual string OfiCcodOficina { get; set; }
        public virtual string SedCpiso { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string SedCprincipal { get; set; }
        public virtual double? CreNconsecutivo { get; set; }

        public virtual Tcliente Tcliente
        {
            get
            {
                if (_tcliente == null)
                {
                    _tcliente = new Tcliente();
                    return _tcliente;
                }
                else
                {
                    return _tcliente;
                }
            }
            set
            {
                _tcliente = value;
                _tcliente = ClaseBase.Contexto.Get<Tcliente>(_tcliente.CliNcodigo);
            }
        }

        public virtual string SedCnombre { get; set; }
        public virtual string SedCtelefono { get; set; }
        public virtual string SedCdireccion { get; set; }
        public virtual string SedCoficina { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual string CreCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
    }
}