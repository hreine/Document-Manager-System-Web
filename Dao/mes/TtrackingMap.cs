using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TtrackingMap : ClassMap<Ttracking> {
        
        public TtrackingMap() {
			Table("mes.ttracking");
			LazyLoad();
			Id(x => x.TrkNcodigo).GeneratedBy.Assigned().Column("trk_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.TrkCdescripcion).Column("trk_cdescripcion");
			Map(x => x.TrkCfinal).Column("trk_cfinal");
			Map(x => x.TrkCaccion).Column("trk_caccion");			
        }
    }
}
