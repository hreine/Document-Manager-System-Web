using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TgestionTelefonicaMap : ClassMap<TgestionTelefonica> {
        
        public TgestionTelefonicaMap() {
			Table("mes.tgestion_telefonica");
			LazyLoad();
			Id(x => x.GteNcodigo).GeneratedBy.Assigned().Column("gte_ncodigo");
            Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();                        
            References(x => x.RcargueTelefono).Column("rct_ncodigo").Not.LazyLoad();
            References(x => x.TmotTelefonicos).Column("mot_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.GteFfechaInicial).Column("gte_ffecha_inicial");
			Map(x => x.GteFfechaFinal).Column("gte_ffecha_final");
			Map(x => x.GteCobservacion).Column("gte_cobservacion");
			Map(x => x.CitNcodigo).Column("cit_ncodigo");
        }
    }
}
