using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TestadoGestionMap : ClassMap<TestadoGestion> {
        
        public TestadoGestionMap() {
			Table("mes.testado_gestion");
			LazyLoad();
			Id(x => x.EgCcodigo).GeneratedBy.Assigned().Column("eg_ccodigo");
			Map(x => x.EgCdescripcion).Column("eg_cdescripcion");
			Map(x => x.EgCagendamiento).Column("eg_cagendamiento");
			Map(x => x.EgCnotas).Column("eg_cnotas");
			Map(x => x.EgCcitasxcargue).Column("eg_ccitasxcargue");
			Map(x => x.EgCremision).Column("eg_cremision");
			Map(x => x.EgCcorrecdatos).Column("eg_ccorrecdatos");
			Map(x => x.AudCusuario).Column("aud_cusuario");
			Map(x => x.AudCestado).Column("aud_cestado");
			Map(x => x.AudFfecha).Column("aud_ffecha");
			Map(x => x.EgCcodmaster).Column("eg_ccodmaster");			
        }
    }
}
