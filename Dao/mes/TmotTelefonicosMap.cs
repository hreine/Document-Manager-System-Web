using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TmotTelefonicosMap : ClassMap<TmotTelefonicos> {
        
        public TmotTelefonicosMap() {
			Table("mes.tmot_telefonicos");
			LazyLoad();
			Id(x => x.MotNcodigo).GeneratedBy.Assigned().Column("mot_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.MotNmaster).Column("mot_nmaster").Not.Nullable();
			Map(x => x.MotCdescripcion).Column("mot_cdescripcion");
			Map(x => x.MotCagendamiento).Column("mot_cagendamiento");			
        }
    }
}
