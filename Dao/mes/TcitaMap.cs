using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TcitaMap : ClassMap<Tcita> {
        
        public TcitaMap() {
			Table("mes.tcita");
			LazyLoad();
			Id(x => x.CitNcodigo).GeneratedBy.Assigned().Column("cit_ncodigo");
            Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();            
            //References(x => x.Tcargue).Column("car_ncodigo").Not.LazyLoad();
            References(x => x.PestCita).Column("etc_ncodigo").Not.LazyLoad();
            References(x => x.PtipoCita).Column("tci_ncodigo").Not.LazyLoad();
            References(x => x.RcargueDireccion).Column("rcd_ncodigo").Not.LazyLoad();
            References(x => x.RcargueTelefono).Column("rct_ncodigo").Not.LazyLoad();
            References(x => x.Pjornada).Column("jor_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CitFfecha).Column("cit_ffecha").Not.Nullable();
			Map(x => x.CitCobservacion).Column("cit_cobservacion");
			Map(x => x.CitFfechaCancela).Column("cit_ffecha_cancela");
			Map(x => x.UsuCusuarioCancela).Column("usu_cusuario_cancela");
			Map(x => x.CitFfechaCrea).Column("cit_ffecha_crea");
			Map(x => x.CitCusuCrea).Column("cit_cusu_crea");
        }
    }
}
