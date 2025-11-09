using System;
using System.Collections.Generic;
using NHibernate.Type;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class OrdenesDao : ClaseBase
    {
        protected IList<Torden> SelectOrdenes()
        {
            using (new UnitOfWorkScope(false))
            {
                var list = Contexto.QueryOver<Torden>()
                                   .JoinQueryOver(torden => torden.Tnegocio)
                                   .JoinQueryOver(tnegocio => tnegocio.Tcliente)
                                   .List();
                return list; //Contexto.CreateCriteria<Torden>().List<Torden>();
            }            
        }

        public double NextVal()
        {
            var seqCconsecutivo =
                Contexto.CreateSQLQuery(@"select nextval from nextval('mes.seq_orden')")
                        .AddScalar("nextval", new DoubleType())
                        .List();
            return Double.Parse(seqCconsecutivo[0].ToString());
        }


        public double CfNextVal()
        {
            var seqCconsecutivo =
                Contexto.CreateSQLQuery(@"select nextval from nextval('mes.seq_carguefisico')")
                        .AddScalar("nextval", new DoubleType())
                        .List();
            return Double.Parse(seqCconsecutivo[0].ToString());
        }


        public double Executepr_simes0001(double pNordcodigo)
        {
            /*
            var helper = new NpgsqlHelper();
            helper.ClearSqlCommandParameter();
            helper.AddInParameterToSqlCommand("p_nordcodigo", NpgsqlDbType.Numeric, pNordcodigo);            
            helper.GetExecuteNonQueryByCommand(Contexto, "mes.pr_simes0001");
            */
            var d = (decimal) pNordcodigo;
            var query = Contexto.CreateSQLQuery(@"select mes.pr_simes0001(:p0)")
                                .SetDecimal("p0", d)
                                .List();
            return query.Count;
            //return 1;
        }
    }
}