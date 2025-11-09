using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class JornadaDao : ClaseBase
    {

        public IList<Pjornada> SelectAllJornadas()
        {
            using (new UnitOfWorkScope(false))
            {
                const string sqljornada = "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where jor_ncodmaster <> jor_ncodigo order by jor_dinicio";
                var query = Contexto.CreateSQLQuery(sqljornada);
                query.AddEntity("pjornada", typeof(Pjornada));
                return query.List<Pjornada>();
            }            
        }

        public IList<Pjornada> SelectAllJornadas(Pcalendario pcalendario, double ciuNcodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var vlDia=DateTime.ParseExact(pcalendario.CalCobservacion, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                var dia = vlDia.DayOfWeek;
                string sqljornada;
                switch (dia)
                {
                    case DayOfWeek.Sunday:
                        sqljornada =
                            "SELECT rcc_cdom as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Monday:
                        sqljornada =
                            "SELECT rcc_clun as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Tuesday:
                        sqljornada =
                            "SELECT rcc_cmar as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Wednesday:
                        sqljornada =
                            "SELECT rcc_cmie as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Thursday:
                        sqljornada =
                            "SELECT rcc_cjue as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Friday:
                        sqljornada =
                            "SELECT rcc_cvie as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    case DayOfWeek.Saturday:
                        sqljornada =
                            "SELECT rcc_csab as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                    default:
                        sqljornada = "SELECT 'T' as jornada FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo";
                        break;
                }

                var siglajornada =
                    Contexto.CreateSQLQuery(sqljornada);
                siglajornada.AddScalar("jornada", NHibernate.NHibernateUtil.String);
                siglajornada.SetParameter("pciuncodigo", ciuNcodigo);
                var jornada = siglajornada.List()[0].ToString();
                switch (jornada)
                {
                    case "T":
                        sqljornada =
                            "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where jor_ncodmaster <>jor_ncodigo order by jor_dinicio";
                        break;
                    case "A":
                        sqljornada =
                            "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where jor_ncodmaster = 0 and jor_ncodmaster <>jor_ncodigo order by jor_dinicio";
                        break;
                    case "P":
                        sqljornada =
                            "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where jor_ncodmaster = 1 and jor_ncodmaster <> jor_ncodigo order by jor_dinicio";
                        break;
                    case "N":
                        sqljornada =
                            "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where 1=2";
                        break;
                    default:
                        sqljornada =
                            "SELECT jor_ncodigo, jor_cnombre, jor_dinicio, jor_dfin, jor_ncodmaster FROM mes.pjornada where 1=2";
                        break;
                }

                var query = Contexto.CreateSQLQuery(sqljornada);
                query.AddEntity("pjornada", typeof (Pjornada));
                return query.List<Pjornada>();
            }
        }


        public IList<Pcalendario> SelectAllFechas(double sedNcodigo, double ciuNcodigo)
        {

            var esTraslado = EsTraslado(sedNcodigo, ciuNcodigo);

            using (new UnitOfWorkScope(false))
            {
                var seqDiasDisponibles =
                    Contexto.CreateSQLQuery(@"SELECT 
                               trim(case when rcc_clun <>'N' then '2 ' else '' end || case when rcc_cmar <>'N' then '3 ' else '' end || case when rcc_cmie <>'N' then '4 ' else '' end
                               || case when rcc_cjue <>'N' then '5 ' else '' end || case when rcc_cvie <>'N' then '6 ' else '' end
                               || case when rcc_csab <>'N' then '7 ' else '' end || case when rcc_cdom <>'N' then '1' else '' end) as lista
                          FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo")
                            .AddScalar("lista", NHibernate.NHibernateUtil.String)
                            .SetParameter("pciuncodigo", ciuNcodigo)
                            .List();

                var cadenadias = " ";
                if (seqDiasDisponibles.Count > 0)
                {
                    cadenadias = seqDiasDisponibles[0].ToString();
                }

                if (esTraslado)
                {
                    const string sql =
                        @"SELECT  n as cal_ncodigo,
                                  now() + (n*interval '1 day') as cal_ffecha,
                                  to_char(now() + (n*interval '1 day'),'yyyy-mm-dd') as cal_cobservacion
                      FROM mes.vi_seqdia15,(select regexp_split_to_table(:cadenadias, E'\\s+') as diasd) as cober
                      where to_char(now() + (n*interval '1 day'),'D') = cober.diasd and
                      cast((now() + (n*interval '1 day')) as date) not in (select fes_ffecha from mes.pfestivos) and
                      (now() + (n*interval '1 day')) > (now() + (interval '1 day'))
                      order by 1";

                    var query = Contexto.CreateSQLQuery(sql);
                    query.SetParameter("cadenadias", cadenadias);
                    query.AddEntity("t", typeof(Pcalendario));
                    return query.List<Pcalendario>();
                }
                else
                {
                    const string sql =
                        @"SELECT  n as cal_ncodigo ,now() + (n*interval '1 day') as cal_ffecha, to_char(now() + (n*interval '1 day'),'yyyy-mm-dd') as cal_cobservacion
                      FROM mes.vi_seqdia15,(select regexp_split_to_table(:cadenadias, E'\\s+') as diasd) as cober
                      where to_char(now() + (n*interval '1 day'),'D') = cober.diasd and
                      cast ((now() + (n*interval '1 day')) as date) not in (select fes_ffecha from mes.pfestivos)
                      order by 1";

                    var query = Contexto.CreateSQLQuery(sql);
                    query.SetParameter("cadenadias", cadenadias);
                    query.AddEntity("t", typeof(Pcalendario));
                    return query.List<Pcalendario>();    
                }                

            }
        }


        private bool EsTraslado(double sedNcodigo, double ciuNcodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var sqlSucursalDestino = Contexto.CreateSQLQuery(@"SELECT  sed_ncodigo FROM mes.rred_mens_detalle WHERE ciu_ncodigo =:pciuncodigo")                         
                                                 .AddScalar("sed_ncodigo", NHibernate.NHibernateUtil.String)
                                                 .SetParameter("pciuncodigo", ciuNcodigo)
                                                 .List();
                if (sqlSucursalDestino.Count > 0)
                {
                    var sededest = Double.Parse(sqlSucursalDestino[0].ToString());
                    if (Math.Abs(sedNcodigo - sededest) != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public IList<Pcalendario> SelectAllFechas(double ciuNcodigo)
        {

            using (new UnitOfWorkScope(false))
            {
                var seqDiasDisponibles =
                    Contexto.CreateSQLQuery(@"SELECT 
                               trim(case when rcc_clun <>'N' then '2 ' else '' end || case when rcc_cmar <>'N' then '3 ' else '' end || case when rcc_cmie <>'N' then '4 ' else '' end
                               || case when rcc_cjue <>'N' then '5 ' else '' end || case when rcc_cvie <>'N' then '6 ' else '' end
                               || case when rcc_csab <>'N' then '7 ' else '' end || case when rcc_cdom <>'N' then '1' else '' end) as lista
                          FROM mes.rred_mens_detalle where ciu_ncodigo =:pciuncodigo")
                            .AddScalar("lista", NHibernate.NHibernateUtil.String)
                            .SetParameter("pciuncodigo", ciuNcodigo)
                            .List();

                var cadenadias = " ";
                if (seqDiasDisponibles.Count > 0)
                {
                    cadenadias = seqDiasDisponibles[0].ToString();
                }

                const string sql =
                    @"SELECT  n as cal_ncodigo ,now() + (n*interval '1 day') as cal_ffecha, to_char(now() + (n*interval '1 day'),'yyyy-mm-dd') as cal_cobservacion
                      FROM mes.vi_seqdia15,(select regexp_split_to_table(:cadenadias, E'\\s+') as diasd) as cober
                      where to_char(now() + (n*interval '1 day'),'D') = cober.diasd and
                      (now() + (n*interval '1 day')) not in (select fes_ffecha from mes.pfestivos)
                      order by 1";

                var query = Contexto.CreateSQLQuery(sql);
                query.SetParameter("cadenadias", cadenadias);
                query.AddEntity("t", typeof (Pcalendario));
                return query.List<Pcalendario>();

            }
        }
        
    }
}
