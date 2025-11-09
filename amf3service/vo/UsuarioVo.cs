using System;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.amf3service.vo
{
    public class UsuarioVo
    {
        public string UsuCcodigo { get; set; }
        public SedeVo Tsede { get; set; }
        public string UsuCobliga { get; set; }
        public string UsuCsadmin { get; set; }
        public string AudCusuario { get; set; }
        public string UsuCemail { get; set; }
        public string UsuCcedula { get; set; }
        public string AudCestado { get; set; }
        public double? UsuNtimeout { get; set; }
        public string UsuCapellido { get; set; }
        public DateTime AudFfecha { get; set; }
        public string UsuCreexpedicion { get; set; }
        public string UsuCnombre { get; set; }
        public string UsuCclave { get; set; }

        public UsuarioVo(Tusuario item)
        {
            UsuCcodigo = item.UsuCcodigo;
            Tsede = new SedeVo(item.Tsede);
            UsuCobliga = item.UsuCobliga;
            UsuCsadmin = item.UsuCsadmin;
            AudCusuario = item.AudCusuario;
            UsuCemail = item.UsuCemail;
            UsuCcedula = item.UsuCcedula;
            AudCestado = item.AudCestado;
            UsuNtimeout = item.UsuNtimeout;
            UsuCapellido = item.UsuCapellido;
            AudFfecha = item.AudFfecha;
            UsuCreexpedicion = item.UsuCreexpedicion;
            UsuCnombre = item.UsuCnombre;
            UsuCclave = item.UsuCclave;
        }
    }


  


}