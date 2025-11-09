using System;
using System.Collections.Generic;
using FluorineFx;
using Reines.dmsflex.BLL.mes;
using Reines.dmsflex.amf3service.cl;
using Reines.dmsflex.amf3service.vo;

namespace Reines.dmsflex.amf3service
{
    [RemotingService]
    public class TrackingSrv
    {

        public IList<ProductoVo> ListaProductosByGuia(string guia)
        {
            var sesionVo = SessionFactory.GetSession();
            var productoBll = new ProductoBll();
            var productos = productoBll.SelectProductosByGuia1(guia);
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "TrackingSrv.GuardaGestionTelefonica", "usuario:" + sesionVo.Usuario); 
            return ProductoFactory.FromList(productos);
        }


        public IList<ProductoVo> ListaProductos(string cedula)
        {
            var sesionVo = SessionFactory.GetSession();
            var productoBll = new ProductoBll();
            var productos = productoBll.SelectProductos1(cedula);
            SessionFactory.InfoLog(DateTime.Now, SessionFactory.Tipo.Consulta, "TrackingSrv.GuardaGestionTelefonica", "usuario:" + sesionVo.Usuario); 
            return ProductoFactory.FromList(productos);
        }


    }
}
