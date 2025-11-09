using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class RcargueDireccionMap : ClassMap<RcargueDireccion> {
        
        public RcargueDireccionMap() {
			Table("mes.rcargue_direccion");
			LazyLoad();
			Id(x => x.RcdNcodigo).GeneratedBy.Assigned().Column("rcd_ncodigo");
            References(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();
			Map(x => x.RcdCdireccion).Column("rcd_cdireccion").Not.Nullable();
			Map(x => x.RcdCbarrio).Column("rcd_cbarrio");
        }
    }
}
