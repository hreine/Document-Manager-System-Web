using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;


namespace Reines.dmsflex.Dao.mes
{
    public class TusuarioMap : ClassMap<Tusuario>
    {
        public TusuarioMap()
        {
            Table("mes.tusuario");
            LazyLoad();
            Id(x => x.UsuCcodigo).GeneratedBy.Assigned().Column("usu_ccodigo");
            References<Tsede>(x => x.Tsede).Column("sed_ncodigo").Not.LazyLoad();
            Map(x => x.UsuCobliga).Column("usu_cobliga").Not.Nullable();
            Map(x => x.UsuCsadmin).Column("usu_csadmin");
            Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
            Map(x => x.UsuCemail).Column("usu_cemail");
            Map(x => x.UsuCcedula).Column("usu_ccedula").Not.Nullable();
            Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
            Map(x => x.UsuNtimeout).Column("usu_ntimeout");
            Map(x => x.UsuCapellido).Column("usu_capellido").Not.Nullable();
            Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
            Map(x => x.UsuCreexpedicion).Column("usu_creexpedicion");
            Map(x => x.UsuCnombre).Column("usu_cnombre").Not.Nullable();
            Map(x => x.UsuCclave).Column("usu_cclave");
        }
    }
}