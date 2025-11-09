using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class TipoCitaDao :ClaseBase
    {

        protected IList<PtipoCita> SelectAllCitas()
        {
            using (new UnitOfWorkScope(false))
            {
                return Contexto.CreateCriteria<PtipoCita>().List<PtipoCita>();
            }            
        }

    }
}
