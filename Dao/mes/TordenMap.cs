using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TordenMap : ClassMap<Torden> {
        
        public TordenMap() {
			Table("mes.torden");
			LazyLoad();
			Id(x => x.OrdNcodigo).GeneratedBy.Assigned().Column("ord_ncodigo");
            References(x => x.Tnegocio).Column("neg_ncodigo").Not.LazyLoad(); 
            References(x => x.Tsede).Column("sed_ncodigo").Not.LazyLoad(); 
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.OrdCarchivo).Column("ord_carchivo");
        }
    }
}
