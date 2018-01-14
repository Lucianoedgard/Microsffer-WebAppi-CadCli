using CadCli.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CadCli.Infra.Mapping
{
    public class ClientMap: EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Client");
            HasKey(x => x.Id);
            Property(x => x.Code).HasMaxLength(100).IsRequired();
            Property(x => x.Name).HasMaxLength(300).IsRequired();
            Property(x => x.IsActive).IsRequired();

            HasRequired(x => x.ClientType);
        }
    }
}
