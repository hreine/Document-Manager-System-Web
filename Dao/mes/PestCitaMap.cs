using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PestCitaMap : ClassMap<PestCita> {
        
        public PestCitaMap() {
			Table("mes.pest_cita");
			LazyLoad();
			Id(x => x.EtcNcodigo).GeneratedBy.Assigned().Column("etc_ncodigo");
			Map(x => x.EtcCnombre).Column("etc_cnombre");
        }
    }
}
