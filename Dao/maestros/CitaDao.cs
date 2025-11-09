using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class CitaDao :ClaseBase
    {


        protected int Update(Tcita tcita)
        {
            using (new UnitOfWorkScope(false))
            {
                const string qryText =
                    @"UPDATE mes.tcita
                       SET aud_cusuario=:new_aud_cusuario, aud_ffecha=now(), aud_cestado=:new_aud_cestado, car_ncodigo=:new_car_ncodigo,
                           etc_ncodigo=:new_etc_ncodigo, tci_ncodigo=:new_tci_ncodigo, rcd_ncodigo=:new_rcd_ncodigo, rct_ncodigo=:new_rct_ncodigo, jor_ncodigo=:new_jor_ncodigo, 
                           cit_ffecha=:new_cit_ffecha, cit_cobservacion=:new_cit_cobservacion, cit_ffecha_cancela=:new_cit_ffecha_cancela, usu_cusuario_cancela=:new_usu_cusuario_cancela, 
                           cit_ffecha_crea=:new_cit_ffecha_crea, cit_cusu_crea=:new_cit_cusu_crea
                    WHERE cit_ncodigo = :new_cit_ncodigo                      
                    ";
                var query = Contexto.CreateSQLQuery(qryText);

                query.SetParameter("new_cit_ncodigo", tcita.CitNcodigo);
                query.SetParameter("new_aud_cusuario", tcita.AudCusuario);
                query.SetParameter("new_aud_cestado", tcita.AudCestado);
                query.SetParameter("new_car_ncodigo", tcita.CarNcodigo);
                query.SetParameter("new_etc_ncodigo", tcita.PestCita.EtcNcodigo);
                query.SetParameter("new_tci_ncodigo", tcita.PtipoCita.TciNcodigo);
                query.SetParameter("new_rcd_ncodigo", tcita.RcargueDireccion.RcdNcodigo);
                query.SetParameter("new_rct_ncodigo", tcita.RcargueTelefono.RctNcodigo);
                query.SetParameter("new_jor_ncodigo", tcita.Pjornada.JorNcodigo);
                query.SetParameter("new_cit_ffecha", tcita.CitFfecha);
                query.SetParameter("new_cit_cobservacion", tcita.CitCobservacion);
                query.SetParameter("new_cit_ffecha_cancela", tcita.CitFfechaCancela);
                query.SetParameter("new_usu_cusuario_cancela", tcita.UsuCusuarioCancela);
                query.SetParameter("new_cit_ffecha_crea", tcita.CitFfechaCrea);                
                query.SetParameter("new_cit_cusu_crea", tcita.CitCusuCrea);

                return query.ExecuteUpdate();
            }
        }


        public  IList<Tcita> SelectAllCitas()
        {
            using (new UnitOfWorkScope(false))
            {
                return Contexto.CreateCriteria<Tcita>().List<Tcita>();
            }            
        }

        public IList<Tcita> SelectAllCitasbycodigo(double citNcodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT 
                      cit.aud_cusuario, 
                      cit.aud_ffecha, 
                      cit.aud_cestado, 
                      cit.car_ncodigo, 
                      cit.cit_ncodigo, 
                      cit.etc_ncodigo, 
                      cit.tci_ncodigo, 
                      cit.rcd_ncodigo, 
                      cit.rct_ncodigo, 
                      cit.jor_ncodigo, 
                      cit.cit_ffecha, 
                      cit.cit_cobservacion, 
                      cit.cit_ffecha_cancela, 
                      cit.usu_cusuario_cancela, 
                      cit.cit_ffecha_crea, 
                      cit.cit_cusu_crea
                    FROM 
                      mes.tcita cit, 
                      mes.tcargue car, 
                      mes.tproducto pro
                    WHERE 
                      cit.cit_ncodigo = :citNcodigo
                 ");
                query.SetParameter("citNcodigo", citNcodigo);
                query.AddEntity("cit", typeof(Tcita));
                return query.List<Tcita>();
            }
        }

        public IList<Tcita> SelectAllCitasbyGuia(string pGuia)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT 
                      cit.aud_cusuario, 
                      cit.aud_ffecha, 
                      cit.aud_cestado, 
                      cit.car_ncodigo, 
                      cit.cit_ncodigo, 
                      cit.etc_ncodigo, 
                      cit.tci_ncodigo, 
                      cit.rcd_ncodigo, 
                      cit.rct_ncodigo, 
                      cit.jor_ncodigo, 
                      cit.cit_ffecha, 
                      cit.cit_cobservacion, 
                      cit.cit_ffecha_cancela, 
                      cit.usu_cusuario_cancela, 
                      cit.cit_ffecha_crea, 
                      cit.cit_cusu_crea
                    FROM 
                      mes.tcita cit, 
                      mes.tcargue car, 
                      mes.tproducto pro
                    WHERE 
                      car.car_ncodigo = cit.car_ncodigo AND
                      pro.car_ncodigo = car.car_ncodigo AND
                      cit.etc_ncodigo = 1 AND
                      pro.pro_cguia = :pGuia
                 ");
                query.SetParameter("pGuia", pGuia);
                query.AddEntity("cit", typeof(Tcita));
                return query.List<Tcita>();
            }
        }


        public IList<Tcita> SelectAllCitasbycedula(string pCedula)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT 
                      cit.aud_cusuario, 
                      cit.aud_ffecha, 
                      cit.aud_cestado, 
                      cit.car_ncodigo, 
                      cit.cit_ncodigo, 
                      cit.etc_ncodigo, 
                      cit.tci_ncodigo, 
                      cit.rcd_ncodigo, 
                      cit.rct_ncodigo, 
                      cit.jor_ncodigo, 
                      cit.cit_ffecha, 
                      cit.cit_cobservacion, 
                      cit.cit_ffecha_cancela, 
                      cit.usu_cusuario_cancela, 
                      cit.cit_ffecha_crea, 
                      cit.cit_cusu_crea
                    FROM 
                      mes.tcita cit, 
                      mes.tcargue car, 
                      mes.tproducto pro
                    WHERE 
                      car.car_ncodigo = cit.car_ncodigo AND
                      pro.car_ncodigo = car.car_ncodigo AND
                      cit.etc_ncodigo = 1 AND
                      car.car_cidentificacion = :pCedula
                 ");
                query.SetParameter("pCedula", pCedula);
                query.AddEntity("cit", typeof(Tcita));
                return query.List<Tcita>();
            }
        }


    }
}
