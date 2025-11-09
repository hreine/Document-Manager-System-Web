using System.Collections.Generic;
using Reines.dmsflex.Dao.mes;


namespace Reines.dmsflex.Dao.maestros
{
    public class CiudadDao : ClaseBase
    {
        protected IList<Pciudad> SelectAllCiudades()
        {
            using (new UnitOfWorkScope(false))
            {
                return Contexto.CreateCriteria<Pciudad>().List<Pciudad>();
            }            
        }


        public IList<Pciudad> SelectCiudades()
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT 
                                                      ciu.aud_cusuario, 
                                                      ciu.aud_cestado, 
                                                      ciu.aud_ffecha, 
                                                      ciu.ciu_ncodigo, 
                                                      ciu.ciu_cnombre, 
                                                      ciu.dep_ncodigo, 
                                                      ciu.ciu_csigla, 
                                                      ciu.ciu_cdane, 
                                                      ciu.ciu_ncentro
                                                    FROM 
                                                      mes.pciudad ciu, 
                                                      mes.pred_mensajeria pdm, 
                                                      mes.rred_mens_detalle rmd
                                                    WHERE 
                                                      ciu.ciu_ncodigo = rmd.ciu_ncodigo AND
                                                      pdm.rdm_ncodigo = rmd.rdm_ncodigo AND
                                                      pdm.rdm_ncodigo = 0
                 ");
                query.AddEntity("ciu", typeof(Pciudad));
                return query.List<Pciudad>();
            }  
        }
    }
}