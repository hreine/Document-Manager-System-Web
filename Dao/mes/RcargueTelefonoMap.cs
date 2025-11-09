using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class RcargueTelefonoMap : ClassMap<RcargueTelefono> {
        
        public RcargueTelefonoMap() {
			Table("mes.rcargue_telefono");
			LazyLoad();
			Id(x => x.RctNcodigo).GeneratedBy.Assigned().Column("rct_ncodigo");
            References(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();
			Map(x => x.RctCtelefono).Column("rct_ctelefono").Not.Nullable();
			Map(x => x.RctCextension).Column("rct_cextension");
			Map(x => x.RctNtipotel).Column("rct_ntipotel");
			Map(x => x.RctNcountGestion).Column("rct_ncount_gestion");
			Map(x => x.RctNcountVirtualgestion).Column("rct_ncount_virtualgestion");
			Map(x => x.RctNcontactos).Column("rct_ncontactos");
			Map(x => x.RctCestado).Column("rct_cestado");
        }
    }
}
