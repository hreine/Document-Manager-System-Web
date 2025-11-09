using System;
using System.Collections.Generic;
using Reines.dmsflex.Dao.maestros;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.BLL.mes
{
    public class CitaBll :CitaDao
    {

        public int CancelaCita(Tcita tcita)
        {
            var citas= SelectAllCitasbycodigo(tcita.CitNcodigo);
            if (citas.Count > 0)
            {
                if (citas[0].PestCita.EtcNcodigo == 1)
                {
                    tcita.PestCita.EtcNcodigo = 2;
                    tcita.UsuCusuarioCancela = tcita.AudCusuario;
                    tcita.CitFfechaCancela = DateTime.Now;
                    return Update(tcita);
                }
                throw new Exception("La cita no esta en estado 'PROGRAMADA'");
            }
            throw new Exception("La cita no fue encontrada");
            return 0;
        }
    }
}
