using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class RcargueDocumentosMap : ClassMap<RcargueDocumentos> {
        
        public RcargueDocumentosMap() {
			Table("mes.rcargue_documentos");
			LazyLoad();
			Id(x => x.CrdNcodigo).GeneratedBy.Assigned().Column("crd_ncodigo");
            Map(x => x.CarNcodigo).Column("car_ncodigo").Not.Nullable();
            //References(x => x.Tcargue).Column("car_ncodigo").Not.LazyLoad();
            References(x => x.Tdocumento).Column("doc_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.CrdCasociacion).Column("crd_casociacion");
			Map(x => x.CrdCestado).Column("crd_cestado").Not.Nullable();
			Map(x => x.CrdCvista).Column("crd_cvista");
			Map(x => x.CrdCreporte).Column("crd_creporte");
			Map(x => x.CrdNorden).Column("crd_norden");
			Map(x => x.CarNcodigoOrigen).Column("car_ncodigo_origen");
			Map(x => x.CrdCdescripcion).Column("crd_cdescripcion");
        }
    }
}
