using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PjornadaMap : ClassMap<Pjornada> {
        
        public PjornadaMap() {
			Table("mes.pjornada");
			LazyLoad();
			Id(x => x.JorNcodigo).GeneratedBy.Assigned().Column("jor_ncodigo");
			Map(x => x.JorCnombre).Column("jor_cnombre");
			Map(x => x.JorDinicio).Column("jor_dinicio");
			Map(x => x.JorDfin).Column("jor_dfin");
			Map(x => x.JorNcodmaster).Column("jor_ncodmaster");
        }
    }
}
