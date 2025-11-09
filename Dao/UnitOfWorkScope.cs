using System;
using System.Configuration;
using System.Data;
using System.Threading;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Reines.dmsflex.Dao.mes;


namespace Reines.dmsflex.Dao
{
    /// <summary>
    /// Defines a scope wherein only one ObjectContext instance is created, 
    /// and shared by all of those who use it. Instances of this class are 
    /// supposed to be used in a using() statement.
    /// </summary>
    public sealed class UnitOfWorkScope : IDisposable
    {
        [ThreadStatic] private static UnitOfWorkScope _currentScope;
        private ISession _objectContext;
        //private ISession _session;
        private bool _isDisposed, _saveAllChangesAtEndOfScope;
        private ITransaction _transaction = null;
        //private string NlsLang = "SPANISH";

        /// <summary>
        /// Gets or sets a boolean value that indicates whether to automatically save 
        /// all object changes at end of the scope.
        /// </summary>
        public bool SaveAllChangesAtEndOfScope
        {
            get { return _saveAllChangesAtEndOfScope; }
            set { _saveAllChangesAtEndOfScope = value; }
        }


        /// <summary>
        /// Returns a reference to the NorthwindObjectContext that is created 
        /// for the current scope. If no scope currently exists, null is returned.
        /// </summary>
        internal static ISession CurrentObjectContext
        {
            get { return _currentScope != null ? _currentScope._objectContext : null; }
        }

        /// <summary>
        /// Default constructor. Object changes are not automatically saved 
        /// at the end of the scope.
        /// </summary>
        public UnitOfWorkScope()
            : this(false)
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="saveAllChangesAtEndOfScope">
        /// A boolean value that indicates whether to automatically save 
        /// all object changes at end of the scope.
        /// </param>
        public UnitOfWorkScope(bool saveAllChangesAtEndOfScope)
        {
            if (_currentScope != null && !_currentScope._isDisposed)
                throw new InvalidOperationException("ObjectContextScope instancia no se puede anidar.");
            _saveAllChangesAtEndOfScope = saveAllChangesAtEndOfScope;

            /* Create a new ObjectContext instance: */
            string connectionString = ConfigurationManager.ConnectionStrings["simesstr"].ConnectionString;
            var config = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString);
            var sessionFactory = Fluently.Configure()
                                          .Database(config)
                                          .Mappings(m =>
                                                    m.FluentMappings
                                                     .AddFromAssemblyOf<Tcliente>())
                                          .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                                          .Create(false, false))
                                          .BuildSessionFactory();
            _objectContext = sessionFactory.OpenSession();
            //_objectContext.ExecuteStoreCommand("ALTER SESSION SET NLS_LANGUAGE= '" + NlsLang + "'");
            _isDisposed = false;
            Thread.BeginThreadAffinity();
            /* Set the current scope to this UnitOfWorkScopePer object: */
            _currentScope = this;
        }

        /// <summary>
        /// Called on the end of the scope. Disposes the NorthwindObjectContext.
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                /* End of scope, so clear the thread static 
                 * _currentScope member: */
                _currentScope = null;
                Thread.EndThreadAffinity();
                if (_saveAllChangesAtEndOfScope)
                {
                    _objectContext.Save(null);
                }

                /* Dispose the scoped ObjectContext instance: */
                _objectContext.Close();
                _objectContext.Dispose();
                _isDisposed = true;
            }
        }


        public void ClearContext()
        {
            try
            {
                /*
                var liberar = _objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
                foreach (var objectStateEntry in liberar)
                {
                    this._objectContext.Detach(objectStateEntry.Entity);
                }
                */
            }
            catch (Exception)
            {
                //throw; nada
            }
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction = null;
            }
            else
            {
                throw new InvalidOperationException("No existe transaccion activa");
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
                ClearContext();
            }
            else
            {
                throw new InvalidOperationException("No existe transaccion activa");
            }
        }

        public void BeginTransaction()
        {
            if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                _transaction = _objectContext.BeginTransaction();
        }

        public void SaveChanges(object obj)
        {
            _objectContext.Save(obj);
        }
    }
}