using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class RcargueMedioMap : ClassMap<RcargueMedio> {
        
        public RcargueMedioMap() {
			Table("mes.rcargue_medios");
			LazyLoad();
			Id(x => x.RcmNcodigo).GeneratedBy.Assigned().Column("rcm_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();
            References(x => x.Tmedio).Column("med_ncodigo").Not.LazyLoad();            
			Map(x => x.RcmCasociacion).Column("rcm_casociacion");
			Map(x => x.RcmCestado).Column("rcm_cestado").Not.Nullable();
			Map(x => x.RcmScrach).Column("rcm_scrach");
			Map(x => x.CarNcodigoOrigen).Column("car_ncodigo_origen").Not.Nullable();
			Map(x => x.RcmNmaster).Column("rcm_nmaster");
			Map(x => x.CrdNcodigo).Column("crd_ncodigo");
			Map(x => x.RcmBasociacion).Column("rcm_basociacion");
        }
    }
}
