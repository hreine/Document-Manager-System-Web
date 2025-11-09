using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PdepartamentoMap : ClassMap<Pdepartamento> {
        
        public PdepartamentoMap() {
			Table("mes.pdepartamento");
			LazyLoad();
			Id(x => x.DepNcodigo).GeneratedBy.Assigned().Column("dep_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.DepCnombre).Column("dep_cnombre").Not.Nullable();
			Map(x => x.DepCcodigoDane).Column("dep_ccodigo_dane");
        }
    }
}
