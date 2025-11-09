using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Reines.dmsflex.Dao.mes;

namespace Reines.dmsflex.Dao
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["simesstr"].ConnectionString;
            var config = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString);
            //const string strConnectionString = "Server=192.168.2.20;Port=5432;User Id=postgres;Password=root;Database=simes;";
            _sessionFactory = Fluently.Configure()
                                      .Database(config)
                                      .Mappings(m =>
                                                m.FluentMappings
                                                 .AddFromAssemblyOf<Tusuario>())
                                      .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                                      .Create(false, false))
                                      .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}