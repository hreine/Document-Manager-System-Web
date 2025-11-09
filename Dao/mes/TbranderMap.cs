using FluentNHibernate.Mapping;


namespace Reines.dmsflex.Dao.mes {
    
    
    public class TbranderMap : ClassMap<Tbrander> {

        public TbranderMap()
        {
			Table("mes.tbrander");
			LazyLoad();
			Id(x => x.BraNcodigo).GeneratedBy.Assigned().Column("bra_ncodigo");
            References(x => x.Tnegocio).Column("neg_ncodigo").Not.LazyLoad();
            References(x => x.Pjornada).Column("jor_ncodigo").Not.LazyLoad();
            References(x => x.PestCita).Column("etc_ncodigo").Not.LazyLoad();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
            Map(x => x.BraCcedula).Column("bra_ccedula").Not.Nullable();
            Map(x => x.BraCnmbtit).Column("bra_cnmbtit").Not.Nullable();                        
            Map(x => x.BraCtelefono).Column("bra_ctelefono").Not.Nullable();
            Map(x => x.BraCcelular).Column("bra_ccelular").Not.Nullable();
            Map(x => x.BraCdireccion).Column("bra_cdireccion").Not.Nullable();			
            References(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad();
            Map(x => x.BraFfecha).Column("bra_ffecha").Not.Nullable();
            Map(x => x.BraCobservacion).Column("bra_cobservacion");
            Map(x => x.BraCactividadEconomica).Column("bra_cactividad_economica");
            Map(x => x.BraCconvenio).Column("bra_cconvenio");
        }
    }
}
