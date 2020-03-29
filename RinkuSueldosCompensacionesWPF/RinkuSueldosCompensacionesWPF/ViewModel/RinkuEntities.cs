using RinkuSueldosCompensacionesWPF.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace RinkuSueldosCompensacionesWPF.ViewModel
{
    class RinkuEntities : DbContext
    {
        public DbSet<Empleado> rinkuEmpleados { get; set; }
        public DbSet<CapturaFolio> rinkuCapturaFolio { get; set; }
        public DbSet<PagoEmpleado> rinkuPagoEmpleado { get; set; }
        public RinkuEntities() : base("RinkuSql")
        {
            Database.SetInitializer<RinkuEntities>(null);
        }    
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
