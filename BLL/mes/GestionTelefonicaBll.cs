using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.maestros;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.BLL.mes
{
    public class GestionTelefonicaBll : GestionTelefonicaDao
    {
        public void GuardaGestionTelefonica(TgestionTelefonica gestionTelefonicaDao,Tcita citaDao)
        {
            Executepr_GuardaGestionTelefonica(gestionTelefonicaDao, citaDao);            
        }

    
    }
}
