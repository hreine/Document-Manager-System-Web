using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao.maestros
{
    public class ProductoDao : ClaseBase
    {

        public Tproducto SelectProducto(double carNcodigo)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT aud_cusuario, aud_ffecha, aud_cestado, pro_ncodigo, car_ncodigo, 
                           eg_ccodigo, trk_ncodigo, cit_ncodigo, pro_cdescuelgue, pro_cguia, 
                           sed_nactual, ciu_nentrega, gte_ncodigo, mad_ncodigo
                      FROM mes.tproducto
                    WHERE 
                        mes.tproducto.car_ncodigo = :carNcodigo
                 ");
                query.SetParameter("carNcodigo", carNcodigo);
                query.AddEntity("tproducto", typeof(Tproducto));
                var resultado=query.List<Tproducto>();
                if (resultado.Count >0)
                {
                    return resultado[0];
                }
            }
            return  null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGuia"></param>
        /// <returns></returns>
        public IList<Tproducto> SelectProductosByGuia1(string pGuia)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT                                     
                    tproducto.aud_cusuario, tproducto.aud_ffecha, tproducto.aud_cestado, tproducto.pro_ncodigo, tproducto.car_ncodigo, 
                    tproducto.eg_ccodigo, tproducto.trk_ncodigo, tproducto.cit_ncodigo, tproducto.pro_cdescuelgue, tproducto.pro_cguia, 
                    tproducto.sed_nactual, tproducto.ciu_nentrega, tproducto.gte_ncodigo, tproducto.mad_ncodigo
                    FROM 
                        mes.tcargue, 
                        mes.tproducto, 
                        mes.tnegocio, 
                        mes.torden, 
                        mes.tcliente, 
                        mes.tsede, 
                        mes.ttracking, 
                        mes.testado_gestion
                    WHERE 
                        tcargue.car_ncodigo = tproducto.car_ncodigo AND
                        tproducto.trk_ncodigo = ttracking.trk_ncodigo AND
                        tproducto.eg_ccodigo = testado_gestion.eg_ccodigo AND
                        tnegocio.neg_ncodigo = torden.neg_ncodigo AND
                        torden.ord_ncodigo = tcargue.ord_ncodigo AND
                        torden.sed_ncodigo = tsede.sed_ncodigo AND
                        tcliente.cli_ncodigo = tnegocio.cli_ncodigo and
                        tproducto.pro_cguia = :pGuia
                 ");
                query.SetParameter("pGuia", pGuia);
                query.AddEntity("tproducto", typeof(Tproducto));
                return query.List<Tproducto>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGuia"></param>
        /// <returns></returns>
        public IList<Tproducto> SelectProductosByGuia(string pGuia)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT                                     
                    tproducto.aud_cusuario, tproducto.aud_ffecha, tproducto.aud_cestado, tproducto.pro_ncodigo, tproducto.car_ncodigo, 
                    tproducto.eg_ccodigo, tproducto.trk_ncodigo, tproducto.cit_ncodigo, tproducto.pro_cdescuelgue, tproducto.pro_cguia, 
                    tproducto.sed_nactual, tproducto.ciu_nentrega, tproducto.gte_ncodigo, tproducto.mad_ncodigo
                    FROM 
                        mes.tcargue, 
                        mes.tproducto, 
                        mes.tnegocio, 
                        mes.torden, 
                        mes.tcliente, 
                        mes.tsede, 
                        mes.ttracking, 
                        mes.testado_gestion
                    WHERE 
                        tcargue.car_ncodigo = tproducto.car_ncodigo AND
                        tproducto.trk_ncodigo = ttracking.trk_ncodigo AND
                        tproducto.eg_ccodigo = testado_gestion.eg_ccodigo AND
                        tnegocio.neg_ncodigo = torden.neg_ncodigo AND
                        torden.ord_ncodigo = tcargue.ord_ncodigo AND
                        torden.sed_ncodigo = tsede.sed_ncodigo AND
                        tcliente.cli_ncodigo = tnegocio.cli_ncodigo AND
                        testado_gestion.eg_cagendamiento='S' AND
                        tproducto.pro_cguia = :pGuia
                 ");
                query.SetParameter("pGuia", pGuia);
                query.AddEntity("tproducto", typeof (Tproducto));
                return query.List<Tproducto>();
            }
        }


        public IList<Tproducto> SelectProductos(string pCidentificacion)
        {
            using (new UnitOfWorkScope(false))
            {                        
                var query = Contexto.CreateSQLQuery(@"SELECT                                     
                    tproducto.aud_cusuario, tproducto.aud_ffecha, tproducto.aud_cestado, tproducto.pro_ncodigo, tproducto.car_ncodigo, 
                    tproducto.eg_ccodigo, tproducto.trk_ncodigo, tproducto.cit_ncodigo, tproducto.pro_cdescuelgue, tproducto.pro_cguia, 
                    tproducto.sed_nactual, tproducto.ciu_nentrega, tproducto.gte_ncodigo, tproducto.mad_ncodigo
                    FROM 
                        mes.tcargue, 
                        mes.tproducto, 
                        mes.tnegocio, 
                        mes.torden, 
                        mes.tcliente, 
                        mes.tsede, 
                        mes.ttracking, 
                        mes.testado_gestion
                    WHERE 
                        tcargue.car_ncodigo = tproducto.car_ncodigo AND
                        tproducto.trk_ncodigo = ttracking.trk_ncodigo AND
                        tproducto.eg_ccodigo = testado_gestion.eg_ccodigo AND
                        tnegocio.neg_ncodigo = torden.neg_ncodigo AND
                        torden.ord_ncodigo = tcargue.ord_ncodigo AND
                        torden.sed_ncodigo = tsede.sed_ncodigo AND
                        tcliente.cli_ncodigo = tnegocio.cli_ncodigo AND
                        testado_gestion.eg_cagendamiento='S' AND
                        tcargue.car_cidentificacion = :pCidentificacion
                 ");                
                query.SetParameter("pCidentificacion", pCidentificacion);
                query.AddEntity("tproducto", typeof(Tproducto));                               
                return query.List<Tproducto>();
            }

        }

        public IList<Tproducto> SelectProductos1(string pCidentificacion)
        {
            using (new UnitOfWorkScope(false))
            {
                var query = Contexto.CreateSQLQuery(@"SELECT                                     
                    tproducto.aud_cusuario, tproducto.aud_ffecha, tproducto.aud_cestado, tproducto.pro_ncodigo, tproducto.car_ncodigo, 
                    tproducto.eg_ccodigo, tproducto.trk_ncodigo, tproducto.cit_ncodigo, tproducto.pro_cdescuelgue, tproducto.pro_cguia, 
                    tproducto.sed_nactual, tproducto.ciu_nentrega, tproducto.gte_ncodigo, tproducto.mad_ncodigo
                    FROM 
                        mes.tcargue, 
                        mes.tproducto, 
                        mes.tnegocio, 
                        mes.torden, 
                        mes.tcliente, 
                        mes.tsede, 
                        mes.ttracking, 
                        mes.testado_gestion
                    WHERE 
                        tcargue.car_ncodigo = tproducto.car_ncodigo AND
                        tproducto.trk_ncodigo = ttracking.trk_ncodigo AND
                        tproducto.eg_ccodigo = testado_gestion.eg_ccodigo AND
                        tnegocio.neg_ncodigo = torden.neg_ncodigo AND
                        torden.ord_ncodigo = tcargue.ord_ncodigo AND
                        torden.sed_ncodigo = tsede.sed_ncodigo AND
                        tcliente.cli_ncodigo = tnegocio.cli_ncodigo AND                        
                        tcargue.car_cidentificacion = :pCidentificacion
                 ");
                query.SetParameter("pCidentificacion", pCidentificacion);
                query.AddEntity("tproducto", typeof(Tproducto));
                return query.List<Tproducto>();
            }

        }

    }
}
