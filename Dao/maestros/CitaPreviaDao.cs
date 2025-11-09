using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class CitaPreviaDao : ClaseBase
    {

        public IList<TcitaPrevia> SelectAllCitaPrevia()
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_ffecha, aud_cestado, aud_cusuario, cpr_ncodigo, neg_ncodigo, 
                                                    cpr_ccedula, cpr_cnmbtit, cpr_ctelefono, cpr_ndireccion, ciu_ncodigo, 
                                                    cpr_ffecha, jor_ncodigo, cpr_cobservacion, etc_ncodigo
                                                FROM mes.tcita_previa
                                                WHERE neg_ncodigo = :old_neg_ncodigo and 
                                                      etc_ncodigo = :old_etc_ncodigo and 
                                                      aud_cestado = :old_aud_cestado
                 ");
                query.SetParameter("old_neg_ncodigo", 1);
                query.SetParameter("old_etc_ncodigo", 1);
                query.SetParameter("old_aud_cestado", "A", NHibernate.NHibernateUtil.String);
                query.AddEntity("tcita_previa", typeof(TcitaPrevia));
                return query.List<TcitaPrevia>();
            }
        }


        public IList<TcitaPrevia> SelectCitaPreviaPorFechaCedula(TcitaPrevia tcitaPrevia)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_ffecha, aud_cestado, aud_cusuario, cpr_ncodigo, neg_ncodigo, 
                                                    cpr_ccedula, cpr_cnmbtit, cpr_ctelefono, cpr_ndireccion, ciu_ncodigo, 
                                                    cpr_ffecha, jor_ncodigo, cpr_cobservacion, etc_ncodigo
                                                FROM mes.tcita_previa
                                                WHERE neg_ncodigo = :new_neg_ncodigo and etc_ncodigo = :new_etc_ncodigo and aud_cestado ='A' and 
                                                cpr_ccedula=:new_cpr_ccedula and cpr_ffecha =:new_cpr_ffecha and ciu_ncodigo=:new_ciu_ncodigo
                 ");

                query.SetParameter("new_neg_ncodigo", 1);
                query.SetParameter("new_etc_ncodigo", 1);

                query.SetParameter("new_cpr_ccedula", tcitaPrevia.CprCcedula,NHibernate.NHibernateUtil.String);
                query.SetParameter("new_cpr_ffecha", tcitaPrevia.CprFfecha,NHibernate.NHibernateUtil.Date);
                query.SetParameter("new_ciu_ncodigo", tcitaPrevia.Pciudad.CiuNcodigo);
                
                query.AddEntity("tcita_previa", typeof(TcitaPrevia));
                return query.List<TcitaPrevia>();
            }
        }

        protected int Insert(TcitaPrevia tcitaPrevia)
        {
            using (new UnitOfWorkScope(false))
            {
                const string qryText =
                    @"INSERT INTO mes.tcita_previa(
                    aud_ffecha, aud_cestado, aud_cusuario, cpr_ncodigo, neg_ncodigo, 
                    cpr_ccedula, cpr_cnmbtit, cpr_ctelefono, cpr_ndireccion, ciu_ncodigo, 
                    cpr_ffecha, jor_ncodigo, cpr_cobservacion, etc_ncodigo)
                    VALUES (now(), 'A', :new_aud_cusuario, nextval('mes.seq_citaprevia'), :new_neg_ncodigo,
                    :new_cpr_ccedula, :new_cpr_cnmbtit, :new_cpr_ctelefono, :new_cpr_ndireccion, :new_ciu_ncodigo, 
                    :new_cpr_ffecha, :new_jor_ncodigo, :new_cpr_cobservacion, :new_etc_ncodigo)
                    ";
                var query = Contexto.CreateSQLQuery(qryText);
                query.SetParameter("new_aud_cusuario", tcitaPrevia.AudCusuario);
                query.SetParameter("new_neg_ncodigo", tcitaPrevia.Tnegocio.NegNcodigo);

                query.SetParameter("new_cpr_ccedula", tcitaPrevia.CprCcedula);
                query.SetParameter("new_cpr_cnmbtit", tcitaPrevia.CprCnmbtit);
                query.SetParameter("new_cpr_ctelefono", tcitaPrevia.CprCtelefono);
                query.SetParameter("new_cpr_ndireccion", tcitaPrevia.CprNdireccion);
                query.SetParameter("new_ciu_ncodigo", tcitaPrevia.Pciudad.CiuNcodigo);

                query.SetParameter("new_cpr_ffecha", tcitaPrevia.CprFfecha);
                query.SetParameter("new_jor_ncodigo", tcitaPrevia.Pjornada.JorNcodigo);
                query.SetParameter("new_cpr_cobservacion", tcitaPrevia.CprCobservacion);
                query.SetParameter("new_etc_ncodigo", tcitaPrevia.PestCita.EtcNcodigo);

                return query.ExecuteUpdate();                 
            }
        }


        protected int Update(TcitaPrevia tcitaPrevia)
        {
            using (new UnitOfWorkScope(false))
            {
                const string qryText =
                    @"UPDATE 
                      mes.tcita_previa 
                    SET 
                      aud_ffecha = now(),
                      aud_cestado = :new_aud_cestado,
                      aud_cusuario = :new_aud_cusuario,
                      neg_ncodigo = :new_neg_ncodigo,
                      cpr_ccedula = :new_cpr_ccedula,
                      cpr_cnmbtit = :new_cpr_cnmbtit,
                      cpr_ctelefono = :new_cpr_ctelefono,
                      cpr_ndireccion = :new_cpr_ndireccion,
                      ciu_ncodigo = :new_ciu_ncodigo,
                      cpr_ffecha = :new_cpr_ffecha,
                      jor_ncodigo = :new_jor_ncodigo,
                      cpr_cobservacion = :new_cpr_cobservacion,
                      etc_ncodigo = :new_etc_ncodigo
                    WHERE 
                      cpr_ncodigo = :new_cpr_ncodigo
                    ";
                var query = Contexto.CreateSQLQuery(qryText);

                query.SetParameter("new_cpr_ncodigo", tcitaPrevia.CprNcodigo);
                query.SetParameter("new_aud_cestado", tcitaPrevia.AudCestado);
                query.SetParameter("new_aud_cusuario", tcitaPrevia.AudCusuario);
                query.SetParameter("new_neg_ncodigo", tcitaPrevia.Tnegocio.NegNcodigo);
                query.SetParameter("new_cpr_ccedula", tcitaPrevia.CprCcedula);
                query.SetParameter("new_cpr_cnmbtit", tcitaPrevia.CprCnmbtit);
                query.SetParameter("new_cpr_ctelefono", tcitaPrevia.CprCtelefono);
                query.SetParameter("new_cpr_ndireccion", tcitaPrevia.CprNdireccion);
                query.SetParameter("new_ciu_ncodigo", tcitaPrevia.Pciudad.CiuNcodigo);
                query.SetParameter("new_cpr_ffecha", tcitaPrevia.CprFfecha);
                query.SetParameter("new_jor_ncodigo", tcitaPrevia.Pjornada.JorNcodigo);
                query.SetParameter("new_cpr_cobservacion", tcitaPrevia.CprCobservacion);
                query.SetParameter("new_etc_ncodigo", tcitaPrevia.PestCita.EtcNcodigo);

                return query.ExecuteUpdate();
            }
        }
        
    }
}
