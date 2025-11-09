using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class MotTelefonicosDao : ClaseBase
    {

        public IList<TmotTelefonicos> SelectMasterMotTelefonicos()
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(
                    @"SELECT 
                      tmt.aud_cusuario, 
                      tmt.aud_cestado, 
                      tmt.aud_ffecha, 
                      tmt.mot_ncodigo, 
                      tmt.mot_nmaster, 
                      tmt.mot_cdescripcion, 
                      tmt.mot_cagendamiento, 
                      tmt.eg_ccodigo
                    FROM 
                        mes.tmot_telefonicos tmt,                      
                        mes.rmottelxnegocio rtn                      
                    WHERE 
                      rtn.mot_ncodigo = tmt.mot_ncodigo AND
                      tmt.mot_nmaster=tmt.mot_ncodigo AND
                      rtn.neg_ncodigo = 1 AND
                      tmt.aud_cestado ='A' AND
                      rtn.aud_cestado ='A'
                      order by tmt.mot_ncodigo
                 ");
                query.AddEntity("tmt", typeof(TmotTelefonicos));
                return query.List<TmotTelefonicos>();
            }            
        }

        public IList<TmotTelefonicos> SelectMotTelefonicos(double motNmaster)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(
                    @"SELECT 
                      tmt.aud_cusuario, 
                      tmt.aud_cestado, 
                      tmt.aud_ffecha, 
                      tmt.mot_ncodigo, 
                      tmt.mot_nmaster, 
                      tmt.mot_cdescripcion, 
                      tmt.mot_cagendamiento, 
                      tmt.eg_ccodigo
                    FROM 
                        mes.tmot_telefonicos tmt,                      
                        mes.rmottelxnegocio rtn                       
                    WHERE 
                      rtn.mot_ncodigo = tmt.mot_ncodigo AND
                      tmt.mot_nmaster<>tmt.mot_ncodigo AND
                      rtn.neg_ncodigo = 1 AND                      
                      tmt.mot_nmaster = :motnmaster AND
                      tmt.aud_cestado ='A' AND
                      rtn.aud_cestado ='A'
                      order by tmt.mot_ncodigo
                 ");
                query.SetParameter("motnmaster", motNmaster);
                query.AddEntity("tmt", typeof(TmotTelefonicos));
                return query.List<TmotTelefonicos>();
            }
        }

    }
}
