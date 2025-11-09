using System;
using System.Text;
using System.Collections.Generic;


namespace Reines.dmsflex.Dao.mes {
    
    public class Pciudad {
        //private Pdepartamento _pdepartamento;
        public Pciudad() { }

        public virtual double CiuNcodigo { get; set; }
        public virtual Pdepartamento Pdepartamento { get; set; }
        /*{
            get { return _pdepartamento ?? (_pdepartamento = new Pdepartamento()); } 
            set { _pdepartamento = value;
            _pdepartamento = ClaseBase.Contexto.Get<Pdepartamento>(_pdepartamento.DepNcodigo);
            }
        }
        */
        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual string CiuCnombre { get; set; }
        public virtual string CiuCsigla { get; set; }
        public virtual string CiuCdane { get; set; }
        public virtual double? CiuNcentro { get; set; }
    }
}
