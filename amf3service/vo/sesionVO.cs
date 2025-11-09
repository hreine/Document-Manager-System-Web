using System;

namespace Reines.dmsflex.amf3service.vo
{
    [Serializable]
    public class SesionVo
    {
        public double Ciudad=0;
        public double Cliente=0;
        public String Email="*";
        public String IdSesion="*";
        public String IP = "*";
        public String NombreCiudad = "*";
        public String NombreCliente = "*";
        public String NombreUsuario = "*";
        public String Password = "*";
        public double SedNcodigo=0;
        public string NombreSede = "*";
        public String Usuario = "*";
        public String UsuCtgrol = "*";
        public String UsuCMenu = "*";
        public double DpeNcodigo=0;
        public string ClientTimeZone = "*";
        public string ServerTimeZone = "*";
        public string Extension = "*";
        public string UsuCobliga = "N";
        public double Timeout=10;
        public string UsuCdirplantillas = "assets/docs/plantillas.zip";
        public string UsuCdirAyuda = "assets/docs/manualtgguias.pdf";
    }
}