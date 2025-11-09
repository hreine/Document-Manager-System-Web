using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class BrandersDao : ClaseBase
    {

        public IList<Tbrander> SelectAllBranders(int negNcodigo)
        {

            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@" SELECT aud_ffecha, aud_cestado, aud_cusuario, bra_ncodigo, neg_ncodigo, 
                                                       bra_ccedula, bra_cnmbtit, bra_ccelular, bra_ctelefono, bra_cdireccion, 
                                                       ciu_ncodigo, bra_ffecha, jor_ncodigo, bra_cobservacion, etc_ncodigo, 
                                                       bra_cactividad_economica, bra_cconvenio
                                                FROM mes.tbrander
                                                WHERE neg_ncodigo = :old_neg_ncodigo and 
                                                      etc_ncodigo = :old_etc_ncodigo and 
                                                      aud_cestado = :old_aud_cestado                                       
                 ");
                query.SetParameter("old_neg_ncodigo", negNcodigo);
                query.SetParameter("old_etc_ncodigo", 1);
                query.SetParameter("old_aud_cestado", "A", NHibernate.NHibernateUtil.String);
                query.AddEntity("tbrander", typeof(Tbrander));
                return query.List<Tbrander>();
            }

        }

        public IList<Tbrander> SelectBranderPorFechaCedula(Tbrander tbrander)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_ffecha, aud_cestado, aud_cusuario, bra_ncodigo, neg_ncodigo, 
                                                    bra_ccedula, bra_cnmbtit, bra_ccelular, bra_ctelefono, bra_cdireccion, 
                                                    ciu_ncodigo, bra_ffecha, jor_ncodigo, bra_cobservacion, etc_ncodigo, 
                                                    bra_cactividad_economica, bra_cconvenio
                                                    FROM mes.tbrander
                                                    WHERE neg_ncodigo = :new_neg_ncodigo and etc_ncodigo = :new_etc_ncodigo and aud_cestado ='A' and 
                                                    bra_ccedula=:new_bra_ccedula and bra_ffecha =:new_bra_ffecha and ciu_ncodigo=:new_ciu_ncodigo
                                                    ");

                query.SetParameter("new_neg_ncodigo", 2);
                query.SetParameter("new_etc_ncodigo", 1);

                query.SetParameter("new_bra_ccedula", tbrander.BraCcedula, NHibernate.NHibernateUtil.String);
                query.SetParameter("new_bra_ffecha", tbrander.BraFfecha, NHibernate.NHibernateUtil.Date);
                query.SetParameter("new_ciu_ncodigo", tbrander.Pciudad.CiuNcodigo);

                query.AddEntity("tbrander", typeof(Tbrander));
                return query.List<Tbrander>();
            }
        }



        protected int Insert(Tbrander tbrander)
        {
            using (new UnitOfWorkScope(false))
            {                                     
                const string qryText =
                    @"INSERT INTO mes.tbrander(
                        aud_ffecha, aud_cestado, aud_cusuario, bra_ncodigo, neg_ncodigo, 
                        bra_ccedula, bra_cnmbtit, bra_ccelular, bra_ctelefono, bra_cdireccion, 
                        ciu_ncodigo, bra_ffecha, jor_ncodigo, bra_cobservacion, etc_ncodigo, 
                        bra_cactividad_economica, bra_cconvenio)
                        VALUES (now(), 'A', :new_aud_cusuario, nextval('mes.seq_brander'), :new_neg_ncodigo, 
                        :new_bra_ccedula, :new_bra_cnmbtit, :new_bra_ccelular, :new_bra_ctelefono, :new_bra_cdireccion, 
                        :new_ciu_ncodigo, :new_bra_ffecha, :new_jor_ncodigo, :new_bra_cobservacion, :new_etc_ncodigo, 
                        :new_bra_cactividad_economica, :new_bra_cconvenio)
                    ";
                var query = Contexto.CreateSQLQuery(qryText);
                query.SetParameter("new_aud_cusuario", tbrander.AudCusuario);
                query.SetParameter("new_neg_ncodigo", tbrander.Tnegocio.NegNcodigo);

                query.SetParameter("new_bra_ccedula", tbrander.BraCcedula);
                query.SetParameter("new_bra_cnmbtit", tbrander.BraCnmbtit);
                query.SetParameter("new_bra_ctelefono", tbrander.BraCtelefono);
                query.SetParameter("new_bra_ccelular", tbrander.BraCcelular);
                query.SetParameter("new_bra_cdireccion", tbrander.BraCdireccion);
                query.SetParameter("new_ciu_ncodigo", tbrander.Pciudad.CiuNcodigo);                
                query.SetParameter("new_bra_ffecha", tbrander.BraFfecha);
                query.SetParameter("new_jor_ncodigo", tbrander.Pjornada.JorNcodigo);
                query.SetParameter("new_bra_cobservacion", tbrander.BraCobservacion);
                query.SetParameter("new_etc_ncodigo", tbrander.PestCita.EtcNcodigo);

                query.SetParameter("new_bra_cconvenio", tbrander.BraCconvenio);
                query.SetParameter("new_bra_cactividad_economica", tbrander.BraCactividadEconomica);

                return query.ExecuteUpdate();
            }
        }


        protected int Update(Tbrander tbrander)
        {
            using (new UnitOfWorkScope(false))
            {

                const string qryText =
                    @"UPDATE mes.tbrander SET 
                    aud_ffecha=now(),
                    aud_cestado=:new_aud_cestado,
                    aud_cusuario=:new_aud_cusuario,
                    neg_ncodigo=:new_neg_ncodigo, 
                    bra_ccedula=:new_bra_ccedula,
                    bra_cnmbtit=:new_bra_cnmbtit,
                    bra_ccelular=:new_bra_ccelular,
                    bra_ctelefono=:new_bra_ctelefono, 
                    bra_cdireccion=:new_bra_cdireccion, 
                    ciu_ncodigo=:new_ciu_ncodigo,
                    bra_ffecha=:new_bra_ffecha,
                    jor_ncodigo=:new_jor_ncodigo, 
                    bra_cobservacion=:new_bra_cobservacion,
                    etc_ncodigo=:new_etc_ncodigo,
                    bra_cactividad_economica=:new_bra_cactividad_economica, 
                    bra_cconvenio=:new_bra_cconvenio
                    WHERE bra_ncodigo=:new_bra_ncodigo
                    ";

                var query = Contexto.CreateSQLQuery(qryText);

                query.SetParameter("new_bra_ncodigo", tbrander.BraNcodigo);
                query.SetParameter("new_aud_cestado", tbrander.AudCestado);
                query.SetParameter("new_aud_cusuario", tbrander.AudCusuario);

                query.SetParameter("new_neg_ncodigo", tbrander.Tnegocio.NegNcodigo);
                query.SetParameter("new_bra_ccedula", tbrander.BraCcedula);
                query.SetParameter("new_bra_cnmbtit", tbrander.BraCnmbtit);
                query.SetParameter("new_bra_ctelefono", tbrander.BraCtelefono);
                query.SetParameter("new_bra_ccelular", tbrander.BraCcelular);
                query.SetParameter("new_bra_cdireccion", tbrander.BraCdireccion);
                query.SetParameter("new_ciu_ncodigo", tbrander.Pciudad.CiuNcodigo);
                query.SetParameter("new_bra_ffecha", tbrander.BraFfecha);
                query.SetParameter("new_jor_ncodigo", tbrander.Pjornada.JorNcodigo);
                query.SetParameter("new_bra_cobservacion", tbrander.BraCobservacion);
                query.SetParameter("new_etc_ncodigo", tbrander.PestCita.EtcNcodigo);

                query.SetParameter("new_bra_cactividad_economica", tbrander.BraCactividadEconomica);
                query.SetParameter("new_bra_cconvenio", tbrander.BraCconvenio);

                return query.ExecuteUpdate();
            }
        }


    }
}
