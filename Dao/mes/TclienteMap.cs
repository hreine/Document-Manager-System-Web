using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TclienteMap : ClassMap<Tcliente> {
        
        public TclienteMap() {
			Table("mes.tcliente");
			LazyLoad();
			Id(x => x.CliNcodigo).GeneratedBy.Assigned().Column("cli_ncodigo");
            References(x => x.Pciudad).Column("ciu_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.CliCrazonSocial).Column("cli_crazon_social");
			Map(x => x.CliCidentificacion).Column("cli_cidentificacion").Not.Nullable();
			Map(x => x.CliNdigitoVerificacion).Column("cli_ndigito_verificacion").Not.Nullable();
			Map(x => x.CliCsigla).Column("cli_csigla");
			Map(x => x.CliCdireccion).Column("cli_cdireccion").Not.Nullable();
			Map(x => x.CliCtelefono).Column("cli_ctelefono").Not.Nullable();
			Map(x => x.CliCsecuencia).Column("cli_csecuencia");
        }
    }
}
