using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TnegocioMap : ClassMap<Tnegocio> {
        
        public TnegocioMap() {
			Table("mes.tnegocio");
            LazyLoad();
			Id(x => x.NegNcodigo).GeneratedBy.Assigned().Column("neg_ncodigo");
			References(x => x.Tcliente).Column("cli_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.NegCnombre).Column("neg_cnombre");            
        }
    }
}
