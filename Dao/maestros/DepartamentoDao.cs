using System.Collections.Generic;
using Reines.dmsflex.Dao.mes;


namespace Reines.dmsflex.Dao.maestros
{
    public class DepartamentoDao : ClaseBase
    {

        public IList<Pdepartamento> SelectAllDepartamentos()
        {
            using (new UnitOfWorkScope(false))
            {
                return Contexto.CreateCriteria<Pdepartamento>().List<Pdepartamento>();
            }            
        }

    }
}