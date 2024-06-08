using ClientProductApp.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ClientProductApp.InfrastructureLayer.Data.Configuration
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Code).HasMaxLength(9).IsRequired();
            builder.Property(p=>p.Class).IsRequired();
            builder.Property(p=>p.State).IsRequired();
        }
    }
}