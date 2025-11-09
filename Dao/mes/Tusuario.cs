using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes
{
    public class Tusuario
    {
        private Tsede _tsede;
        public virtual string UsuCcodigo { get; set; }

        public virtual Tsede Tsede
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

        public virtual string UsuCobliga { get; set; }
        public virtual string UsuCsadmin { get; set; }
        public virtual string AudCusuario { get; set; }
        public virtual string UsuCemail { get; set; }
        public virtual string UsuCcedula { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual double? UsuNtimeout { get; set; }
        public virtual string UsuCapellido { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string UsuCreexpedicion { get; set; }
        public virtual string UsuCnombre { get; set; }
        public virtual string UsuCclave { get; set; }
    }
}