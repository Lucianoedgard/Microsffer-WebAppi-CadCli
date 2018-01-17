using CadCli.Domain;
using CadCli.Infra.Mapping;
using System.Data.Entity;

namespace CadCli.Infra.DataContext
{
    public class CadCliDataContext : DbContext
    {
        public CadCliDataContext() : base("CadCliConnectionString")
        {
            Database.SetInitializer<CadCliDataContext>(new CadCliDataContextInitializer());
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientType> ClientType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientTypeMap());

            base.OnModelCreating(modelBuilder);
        }

        public class CadCliDataContextInitializer : CreateDatabaseIfNotExists<CadCliDataContext>
        {
            protected override void Seed(CadCliDataContext context)
            {
                context.ClientType.Add(new ClientType { Id = 1, Code = "Consumidor", Description = "Cliente do tipo Consumidor", IsActive = true });
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
