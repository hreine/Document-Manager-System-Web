using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.model;

namespace DAL.mes
{
    public partial class DbEntities : DbContext
    {
        public DbEntities() : base(nameOrConnectionString: "simesstr") { }

        public DbSet<Tusuario> Usuario { get; set; }
    }
}
