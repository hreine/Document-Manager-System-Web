using FluentNHibernate.Mapping;


namespace Reines.dmsflex.Dao.mes
{
    public class TsedeMap : ClassMap<Tsede>
    {
        public TsedeMap()
        {
            Table("mes.tsede");
            LazyLoad();
            Id(x => x.SedNcodigo).GeneratedBy.Assigned().Column("sed_ncodigo");
            Map(x => x.CreFfecha).Column("cre_ffecha");
            Map(x => x.SedNcodpadre).Column("sed_ncodpadre");
            References<Pciudad>(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad(); 
            Map(x => x.OfiCcodOficina).Column("ofi_ccod_oficina");
            Map(x => x.SedCpiso).Column("sed_cpiso");
            Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
            Map(x => x.SedCprincipal).Column("sed_cprincipal").Not.Nullable();
            Map(x => x.CreNconsecutivo).Column("cre_nconsecutivo");
            References<Tcliente>(x => x.Tcliente).Column("cli_ncodigo").Not.LazyLoad(); 
            Map(x => x.SedCnombre).Column("sed_cnombre").Not.Nullable();
            Map(x => x.SedCtelefono).Column("sed_ctelefono");
            Map(x => x.SedCdireccion).Column("sed_cdireccion").Not.Nullable();
            Map(x => x.SedCoficina).Column("sed_coficina");
            Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
            Map(x => x.CreCusuario).Column("cre_cusuario");
            Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
        }
    }
}