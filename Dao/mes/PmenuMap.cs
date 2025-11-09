using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class PmenuMap : ClassMap<Pmenu> {
        
        public PmenuMap() {
			Table("mes.pmenu");
			LazyLoad();
			Id(x => x.MenNcodigo).GeneratedBy.Assigned().Column("men_ncodigo");
			Map(x => x.MenCnombre).Column("men_cnombre").Not.Nullable();
			Map(x => x.MenCdescripcion).Column("men_cdescripcion").Not.Nullable();
			Map(x => x.MenCtxtayuda).Column("men_ctxtayuda");
			Map(x => x.MenCcategoria).Column("men_ccategoria");
			Map(x => x.MenCtipo).Column("men_ctipo");
        }
    }
}
