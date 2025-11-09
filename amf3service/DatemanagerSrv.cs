using System;
using System.Collections.Generic;
using System.Security;
using FluorineFx;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.amf3service.cl;
using Reines.dmsflex.amf3service.vo;

namespace Reines.dmsflex.amf3service
{
     [RemotingService]
    public class DatemanagerSrv
     {
              
         public string Echo(string name)
         {
             return "Date Manager " + name;
         }

         public IList<MotTelefonicosVo> ListaMasterMotTelefonicos()
         {
             var parametrosBll = new ParametrosBll();
             var motivos = parametrosBll.SelectMasterMotTelefonicos();
             return MotTelefonicosFactory.FromList(motivos);
         }

         public IList<MotTelefonicosVo> ListaMotTelefonicos(MotTelefonicosVo motTelefonicosVo)
         {
             var parametrosBll = new ParametrosBll();
             var motivos = parametrosBll.SelectMotTelefonicos(motTelefonicosVo.MotNcodigo);
             return MotTelefonicosFactory.FromList(motivos);
         }

         public IList<JornadaVo> ListaJornadas()
         {
             var jornadaBll = new ParametrosBll();
             var jornadas = jornadaBll.SelectAllJornadas();
             return JornadaFactory.FromList(jornadas);
         }

         public IList<JornadaVo> ListaJornadas(CalendarioVo calendarioVo,double ciuNcodigo)
         {
             var sesionVo = SessionFactory.GetSession();
             if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
             var jornadaBll = new ParametrosBll();
             var jornadas = jornadaBll.SelectAllJornadas(CalendarioFactory.ToDao(calendarioVo), ciuNcodigo);
             return JornadaFactory.FromList(jornadas);
         }

         public IList<CalendarioVo> ListaFechas(double ciuNcodigo)
         {
             var sesionVo = SessionFactory.GetSession();
             if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
             var calendarioBll = new ParametrosBll();
             var calendario = calendarioBll.SelectAllFechas(ciuNcodigo);
             return CalendarioFactory.FromList(calendario);
         }

         public IList<CalendarioVo> ListaFechas(double sedNcodigo, double ciuNcodigo)
         {
             var sesionVo = SessionFactory.GetSession();
             if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
             var calendarioBll = new ParametrosBll();
             var calendario = calendarioBll.SelectAllFechas(sedNcodigo, ciuNcodigo);
             return CalendarioFactory.FromList(calendario);
         }
         
         public IList<CitaVo> ListaCitas()
         {
             var sesionVo = SessionFactory.GetSession();
             var bll = new CitaBll();
             var lista = bll.SelectAllCitas();
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.ListaCitas", "usuario:" + sesionVo.Usuario);
             return CitaFactory.FromList(lista);
         }

         public IList<CitaVo> ListaCitasbyGuia(string guia)
         {
             var sesionVo = SessionFactory.GetSession();
             var bll = new CitaBll();
             var lista = bll.SelectAllCitasbyGuia(guia);
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.ListaCitasbyGuia", "usuario:" + sesionVo.Usuario);
             return CitaFactory.FromList(lista);
         }

         public IList<CitaVo> ListaCitasbyCedula(string cedula)
         {
             var sesionVo = SessionFactory.GetSession();
             var bll = new CitaBll();
             var lista = bll.SelectAllCitasbycedula(cedula);
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.ListaCitasbyCedula", "usuario:" + sesionVo.Usuario);
             return CitaFactory.FromList(lista);
         }

         public IList<ProductoVo> ListaProductosbyGuia(string guia)
         {
             var sesionVo = SessionFactory.GetSession();
             var productoBll = new ProductoBll();
             var productos = productoBll.SelectProductosByGuia(guia);
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.ListaProductosByGuia", "usuario:" + sesionVo.Usuario); 
             return ProductoFactory.FromList(productos);
         }

         public ProductoVo InfoProducto(double carNcodigo)
         {
             var sesionVo = SessionFactory.GetSession();
             var productoBll = new ProductoBll();
             var productos = productoBll.SelectProducto(carNcodigo);
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.InfoProducto", "usuario:" + sesionVo.Usuario);
             return ProductoFactory.ToVo(productos);
         }

         public IList<ProductoVo> ListaProductos(string cedula)
         {
             var sesionVo = SessionFactory.GetSession();
             var productoBll = new ProductoBll();
             var productos = productoBll.SelectProductos(cedula);
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "DatemanagerSrv.ListaProductos", "usuario:" + sesionVo.Usuario); 
             return ProductoFactory.FromList(productos);
         }

         public int GuardaGestionTelefonica(GestionTelefonicaVo gestionTelefonicaVo, CitaVo citaVo,string citCfecha)
         {                          
             var gestionTelefonicaBll = new GestionTelefonicaBll();
             var sesionVo = SessionFactory.GetSession();
             if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
             gestionTelefonicaVo.AudCusuario = sesionVo.Usuario.ToUpper();
             citaVo.AudCusuario = sesionVo.Usuario.ToUpper();
             if (citCfecha.Trim().Length >0)
                citaVo.CitFfecha = DateTime.ParseExact(citCfecha, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
             gestionTelefonicaBll.GuardaGestionTelefonica(GestionTelefonicaFactory.ToDao(gestionTelefonicaVo), CitaFactory.ToDao(citaVo));
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "DatemanagerSrv.GuardaGestionTelefonica", "usuario:" + sesionVo.Usuario); 
             return 1;
         }

         public int CancelaCita(CitaVo citaVo)
         {
             var bll = new CitaBll();
             var sesionVo = SessionFactory.GetSession();
             if (sesionVo.ServerTimeZone != sesionVo.ClientTimeZone) throw new SecurityException("La configuracion actual de su zona horaria no es correcta;debe configurarla en " + sesionVo.ServerTimeZone);
             
             citaVo.AudCusuario = sesionVo.Usuario.ToUpper();
             bll.CancelaCita(CitaFactory.ToDao(citaVo));
             
             SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Insercion, "DatemanagerSrv.CancelaCita", "usuario:" + sesionVo.Usuario);
             return 1;
         }

     }
}
