using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class RcargueGestionMap : ClassMap<RcargueGestion> {
        
        public RcargueGestionMap() {
			Table("mes.rcargue_gestion");
			LazyLoad();
			Id(x => x.CrgNcodigo).GeneratedBy.Assigned().Column("crg_ncodigo");
            References(x => x.Ttracking).Column("trk_ncodigo").Not.LazyLoad();
            Map(x => x.CarNcodigo).Column("car_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.UsuCcodigo).Column("usu_ccodigo");
			Map(x => x.PrgCobservacion).Column("prg_cobservacion");
			Map(x => x.ManNcodigo).Column("man_ncodigo");
			Map(x => x.GetNcodigo).Column("get_ncodigo");
			Map(x => x.RemNcodigo).Column("rem_ncodigo");
        }
    }
}
