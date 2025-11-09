using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Npgsql;
using NpgsqlTypes;
using Reines.DB;
using Reines.dmsflex.Dao.mes;
using Reines.utils;


namespace Reines.dmsflex.Dao.maestros
{
    public class UsuariosDao : ClaseBase
    {


        public NpgsqlDataReader Prueba()
        {
            var helper = new NpgsqlHelper("simesstr");
            helper.BeginTransaction();
            try
            {
                helper.ClearSqlCommandParameter();
                var ds = helper.GetReaderByCmd("mes.show_cities");
                //helper.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                helper.RollBack();
                throw new Exception(Excepciones.Extraemensaje(ex.Message), ex);
            }

            //mes.show_cities
        }




        public List<Pmenu> GetOpcionesxCategorias(string usuCCodigo, double cliNcodigo, string menCcategoria)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery("SELECT distinct " +
                                                    "pmenu.men_ncodigo, " +
                                                    "pmenu.men_cnombre, " +
                                                    "pmenu.men_cdescripcion, " +
                                                    "pmenu.men_ctxtayuda, " +
                                                    "pmenu.men_ccategoria, " +
                                                    "pmenu.men_ctipo " +
                                                    "FROM  " +
                                                    "mes.pmenu,  " +
                                                    "mes.tusuario,  " +
                                                    "mes.tusugrupo,  " +
                                                    "mes.rusuario_grupo,  " +
                                                    "mes.rgrupo_menu " +
                                                    "WHERE " +
                                                    "tusuario.usu_ccodigo = rusuario_grupo.usu_ccodigo AND " +
                                                    "tusugrupo.gru_ncodigo = rgrupo_menu.gru_ncodigo AND " +
                                                    "rusuario_grupo.gru_ncodigo = tusugrupo.gru_ncodigo AND " +
                                                    "rgrupo_menu.men_ncodigo = pmenu.men_ncodigo AND " +
                                                    "mes.pmenu.men_ctipo  ='WB' and          " +
                                                    "mes.pmenu.men_ccategoria = :menccategoria and " +
                                                    "mes.tusuario.usu_ccodigo = :usuccodigo ");
                query.AddEntity("pmenu", typeof (Pmenu));
                query.SetParameter("menccategoria", menCcategoria);
                query.SetParameter("usuccodigo", usuCCodigo);
                return query.List<Pmenu>() as List<Pmenu>;
            }
        }


        public List<Pmenu> Getmenus(string usuCCodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery("SELECT distinct " +
                                                    "pmenu.men_ncodigo, " +
                                                    "pmenu.men_cnombre, " +
                                                    "pmenu.men_cdescripcion, " +
                                                    "pmenu.men_ctxtayuda, " +
                                                    "pmenu.men_ccategoria, " +
                                                    "pmenu.men_ctipo " +
                                                    "FROM  " +
                                                    "mes.pmenu,  " +
                                                    "mes.tusuario,  " +
                                                    "mes.tusugrupo,  " +
                                                    "mes.rusuario_grupo,  " +
                                                    "mes.rgrupo_menu " +
                                                    "WHERE " +
                                                    "tusuario.usu_ccodigo = rusuario_grupo.usu_ccodigo AND " +
                                                    "tusugrupo.gru_ncodigo = rgrupo_menu.gru_ncodigo AND " +
                                                    "rusuario_grupo.gru_ncodigo = tusugrupo.gru_ncodigo AND " +
                                                    "rgrupo_menu.men_ncodigo = pmenu.men_ncodigo AND " +
                                                    "mes.pmenu.men_ctipo  ='WB' and          " +
                                                    "tusuario.usu_ccodigo = :usuccodigo order by pmenu.men_ncodigo");
                query.AddEntity("pmenu", typeof (Pmenu));
                query.SetParameter("usuccodigo", usuCCodigo);

                return query.List<Pmenu>() as List<Pmenu>;
            }
        }


        public List<Pmenu> Getcategorias(string usuCCodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery("SELECT " +
                                                    " men.men_ncodigo, " +
                                                    " men.men_cnombre, " +
                                                    " men.men_cdescripcion, " +
                                                    " men.men_ctxtayuda, " +
                                                    " men.men_ccategoria, " +
                                                    " men.men_ctipo " +
                                                    "FROM  " +
                                                    "mes.menu_categoria men " +
                                                    "WHERE " +
                                                    "men.usu_ccodigo = :usuccodigo ");
                query.AddEntity("men", typeof (Pmenu));
                query.SetParameter("usuccodigo", usuCCodigo);
                return query.List<Pmenu>() as List<Pmenu>;
                //return query.SetResultTransformer(Transformers.AliasToBean(typeof(Pmenu))).List<Pmenu>() as List<Pmenu>;
            }
        }


        public List<Tusuario> FetchByIdFormActive(string usuario)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateQuery("from Tusuario where usu_ccodigo = :usuccodigo ");
                query.SetParameter("usuccodigo", usuario);
                return query.List<Tusuario>() as List<Tusuario>;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="venceClave"></param>
        /// <returns></returns>
        public DateTime GetUltimaCambio(string usuario,int venceClave)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery("SELECT case when max(aud_ffecha) is not null then max(aud_ffecha) else (now()- INTERVAL '" + venceClave + " day')  end as ultimocambio FROM mes.hcontrasenas WHERE usu_ccodigo = :usuccodigo");
                query.SetParameter("usuccodigo", usuario);
                return query.UniqueResult<DateTime>();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuCcodigo">Nombre de usuario</param>
        /// <param name="password">Contraseña actual </param>
        /// <param name="newpassword">Nueva contraseña</param>
        /// <returns></returns>
        protected bool UpdatePasword(string usuCcodigo, string password, string newpassword)
        {
            using (new UnitOfWorkScope(false))
            {
                var transaccion = Contexto.BeginTransaction();
                try
                {
                    const string qryText1 =
                        "UPDATE mes.tusuario SET usu_cclave = :newpassword ,usu_cobliga = 'N', aud_ffecha = now() WHERE usu_ccodigo = :usuCcodigo and  usu_cclave= :password";
                    var query1 = Contexto.CreateSQLQuery(qryText1);
                    query1.SetParameter("usuCcodigo", usuCcodigo);
                    query1.SetParameter("password", password);
                    query1.SetParameter("newpassword", newpassword);
                    if (query1.ExecuteUpdate() > 0)
                    {
                        const string qryText2 =
                            "INSERT INTO mes.hcontrasenas(aud_cusuario, aud_cestado, aud_ffecha, hco_ncodigo, usu_ccodigo,usu_cclave) VALUES (:usuCcodigo, 'A', now(), nextval('mes.seq_hcontrasenas'), :usuCcodigo,:newpassword)";
                        var query2 = Contexto.CreateSQLQuery(qryText2);
                        query2.SetParameter("usuCcodigo", usuCcodigo);
                        query2.SetParameter("newpassword", newpassword);
                        query2.ExecuteUpdate();
                        transaccion.Commit();
                        return true;
                    }
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
                return false;
            }
        }


        public bool RegistraIngreso(string usuCcodigo, string audCdirip)
        {
            using (new UnitOfWorkScope(false))
            {
                const string qryText1 =
                    "INSERT INTO mes.haccesos(aud_cusuario, aud_cestado, aud_ffecha, aud_cdirip, hac_ncodigo, usu_ccodigo, hac_ctipo, hac_capp) VALUES (:usuCcodigo,'A', now(), :audCdirip, nextval('mes.seq_haccesos'), :usuCcodigo, 'E', 'DMS-WEB')";
                var query1 = Contexto.CreateSQLQuery(qryText1);
                query1.SetParameter("usuCcodigo", usuCcodigo);
                query1.SetParameter("audCdirip", audCdirip);
                return query1.ExecuteUpdate()>0;
            }
        }

        public bool RegistraSalida(string usuCcodigo, string audCdirip)
        {
            using (new UnitOfWorkScope(false))
            {
                const string qryText1 =
                    "INSERT INTO mes.haccesos(aud_cusuario, aud_cestado, aud_ffecha, aud_cdirip, hac_ncodigo, usu_ccodigo, hac_ctipo, hac_capp) VALUES (:usuCcodigo,'A', now(), :audCdirip, nextval('mes.seq_haccesos'), :usuCcodigo, 'S', 'DMS-WEB')";
                var query1 = Contexto.CreateSQLQuery(qryText1);
                query1.SetParameter("usuCcodigo", usuCcodigo);
                query1.SetParameter("audCdirip", audCdirip);
                return query1.ExecuteUpdate() > 0;
            }
        }

        
            public
            string Login(string usuario, string contrasena)
        {
            using (new UnitOfWorkScope(false))
            {
                var usuarios = Contexto.CreateCriteria<Tusuario>().AddOrder(Order.Asc("UsuCnombre")).List<Tusuario>();
                return usuarios[0].UsuCcodigo;
            }            
        }


/*
        public string Login(string usuario, string contrasena, out string roll)
        {
            using (new UnitOfWorkScope(false))
            {
                roll = string.Empty;
                try
                {
                    var vardomain = usuario.Split('@');
                    List<Tusuario> usuarios = null;
                    if (vardomain.Length == 1)
                    {
                        usuarios = FetchByIdFormActive(usuario.ToLower());
                        if (usuarios.Count == 0)
                        {
                            //Setsession(usuario, "*", (int)Motivos.Usuarionoexiste, 0, 0);
                            return Mensajemotivos(Motivos.Usuarionoexiste);
                        }

                        //se compara el hash de las dos maneras; para conservar la compativilidad con md5 hasta que la persona cambie la contraseña
                        if (usuarios[0].USU_CCLAVEN.ToUpper() != GetSha512(contrasena).ToUpper() &&
                            usuarios[0].USU_CCLAVEN.ToUpper() != ObtenerMd5(contrasena).ToUpper())
                        {
                            usuarios[0].USU_NINTENTOS = usuarios[0].USU_NINTENTOS + 1;
                            Contexto.SaveChanges();
                            if (usuarios[0].USU_NINTENTOS >= _maxIntentos)
                            {
                                if (usuarios[0].DPE_NCODIGO != 10)
                                    usuarios[0].USU_CINHABILITA = "S";
                                usuarios[0].USU_NINTENTOS = 0;
                                usuarios[0].PAR_NMOTIVO = (int)Motivos.Maxnumintentos;
                                Contexto.SaveChanges();
                                Setsession(usuario, "*", (int)Motivos.Maxnumintentos, usuarios[0].SED_NCODIGO,
                                           (decimal)usuarios[0].DPE_NCODIGO);
                                return (Mensajemotivos(Motivos.Maxnumintentos, _maxIntentos));
                            }
                            return (Mensajemotivos(Motivos.Contrasenaerrada));
                        }

                        if (usuarios[0].USU_CINHABILITA.Trim() == "S")
                        {
                            Setsession(usuario, "*", (int)usuarios[0].PAR_NMOTIVO, usuarios[0].SED_NCODIGO,
                                       (decimal)usuarios[0].DPE_NCODIGO);
                            return (Mensajemotivos((Motivos)usuarios[0].PAR_NMOTIVO));
                        }

                        var tiemposiningresar = TimeSpan.Zero;
                        if (usuarios[0].USU_FULTIMO_INGRESO != null)
                            tiemposiningresar = (TimeSpan)(_ahora - usuarios[0].USU_FULTIMO_INGRESO);

                        if (tiemposiningresar.Hours > (MaxTiempoSinIngresar * 24))
                        {
                            if (usuarios[0].DPE_NCODIGO != 10)
                                usuarios[0].USU_CINHABILITA = "S";
                            usuarios[0].PAR_NMOTIVO = (int)Motivos.Tiemposiningresar;
                            Contexto.SaveChanges();
                            Setsession(usuario, "*", (int)Motivos.Tiemposiningresar, usuarios[0].SED_NCODIGO,
                                       (decimal)usuarios[0].DPE_NCODIGO);
                            return (Mensajemotivos(Motivos.Tiemposiningresar, (MaxTiempoSinIngresar * 24)));
                        }

                        var tiemposincambio = (TimeSpan)(_ahora - usuarios[0].USU_FULTIMO_CAMBIO);
                        if (tiemposincambio.Hours > (VenceClave * 24))
                        {
                            if (usuarios[0].DPE_NCODIGO != 10)
                                usuarios[0].USU_CINHABILITA = "S";
                            usuarios[0].PAR_NMOTIVO = (int)Motivos.Cambiarcontrasena;
                            Contexto.SaveChanges();
                            Setsession(usuario, "*", (int)Motivos.Cambiarcontrasena, usuarios[0].SED_NCODIGO,
                                       (decimal)usuarios[0].DPE_NCODIGO);
                            return (Mensajemotivos(Motivos.Cambiarcontrasena, (VenceClave * 24)));
                        }
                    }
                    else if (vardomain.Length == 2)
                    {
                        var client = new AdmangerService.AdmangerSvrClient();
                        var isValid = client.ValidateCredentials(usuario, contrasena);
                        if (isValid == false)
                        {
                            Setsession(usuario, "*", (int)Motivos.Contrasenaerrada, 0, 0);
                            return (Mensajemotivos(Motivos.Contrasenaerrada));
                        }
                        usuarios = FetchByIdFormActiveDomain(vardomain[0]);
                        if (usuarios.Count == 0)
                        {
                            Setsession(usuario, "*", (int)Motivos.Usuarionoexiste, 0, 0);
                            return Mensajemotivos(Motivos.Usuarionoexiste);
                        }
                        usuarios[0].USU_CCLAVEN = GetSha512(contrasena).ToUpper();
                    }
                    else
                    {
                        Setsession(usuario.Substring(0, 30), "*", (int)Motivos.Usuarionoexiste, 0, 0);
                        return Mensajemotivos(Motivos.Usuarionoexiste);
                    }

                    if (usuarios[0].USU_CTGROL == null)
                    {
                        Setsession(usuario, "*", (int)Motivos.Usuarionoexiste, usuarios[0].SED_NCODIGO,
                                   (decimal)usuarios[0].DPE_NCODIGO);
                        return (Mensajemotivos(Motivos.Usuarionoexiste));
                    }

                    roll = usuarios[0].USU_CTGROL;
                    usuarios[0].PAR_NMOTIVO = -1;
                    usuarios[0].USU_CINHABILITA = "N";
                    usuarios[0].USU_NINTENTOS = 0;
                    usuarios[0].USU_FULTIMO_INGRESO = DateTime.Now;
                    usuarios[0].AUD_FFECHA = DateTime.Now;
                    Contexto.SaveChanges();

                    //-----------------------------------------------------//
                    var ip = HttpContext.Current.Request.UserHostAddress;
                    var sede = Ususede.FetchByID(usuarios[0].SED_NCODIGO)[0];
                    if (roll == "ROOT" && sede.CliNcodigo == 0)
                    {
                        //no valide nada
                    }
                    else if (Allowip(sede.CliNcodigo, ip) == false)
                    {
                        Setsession(usuario, "*", (int)Motivos.IpnoPermitida, usuarios[0].SED_NCODIGO,
                                   (decimal)usuarios[0].DPE_NCODIGO);
                        return (Mensajemotivos(Motivos.IpnoPermitida));
                    }
                    //-----------------------------------------------------//                                
                }
                catch (SecurityException ex)
                {
                    if (ex.Message != null)
                    {
                        return ex.Message;
                    }
                }
                return "";
            }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuCnombre"></param>
        /// <returns></returns>
        public IList<Tusuario> GetUsuario(string usuCnombre)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateCriteria<Tusuario>().AddOrder(Order.Asc("UsuCnombre"));
                var res = query.List<Tusuario>();
                return res;
            }


            /*
    ClearSqlCommandParameter();
    var result = GetReaderBySql("select * from mes.tusuario");
    // AddInParameterToSqlCommand("usu_ccodigo",NpgsqlDbType.Varchar,usuCnombre);
    result = result;
    */

            //var session = NHibernateHelper.OpenSession();
            //var connt=session.Connection;            
            //var query = session.CreateCriteria<Tusuario>().AddOrder(Order.Asc("UsuCnombre"));
            /*                                              
            var ciudad = new Tusuario()
                {
                    UsuCcodigo = "ADMIN"
                };

            var tx = session.BeginTransaction();
            session.Save(ciudad);
            tx.Commit();            
            */
        }

        public IList<Tusuario> GetUsuarios()
        {
            // var result =GetReaderBySql("select * from mes.tusuario");
            //result = result;

            /*           
            var session = NHibernateHelper.OpenSession();
            var connt=session.Connection;            
            var ciudad = new Tusuario()
                {
                    UsuCcodigo = "ADMIN"
                };
            var tx = session.BeginTransaction();
            session.Save(ciudad);
            tx.Commit();            
            var query = session.CreateCriteria<Tusuario>().AddOrder(Order.Asc("usu_cnombre"));
            */
            return new List<Tusuario>();
        }
    }
}