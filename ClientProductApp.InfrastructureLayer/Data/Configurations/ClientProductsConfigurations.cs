using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ClientProductApp.DomainLayer.Entities;

namespace ClientProductApp.InfrastructureLayer.Data.Configuration
{
    public class ClientProductsConfigurations : IEntityTypeConfiguration<ClientProducts>
    {
        public void Configure(EntityTypeBuilder<ClientProducts> builder)
        {
            builder.HasKey(c=>c.Id);
            builder.HasOne(c=>c.Client).WithMany(c=>c.ClientProducts).HasForeignKey(c=>c.ClientId);
            builder.HasOne(c=>c.Product).WithMany(c=>c.ClientProducts).HasForeignKey(c=>c.ProductId);
            builder.Property(c => c.StartDate).HasAnnotation("Required", true);
            builder.Property(c => c.EndDate).HasAnnotation("Required", false);
            builder.Property(c => c.License).HasMaxLength(255).IsRequired();

        }
    }
}