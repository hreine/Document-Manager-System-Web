using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TdocumentoMap : ClassMap<Tdocumento> {
        
        public TdocumentoMap() {
			Table("mes.tdocumentos");
			LazyLoad();
			Id(x => x.DocNcodigo).GeneratedBy.Assigned().Column("doc_ncodigo");
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.DocCnombre).Column("doc_cnombre");
			Map(x => x.DocCvalhomologa).Column("doc_cvalhomologa");
			Map(x => x.DocCobservacion).Column("doc_cobservacion");
			Map(x => x.DocNpaginas).Column("doc_npaginas");
			Map(x => x.DocCtipo).Column("doc_ctipo");
			Map(x => x.DocBvisenctr).Column("doc_bvisenctr").Not.Nullable();
			Map(x => x.DocNorden).Column("doc_norden");
			Map(x => x.MedNcodigo).Column("med_ncodigo");
        }
    }
}
