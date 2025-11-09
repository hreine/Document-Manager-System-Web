using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Criterion;


namespace Reines.dmsflex.Dao.mes {
    
    public class Tcargue {
        private Torden _torden;
        private IList<RcargueDireccion> _rcargueDireccion;
        private IList<RcargueTelefono> _rcargueTelefono;
        private IList<Tcita> _tcita;
        private IList<RcargueGestion> _rcargueGestion;
        private IList<RcargueDocumentos> _rcargueDocumentos;
        private IList<TgestionTelefonica> _tgestionTelefonica;
        private IList<RcargueMedio> _rcargueMedios;

        public Tcargue()
        {            
        }
        public virtual double CarNcodigo { get; set; }

        public virtual Torden Torden
        {
            get { return _torden ?? (_torden=new Torden()); }
            set
            {
                _torden = value;
                _torden = ClaseBase.Contexto.Get<Torden>(_torden.OrdNcodigo);
            }
        }

        public virtual string AudCusuario { get; set; }
        public virtual string AudCestado { get; set; }
        public virtual DateTime AudFfecha { get; set; }
        public virtual double CarNconsecutivo { get; set; }
        public virtual DateTime CarFenvio { get; set; }
        public virtual string CarCidentificacion { get; set; }
        public virtual double? ParNtipoid { get; set; }
        public virtual string CarCnombre1 { get; set; }
        public virtual string CarCnombre2 { get; set; }
        public virtual string CarCapellido1 { get; set; }
        public virtual string CarCapellido2 { get; set; }
        public virtual string CarCnombre { get; set; }
        public virtual string CarCtelefono1 { get; set; }
        public virtual string CarCtelefono2 { get; set; }
        public virtual string CarCtelefono3 { get; set; }
        public virtual string CarCtelefono4 { get; set; }
        public virtual string CarCtelefono5 { get; set; }
        public virtual string CarCtelefono6 { get; set; }
        public virtual string CarCtelefono7 { get; set; }
        public virtual string CarCtelefono8 { get; set; }
        public virtual string CarCtelefono9 { get; set; }
        public virtual string CarCtelefono10 { get; set; }
        public virtual string CarCdireccion1 { get; set; }
        public virtual string CarCdireccion2 { get; set; }
        public virtual string CarCdireccion3 { get; set; }
        public virtual string CarCdireccion4 { get; set; }
        public virtual string CarCdireccion5 { get; set; }
        public virtual string CarCdireccion6 { get; set; }
        public virtual string CarCdireccion7 { get; set; }
        public virtual string CarCdireccion8 { get; set; }
        public virtual string CarCdireccion9 { get; set; }
        public virtual string CarCdireccion10 { get; set; }
        public virtual double? CarCciudad1 { get; set; }
        public virtual double? CarCciudad2 { get; set; }
        public virtual double? CarCciudad3 { get; set; }
        public virtual double? CarCciudad4 { get; set; }
        public virtual double? CarCciudad5 { get; set; }
        public virtual double? CarCciudad6 { get; set; }
        public virtual double? CarCciudad7 { get; set; }
        public virtual double? CarCciudad8 { get; set; }
        public virtual double? CarCciudad9 { get; set; }
        public virtual double? CarCciudad10 { get; set; }
        public virtual string CarCnomCiudad1 { get; set; }
        public virtual string CarCnomCiudad2 { get; set; }
        public virtual string CarCnomCiudad3 { get; set; }
        public virtual string CarCnomCiudad4 { get; set; }
        public virtual string CarCnomCiudad5 { get; set; }
        public virtual string CarCnomCiudad6 { get; set; }
        public virtual string CarCnomCiudad7 { get; set; }
        public virtual string CarCnomCiudad8 { get; set; }
        public virtual string CarCnomCiudad9 { get; set; }
        public virtual string CarCnomCiudad10 { get; set; }
        public virtual string CarCcodSucursal { get; set; }
        public virtual string CarCnomSucursal { get; set; }
        public virtual string CarCestado { get; set; }
        public virtual string UsuCasociacion { get; set; }
        public virtual DateTime? CarFasociacion { get; set; }
        public virtual string CarCasociacion { get; set; }
        public virtual double? CiuNcodigo { get; set; }
        public virtual string CarCtelext1 { get; set; }
        public virtual string CarCtelext2 { get; set; }
        public virtual string CarCtelext3 { get; set; }
        public virtual string CarCtelext4 { get; set; }
        public virtual string CarCtelext5 { get; set; }
        public virtual string CarCtelext6 { get; set; }
        public virtual string CarCtelext7 { get; set; }
        public virtual string CarCtelext8 { get; set; }
        public virtual string CarCtelext9 { get; set; }
        public virtual string CarCtelext10 { get; set; }
        public virtual string CarCperfilDoc { get; set; }
        public virtual string CarCemision { get; set; }

