using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class NegocioDao : ClaseBase
    {
        public IList<Tnegocio> SelectNegocios()
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_cusuario, aud_cestado, aud_ffecha, neg_ncodigo, neg_cnombre,
                                                    cli_ncodigo
                                                    FROM mes.tnegocio
                                                    where cli_ncodigo =1 and neg_ncodigo = 1
                 ");
                query.AddEntity("tnegocio", typeof(Tnegocio));
                return query.List<Tnegocio>();
            }
        }

        public IList<Tnegocio> SelectNegocios(int negNcodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_cusuario, aud_cestado, aud_ffecha, neg_ncodigo, neg_cnombre,
                                                    cli_ncodigo
                                                    FROM mes.tnegocio
                                                    where cli_ncodigo =1 and neg_ncodigo = :negNcodigo
                 ");
                query.SetParameter("negNcodigo", negNcodigo);
                query.AddEntity("tnegocio", typeof(Tnegocio));
                return query.List<Tnegocio>();
            }
        }

    }
}
