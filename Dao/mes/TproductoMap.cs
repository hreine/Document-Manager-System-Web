using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TproductoMap : ClassMap<Tproducto> {
        
        public TproductoMap() {
			Table("mes.tproducto");
			LazyLoad();
			Id(x => x.ProNcodigo).GeneratedBy.Assigned().Column("pro_ncodigo");
            References(x => x.Tcargue).Column("car_ncodigo").Not.LazyLoad();
            References(x => x.TestadoGestion).Column("eg_ccodigo").Not.LazyLoad();
            References(x => x.Ttracking).Column("trk_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CitNcodigo).Column("cit_ncodigo");
			Map(x => x.ProCdescuelgue).Column("pro_cdescuelgue");
			Map(x => x.ProCguia).Column("pro_cguia").Not.Nullable();
			//Map(x => x.SedNactual).Column("sed_nactual");
            References(x => x.TsedeActual).Column("sed_nactual").Not.LazyLoad();
			//Map(x => x.CiuNentrega).Column("ciu_nentrega");
            References(x => x.PciudadEntrega).Column("ciu_nentrega").Not.LazyLoad();            
            Map(x => x.GteNcodigo).Column("gte_ncodigo");
            Map(x => x.MadNcodigo).Column("mad_ncodigo");
        }
    }
}
