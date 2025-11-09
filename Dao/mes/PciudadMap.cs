using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PciudadMap : ClassMap<Pciudad> {
        
        public PciudadMap() {
			Table("mes.pciudad");
			LazyLoad();
			Id(x => x.CiuNcodigo).GeneratedBy.Assigned().Column("ciu_ncodigo");
            References(x => x.Pdepartamento).Column("dep_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.CiuCnombre).Column("ciu_cnombre").Not.Nullable();
			Map(x => x.CiuCsigla).Column("ciu_csigla");
			Map(x => x.CiuCdane).Column("ciu_cdane");
			Map(x => x.CiuNcentro).Column("ciu_ncentro");
        }
    }
}
