using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tcita {
        private RcargueTelefono _rcargueTelefono;
        private RcargueDireccion _rcargueDireccion;
        private Pjornada _pjornada;        
        private PestCita _pestCita;
        private PtipoCita _ptipoCita;

        public virtual double CitNcodigo { get; set;}
        public virtual double CarNcodigo { get; set; }
        /*
        public virtual Tcargue Tcargue
        {
            get { return _tcargue??(_tcargue = new Tcargue());} 
            set { _tcargue = value;
            _tcargue = ClaseBase.Contexto.Get<Tcargue>(_tcargue.CarNcodigo);
            }
        }
        */
        public virtual PestCita PestCita         
        {
            get { return _pestCita??(_pestCita = new PestCita()); } 
            set
            {
                _pestCita = value;
               // if (_pestCita != null) _pestCita = Double.IsNaN(_pestCita.EtcNcodigo)==false? ClaseBase.Contexto.Get<PestCita>(_pestCita.EtcNcodigo):null;
            }
        }
        
        public virtual PtipoCita PtipoCita
        {
            get { return _ptipoCita ?? (_ptipoCita= new PtipoCita()); } 
            set { _ptipoCita = value;
            //_ptipoCita = ClaseBase.Contexto.Get<PtipoCita>(_ptipoCita.TciNcodigo);
            }
        }

        public virtual RcargueDireccion RcargueDireccion
        {
            get { return _rcargueDireccion ?? (_rcargueDireccion = new RcargueDireccion()); }
            set { _rcargueDireccion = value;
            //_rcargueDireccion = ClaseBase.Contexto.Get<RcargueDireccion>(_rcargueDireccion.RcdNcodigo);
            }
        }

        public virtual RcargueTelefono RcargueTelefono
        {
            get { return _rcargueTelefono ?? (_rcargueTelefono= new RcargueTelefono()); } 
            set { _rcargueTelefono = value;
            //_rcargueTelefono = ClaseBase.Contexto.Get<RcargueTelefono>(_rcargueTelefono.RctNcodigo);
            }
        }

        public virtual Pjornada Pjornada
        {
            get { return _pjornada??(_pjornada = new Pjornada()); } 
            set { _pjornada = value;
            //_pjornada = ClaseBase.Contexto.Get<Pjornada>(_pjornada.JorNcodigo);
            }
        }
        public virtual string AudCusuario { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime CitFfecha { get; set; }
        public virtual string CitCobservacion { get; set; }
        public virtual DateTime CitFfechaCancela { get; set; }
        public virtual string UsuCusuarioCancela { get; set; }
        public virtual DateTime CitFfechaCrea { get; set; }
        public virtual string CitCusuCrea { get; set; }
    }
}
