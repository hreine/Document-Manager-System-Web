using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PtipoCitaMap : ClassMap<PtipoCita> {
        
        public PtipoCitaMap() {
			Table("mes.ptipo_cita");
			LazyLoad();
			Id(x => x.TciNcodigo).GeneratedBy.Assigned().Column("tci_ncodigo");
			Map(x => x.TciCnombre).Column("tci_cnombre");
        }
    }
}
