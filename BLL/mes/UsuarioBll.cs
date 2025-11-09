using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Reines.dmsflex.Dao;
using Reines.dmsflex.Dao.mes;
using Reines.utils;
using Reines.dmsflex.Dao.maestros;

namespace Reines.dmsflex.BLL.mes
{
    public class UsuarioBll :UsuariosDao
    {

       #region Motivos enum
        public enum Motivos
        {
            Usuarionoexiste = 1,
            Tiemposiningresar = 2,
            Contrasenaerrada = 3,
            Maxnumintentos = 4,
            Cambiarcontrasena = 6,
            Noexistehorario = 10,
            IpnoPermitida=90
        }
        #endregion

        /// <summary>
        /// Bloqueo de log de consultas
        /// </summary>
        private Object _lockLog = new Object();

        private readonly DateTime _ahora = DateTime.Now;
       // private readonly int _maxIntentos = 6;


        private IPList _iplist;
        public IPList IpList
        {
            get
            {
                if (_iplist != null)
                {
                    return _iplist;
                }
                _iplist = new IPList();
                return _iplist;
            }
            set { _iplist = value; }
        }


        public UsuarioBll()
        {        
            //var parametro = new Parametroctr();
            //_maxIntentos = 3;//Int32.Parse(parametro.FetchByCodigo(1).PAR_CVALOR);
            //MaxTiempoSinIngresar = 30; //Int32.Parse(parametro.FetchByCodigo(1).PAR_CVALOR);
            //VenceClave = 30; //Int32.Parse(parametro.FetchByCodigo(1).PAR_CVALOR);
            _ahora = DateTime.Now;
        }


        public int VenceClave = 30;
        public int MaxTiempoSinIngresar = 30;


        public string Mensajemotivos(Motivos motivos)
        {
            return Mensajemotivos(motivos, -1);
        }

        public string Mensajemotivos(Motivos motivos,int cant)
        {
            switch (motivos)
            {
                case Motivos.Usuarionoexiste:
                    return ("El usuario o contraseña no es valido");
                case Motivos.Tiemposiningresar:
                    return cant > -1 ? (String.Format("Usuario inhabilitado por {0} horas sin ingresar", cant)) : ("Usuario inhabilitado por horas sin ingresar");
                case Motivos.Contrasenaerrada:
                    return ("El usuario o contraseña no es valido");
                case Motivos.Maxnumintentos:
                    return cant > -1 ? (String.Format("Usuario inhabilitado por que supero los {0} intentos de ingreso fallidos",cant)):("Usuario inhabilitado por que supero los intentos de ingreso fallidos");
                case Motivos.Cambiarcontrasena:
                    return cant > -1 ? (String.Format("Usuario inhabilitado por que no Cambio la contraseña en {0} dias anteriores", cant)) : ("Usuario inhabilitado por que no Cambio la contraseña en dias anteriores");
                case Motivos.Noexistehorario:
                    return ("No existe un horario");
                case Motivos.IpnoPermitida:
                    return ("La direccion ip no esta autorizada");
                default:
                    return ("Acceso negado");
            }
        }

        /*
        public decimal Login(string usuario, string contrasena)
        {
            var usuarios = FetchByIdFormActive(usuario.ToUpper());
            if (usuarios.Count == 0)
            {
                return -1;
            }
            if (usuarios[0].USU_CCLAVEN.ToUpper() != GetSha512(contrasena).ToUpper() &&
                usuarios[0].USU_CCLAVEN.ToUpper() != ObtenerMd5(contrasena).ToUpper())
            {
                return -1;
            }
            return usuarios[0].TSEDE.CLI_NCODIGO;
        }

        */

