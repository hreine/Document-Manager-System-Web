using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Reines.DB;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class GestionTelefonicaDao :ClaseBase
    {


        protected double Executepr_GuardaGestionTelefonica(TgestionTelefonica gestionTelefonicaDao, Tcita citaDao)
        {            
            try
            {
                using (new UnitOfWorkScope(false))
                {
                    var query =
                        Contexto.CreateSQLQuery(
                            @"select mes.gt_guardagestiontel(:audcusuario,:carncodigo,:rctncodigo,:motncodigo,:gtecobservacion,:rcdncodigo,:citffecha,:jorncodigo)")
                                .SetString("audcusuario", gestionTelefonicaDao.AudCusuario)
                                .SetDecimal("carncodigo", (decimal) gestionTelefonicaDao.CarNcodigo)
                                .SetDecimal("rctncodigo", (decimal) gestionTelefonicaDao.RcargueTelefono.RctNcodigo)
                                .SetDecimal("motncodigo", (decimal) gestionTelefonicaDao.TmotTelefonicos.MotNcodigo)
                                .SetString("gtecobservacion", gestionTelefonicaDao.GteCobservacion)
                                .SetDecimal("rcdncodigo",
                                            (decimal)
                                            (double.IsNaN(citaDao.RcargueDireccion.RcdNcodigo) == true
                                                 ? 0
                                                 : citaDao.RcargueDireccion.RcdNcodigo))
                                .SetDateTime("citffecha", citaDao.CitFfecha)
                                .SetDecimal("jorncodigo",
                                            (decimal)
                                            (double.IsNaN(citaDao.Pjornada.JorNcodigo) ? 0 : citaDao.Pjornada.JorNcodigo))
                                .List();

                    return query.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }            
        }

    }
}
