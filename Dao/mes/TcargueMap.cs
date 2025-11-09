using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Reines.dmsflex.Dao.mes; 

namespace Reines.dmsflex.Dao.mes {
    
    
    public class TcargueMap : ClassMap<Tcargue> {
        
        public TcargueMap() {
			Table("mes.tcargue");
			LazyLoad();
			Id(x => x.CarNcodigo).GeneratedBy.Assigned().Column("car_ncodigo");
            References(x => x.Torden).Column("ord_ncodigo").Not.LazyLoad();
			Map(x => x.AudCusuario).Column("aud_cusuario").Not.Nullable();
			Map(x => x.AudCestado).Column("aud_cestado").Not.Nullable();
			Map(x => x.AudFfecha).Column("aud_ffecha").Not.Nullable();
			Map(x => x.CarNconsecutivo).Column("car_nconsecutivo").Not.Nullable();
			Map(x => x.CarFenvio).Column("car_fenvio").Not.Nullable();
			Map(x => x.CarCidentificacion).Column("car_cidentificacion").Not.Nullable();
			Map(x => x.ParNtipoid).Column("par_ntipoid");
			Map(x => x.CarCnombre1).Column("car_cnombre1");
			Map(x => x.CarCnombre2).Column("car_cnombre2");
			Map(x => x.CarCapellido1).Column("car_capellido1");
			Map(x => x.CarCapellido2).Column("car_capellido2");
			Map(x => x.CarCnombre).Column("car_cnombre");
			Map(x => x.CarCtelefono1).Column("car_ctelefono1");
			Map(x => x.CarCtelefono2).Column("car_ctelefono2");
			Map(x => x.CarCtelefono3).Column("car_ctelefono3");
			Map(x => x.CarCtelefono4).Column("car_ctelefono4");
			Map(x => x.CarCtelefono5).Column("car_ctelefono5");
			Map(x => x.CarCtelefono6).Column("car_ctelefono6");
			Map(x => x.CarCtelefono7).Column("car_ctelefono7");
			Map(x => x.CarCtelefono8).Column("car_ctelefono8");
			Map(x => x.CarCtelefono9).Column("car_ctelefono9");
			Map(x => x.CarCtelefono10).Column("car_ctelefono10");
			Map(x => x.CarCdireccion1).Column("car_cdireccion1");
			Map(x => x.CarCdireccion2).Column("car_cdireccion2");
			Map(x => x.CarCdireccion3).Column("car_cdireccion3");
			Map(x => x.CarCdireccion4).Column("car_cdireccion4");
			Map(x => x.CarCdireccion5).Column("car_cdireccion5");
			Map(x => x.CarCdireccion6).Column("car_cdireccion6");
			Map(x => x.CarCdireccion7).Column("car_cdireccion7");
			Map(x => x.CarCdireccion8).Column("car_cdireccion8");
			Map(x => x.CarCdireccion9).Column("car_cdireccion9");
			Map(x => x.CarCdireccion10).Column("car_cdireccion10");
			Map(x => x.CarCciudad1).Column("car_cciudad1");
			Map(x => x.CarCciudad2).Column("car_cciudad2");
			Map(x => x.CarCciudad3).Column("car_cciudad3");
			Map(x => x.CarCciudad4).Column("car_cciudad4");
			Map(x => x.CarCciudad5).Column("car_cciudad5");
			Map(x => x.CarCciudad6).Column("car_cciudad6");
			Map(x => x.CarCciudad7).Column("car_cciudad7");
			Map(x => x.CarCciudad8).Column("car_cciudad8");
			Map(x => x.CarCciudad9).Column("car_cciudad9");
			Map(x => x.CarCciudad10).Column("car_cciudad10");
			Map(x => x.CarCnomCiudad1).Column("car_cnom_ciudad1");
			Map(x => x.CarCnomCiudad2).Column("car_cnom_ciudad2");
			Map(x => x.CarCnomCiudad3).Column("car_cnom_ciudad3");
			Map(x => x.CarCnomCiudad4).Column("car_cnom_ciudad4");
			Map(x => x.CarCnomCiudad5).Column("car_cnom_ciudad5");
			Map(x => x.CarCnomCiudad6).Column("car_cnom_ciudad6");
			Map(x => x.CarCnomCiudad7).Column("car_cnom_ciudad7");
			Map(x => x.CarCnomCiudad8).Column("car_cnom_ciudad8");
			Map(x => x.CarCnomCiudad9).Column("car_cnom_ciudad9");
			Map(x => x.CarCnomCiudad10).Column("car_cnom_ciudad10");
			Map(x => x.CarCcodSucursal).Column("car_ccod_sucursal");
			Map(x => x.CarCnomSucursal).Column("car_cnom_sucursal");
			Map(x => x.CarCestado).Column("car_cestado");
			Map(x => x.UsuCasociacion).Column("usu_casociacion");
			Map(x => x.CarFasociacion).Column("car_fasociacion");
			Map(x => x.CarCasociacion).Column("car_casociacion");
			Map(x => x.CiuNcodigo).Column("ciu_ncodigo");
			Map(x => x.CarCtelext1).Column("car_ctelext1");
			Map(x => x.CarCtelext2).Column("car_ctelext2");
			Map(x => x.CarCtelext3).Column("car_ctelext3");
			Map(x => x.CarCtelext4).Column("car_ctelext4");
			Map(x => x.CarCtelext5).Column("car_ctelext5");
			Map(x => x.CarCtelext6).Column("car_ctelext6");
			Map(x => x.CarCtelext7).Column("car_ctelext7");
			Map(x => x.CarCtelext8).Column("car_ctelext8");
			Map(x => x.CarCtelext9).Column("car_ctelext9");
			Map(x => x.CarCtelext10).Column("car_ctelext10");
			Map(x => x.CarCperfilDoc).Column("car_cperfil_doc");
            Map(x => x.CarCemision).Column("car_cemision");
            HasMany(x => x.RcargueDirecciones).KeyColumn("car_ncodigo").Not.LazyLoad();
            HasMany(x => x.RcargueDocumentos).KeyColumn("car_ncodigo").Not.LazyLoad();
            HasMany(x => x.RcargueGestiones).KeyColumn("car_ncodigo").Not.LazyLoad();
			//HasMany(x => x.RcargueGrdoc).KeyColumns(new string[]  });
            HasMany(x => x.RcargueMedios).KeyColumn("car_ncodigo").Not.LazyLoad();
            HasMany(x => x.RcargueTelefonos).KeyColumn("car_ncodigo").Not.LazyLoad();
            HasMany(x => x.Tcitas).KeyColumn("car_ncodigo").Not.LazyLoad();
            HasMany(x => x.TgestionesTelefonicas).KeyColumn("car_ncodigo").Not.LazyLoad(); 
			//HasMany(x => x.Tproducto).KeyColumns(new string[]  });
			//HasMany(x => x.TremisionDetalle).KeyColumns(new string[]  });

        }
    }
}
