using AndersonCRMEntity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AndersonCRMContext
{
    public class Context : DbContext
    {

        public Context() : base("AndersonCRM")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<ECompany> Companies { get; set; }
        public DbSet<EDepartment> Departments { get; set; }
        public DbSet<EEmployee> Employees { get; set; }
        public DbSet<EEmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EEmployeeTeam> EmployeeTeams { get; set; }
        public DbSet<EJobTitle> JobTitles { get; set; }
        public DbSet<EPeripheral> Peripherals { get; set; }
        public DbSet<EPeripheralHistory> PeripheralHistories { get; set; }
        public DbSet<EPeripheralType> PeripheralTypes { get; set; }
        public DbSet<ETeam> Teams { get; set; }
    }
}
