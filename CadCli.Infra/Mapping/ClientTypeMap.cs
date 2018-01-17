using CadCli.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CadCli.Infra.Mapping
{
    public class ClientTypeMap: EntityTypeConfiguration<ClientType>
    {
        public ClientTypeMap()
        {
            ToTable("ClientType");
            HasKey(x => x.Id);
            Property(x => x.Code).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(1000).IsOptional();
            Property(x => x.IsActive).IsRequired();
        }
    }
}
