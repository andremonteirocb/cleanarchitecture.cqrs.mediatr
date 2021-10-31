using Fundamentos.CQRS.Vendas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundamentos.CQRS.Vendas.Data.Mappings
{
    public class EntitdadeMapping : IEntityTypeConfiguration<Entidade>
    {
        public void Configure(EntityTypeBuilder<Entidade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Entidade");
        }
    }
}