        public string Login(string usuario, string contrasena, out string roll)                          
        {           
                roll = string.Empty;
                try
                {
                    /*
                    var tiemposincambio = (DateTime.Now) - DateTime.Parse("2016-02-01");
                    if (tiemposincambio.Days >= 29)
                    {
                        Setsession(usuario, "*", (int)Motivos.Usuarionoexiste, 0, 0);
                        return Mensajemotivos(Motivos.Usuarionoexiste);
                    }
                    */
                    List<Tusuario> usuarios = null;                    
                    usuarios = FetchByIdFormActive(usuario.ToUpper());
                    if (usuarios.Count == 0)
                    {
                        Setsession(usuario, "*", (int) Motivos.Usuarionoexiste, 0, 0);
                        return Mensajemotivos(Motivos.Usuarionoexiste);
                    }

                    if (usuarios[0].UsuCclave.ToUpper() != GetSha512(contrasena).ToUpper())
                    {
                        Setsession(usuario, "*", (int)Motivos.Contrasenaerrada, 0, 0);
                        return Mensajemotivos(Motivos.Contrasenaerrada);
                    }                                                                                                     
                }
                catch (SecurityException ex)
                {
                    if (ex.Message != null)
                    {
                        return ex.Message;
                    }
                }
                return "";            
        }

  


        /// <summary>
        /// Registrar las sessiones
        /// </summary>
        /// <param name="peCusuccodigo">Codigo del usuario</param>
        /// <param name="peCsescodigo">Codigo de session</param>
        /// <param name="peNsesCodigoError">Codigo del error</param>
        /// <param name="peNsedcodigo">Codigo de la sede</param>
        /// <param name="peNdpecodigo">Codigo de dependencia</param>        
        public void Setsession(string peCusuccodigo, string peCsescodigo, int peNsesCodigoError, double peNsedcodigo, double peNdpecodigo)
        {
                var ip = HttpContext.Current.Request.UserHostAddress;
                //UsuarioDao.ExecPaUiIniSes(peCusuccodigo, peCsescodigo, peNsesCodigoError, peNsedcodigo, peNdpecodigo, ip);
        }

        
        public string ObtenerMd5(string pass)
        {
            var md5 = MD5.Create();
            var dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            var sb = new StringBuilder();
            for (var i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString().ToUpper();
        }
        

        public static string GetSha512(string str)
        {
            var sha1 = SHA512.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }



        public bool ValidarUsuario(string pUsu)
        {
            using (new UnitOfWorkScope(false))
            {
                var resultado = false;
                try
                {
                    if ((pUsu.Length < 4) || (pUsu.Length > 16))
                    {
                        return false;
                    }
                    var alfa = Encoding.ASCII.GetBytes("A")[0];
                    var omega = Encoding.ASCII.GetBytes("Z")[0];
                    var cero = Encoding.ASCII.GetBytes("0")[0];
                    var nueve = Encoding.ASCII.GetBytes("9")[0];
                    var usuario = Encoding.ASCII.GetBytes(pUsu.ToUpper());

                    foreach (var subcod in usuario)
                    {
                        if (((subcod >= alfa) && (subcod <= omega)) || ((subcod >= cero) && (subcod <= nueve)))
                        {
                            resultado = true;
                        }
                        else
                        {
                            resultado = false;
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return (resultado);
            }
        }


        public bool UsuarioExists(Tusuario tusuario)
        {
            using (new UnitOfWorkScope(false))
            {
                var tusuarioCollection = FetchByIdFormActive(tusuario.UsuCcodigo);
                return tusuarioCollection.Count == 1;
            }
        }


        


        /// <summary>
        /// Cambio de contraseña
        /// </summary>
        /// <param name="name">Usuario Actual</param>
        /// <param name="password">Contraseña Actual</param>
        /// <param name="newpassword">Nueva Contraseña</param>
        /// <returns></returns>
        public bool PassChange(string name, string password, string newpassword)
        {            
            List<Tusuario> usuarios = null;
            usuarios = FetchByIdFormActive(name.ToUpper());
            if (usuarios[0].UsuCclave.ToUpper() != GetSha512(password).ToUpper())
            {
                throw new SecurityException(Mensajemotivos(Motivos.Contrasenaerrada));
            }
            var resultado= UpdatePasword(name.ToUpper(), GetSha512(password), GetSha512(newpassword));
            if (resultado == false)
            {
                throw new SecurityException("Error no determinado");
            }
            return true;
        }        
    }
}
