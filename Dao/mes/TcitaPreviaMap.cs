using FluentNHibernate.Mapping;


namespace Reines.dmsflex.Dao.mes {
    
    
    public class TcitaPreviaMap : ClassMap<TcitaPrevia> {
        
        public TcitaPreviaMap() {
			Table("mes.tcita_previa");
			LazyLoad();
			Id(x => x.CprNcodigo).GeneratedBy.Assigned().Column("cpr_ncodigo");
            References(x => x.Tnegocio).Column("neg_ncodigo").Not.LazyLoad();
            References(x => x.Pjornada).Column("jor_ncodigo").Not.LazyLoad();
            References(x => x.PestCita).Column("etc_ncodigo").Not.LazyLoad();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.CprCcedula).Column("cpr_ccedula").Not.Nullable();
			Map(x => x.CprCnmbtit).Column("cpr_cnmbtit").Not.Nullable();
			Map(x => x.CprCtelefono).Column("cpr_ctelefono").Not.Nullable();
			Map(x => x.CprNdireccion).Column("cpr_ndireccion").Not.Nullable();
			//Map(x => x.CiuNcodigo).Column("ciu_ncodigo").Not.Nullable();
            References(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad();
			Map(x => x.CprFfecha).Column("cpr_ffecha").Not.Nullable();
			Map(x => x.CprCobservacion).Column("cpr_cobservacion");
        }
    }
}
