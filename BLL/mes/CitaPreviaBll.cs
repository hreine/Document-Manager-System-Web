using System;
using Reines.dmsflex.Dao.maestros;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.BLL.mes
{
    public class CitaPreviaBll : CitaPreviaDao
    {

        public int GuardaCitaPrevia(TcitaPrevia tcitaPrevia)
        {
            var citasant = SelectCitaPreviaPorFechaCedula(tcitaPrevia);
            if (citasant.Count > 0)
            {
                throw new Exception("Ya existe una cita creada para la cedula '" + tcitaPrevia.CprCcedula + "' en la fecha '"+tcitaPrevia.CprFfecha+"'");
            }
            return Insert(tcitaPrevia);           
        }

        public int CancelaCitaPrevia(TcitaPrevia tcitaPrevia)
        {
            tcitaPrevia.PestCita.EtcNcodigo = 2;
            return Update(tcitaPrevia);           
        }

    }
}
