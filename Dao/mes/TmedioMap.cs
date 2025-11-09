using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TmedioMap : ClassMap<Tmedio> {
        
        public TmedioMap() {
			Table("mes.tmedios");
			LazyLoad();
			Id(x => x.MedNcodigo).GeneratedBy.Assigned().Column("med_ncodigo");
			//References(x => x.Tnegocio).Column("neg_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.MedCnombre).Column("med_cnombre");
			Map(x => x.MedCvalhomologa).Column("med_cvalhomologa");
			Map(x => x.MedCasignacion).Column("med_casignacion");
			Map(x => x.MedNmaster).Column("med_nmaster");
			Map(x => x.MedCregex).Column("med_cregex");
			Map(x => x.MedCencript).Column("med_cencript");
			Map(x => x.MedBpubkey).Column("med_bpubkey");
            Map(x => x.MmdNcodigo).Column("mmd_ncodigo");            
        }
    }
}