        public virtual IList<RcargueDireccion> RcargueDirecciones
        {
            get { return _rcargueDireccion; } 
            set { _rcargueDireccion = value;
            var query = ClaseBase.Contexto.CreateSQLQuery(
                    @"SELECT aud_cusuario, aud_ffecha, aud_cestado, rcd_ncodigo, car_ncodigo, 
                    rcd_cdireccion, rcd_cbarrio, ciu_ncodigo
                    FROM mes.rcargue_direccion where car_ncodigo =:carncodigo ");
            query.SetParameter("carncodigo", CarNcodigo);
            query.AddEntity("rcargue_direccion", typeof(RcargueDireccion));
            _rcargueDireccion = query.List<RcargueDireccion>() as List<RcargueDireccion>;
            }
        }

        public virtual IList<RcargueDocumentos> RcargueDocumentos
        {
            get { return _rcargueDocumentos; } 
            set { _rcargueDocumentos = value;
            var query = ClaseBase.Contexto.CreateSQLQuery(
                 @"SELECT crd.aud_cusuario, crd.aud_ffecha, crd.aud_cestado, crd.car_ncodigo, crd.doc_ncodigo, 
                   crd.crd_casociacion, crd.crd_cestado, crd.crd_cvista, crd.crd_creporte, crd.crd_norden, 
                   crd.car_ncodigo_origen, crd.crd_ncodigo, crd.crd_cdescripcion                     
                   FROM mes.rcargue_documentos crd
                   JOIN mes.tdocumentos doc ON doc.doc_ncodigo = crd.doc_ncodigo
                   where car_ncodigo =:carncodigo 
                   ORDER BY doc.doc_ctipo,crd.crd_norden");
            query.SetParameter("carncodigo", CarNcodigo);
            query.AddEntity("rcargue_documentos", typeof(RcargueDocumentos));
            _rcargueDocumentos = query.List<RcargueDocumentos>() as List<RcargueDocumentos>;           
            }
        }

        public virtual IList<RcargueGestion> RcargueGestiones
        {
            get { return _rcargueGestion; } 
            set { _rcargueGestion = value;
                var query = ClaseBase.Contexto.CreateSQLQuery(
                    @"SELECT aud_cusuario, aud_ffecha, aud_cestado, crg_ncodigo, trk_ncodigo, 
                    usu_ccodigo, prg_cobservacion, man_ncodigo, get_ncodigo, rem_ncodigo, 
                    car_ncodigo
                    FROM mes.rcargue_gestion where car_ncodigo =:carncodigo 
                    ORDER BY crg_ncodigo,aud_ffecha");
            query.SetParameter("carncodigo", CarNcodigo);
            query.AddEntity("rcargue_gestion", typeof(RcargueGestion));
            _rcargueGestion = query.List<RcargueGestion>() as List<RcargueGestion>;
            }
        }

        //public virtual IList<RcargueGrdoc> RcargueGrdoc { get; set; }
        public virtual IList<RcargueMedio> RcargueMedios
        {
            get { return _rcargueMedios; }
            set { _rcargueMedios = value;
            var query = ClaseBase.Contexto.CreateSQLQuery(
                    @"SELECT aud_cusuario, aud_ffecha, aud_cestado, rcm_ncodigo, car_ncodigo, 
                      med_ncodigo, rcm_casociacion, rcm_cestado, rcm_scrach, car_ncodigo_origen, 
                      rcm_nmaster, crd_ncodigo, rcm_basociacion
                      FROM mes.rcargue_medios where car_ncodigo =:carncodigo 
                      ORDER BY rcm_ncodigo");
            query.SetParameter("carncodigo", CarNcodigo);
            query.AddEntity("rcargue_medios", typeof(RcargueMedio));
            _rcargueMedios = query.List<RcargueMedio>() as List<RcargueMedio>;            
            }
        }

        public virtual IList<RcargueTelefono> RcargueTelefonos
        {
            get { return _rcargueTelefono ?? (_rcargueTelefono = new List<RcargueTelefono>()); }
            set
            {
                _rcargueTelefono = value;
                var query = ClaseBase.Contexto.CreateSQLQuery(
                    @"SELECT aud_cusuario, aud_ffecha, aud_cestado, car_ncodigo, rct_ncodigo, 
                    rct_ctelefono, rct_cextension, ciu_ncodigo, rct_ntipotel, rct_ncount_gestion, 
                    rct_ncount_virtualgestion, rct_ncontactos, rct_cestado
                   FROM mes.rcargue_telefono where car_ncodigo =:carncodigo ");
                query.SetParameter("carncodigo", CarNcodigo);
                query.AddEntity("rcargue_telefono", typeof(RcargueTelefono));
                _rcargueTelefono = query.List<RcargueTelefono>() as List<RcargueTelefono>;
            }
        }

        public virtual IList<Tcita> Tcitas
        {
            get { return _tcita ?? (_tcita= new List<Tcita>());}
            set
            {
                _tcita = value;
                var query = ClaseBase.Contexto.CreateSQLQuery(
                    @"SELECT aud_cusuario, aud_ffecha, aud_cestado, car_ncodigo, cit_ncodigo, 
                    etc_ncodigo, tci_ncodigo, rcd_ncodigo, rct_ncodigo, jor_ncodigo, 
                    cit_ffecha, cit_cobservacion, cit_ffecha_cancela, usu_cusuario_cancela, 
                    cit_ffecha_crea, cit_cusu_crea
                    FROM mes.tcita where car_ncodigo =:carncodigo 
                    ORDER BY aud_ffecha DESC");
                query.SetParameter("carncodigo", CarNcodigo);
                query.AddEntity("tcita", typeof(Tcita));
                _tcita = query.List<Tcita>() as List<Tcita>;              
            }
        }

        public virtual IList<TgestionTelefonica> TgestionesTelefonicas
        {
            get { return _tgestionTelefonica; }
            set { _tgestionTelefonica = value;
            var query = ClaseBase.Contexto.CreateSQLQuery(
                @"SELECT aud_cusuario, aud_ffecha, aud_cestado, gte_ncodigo, gte_ffecha_inicial, 
                  gte_ffecha_final, car_ncodigo, rct_ncodigo, mot_ncodigo, gte_cobservacion, 
                  cit_ncodigo
                  FROM mes.tgestion_telefonica where car_ncodigo =:carncodigo 
                  ORDER BY aud_ffecha DESC ");
            query.SetParameter("carncodigo", CarNcodigo);
            query.AddEntity("tgestion_telefonica", typeof(TgestionTelefonica));
            _tgestionTelefonica = query.List<TgestionTelefonica>() as List<TgestionTelefonica>;
            }
        }

        //public virtual IList<Tproducto> Tproducto { get; set; }
        //public virtual IList<TremisionDetalle> TremisionDetalle { get; set; }

    }
}
