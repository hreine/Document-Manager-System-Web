using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reines.dmsflex.Dao.maestros;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.BLL.mes
{
    public class BrandersBll : BrandersDao
    {
        public int GuardaBrander(Tbrander tbrander)
        {
            var citasant = SelectBranderPorFechaCedula(tbrander);
            if (citasant.Count > 0)
            {
                throw new Exception("Ya existe una cita creada para la cedula '" + tbrander.BraCcedula + "' en la fecha '" + tbrander.BraFfecha + "'");
            }
            return Insert(tbrander);
        }

        public int CancelaBrander(Tbrander tbrander)
        {
            tbrander.PestCita.EtcNcodigo = 2;
            return Update(tbrander);       
        }
    }
}
