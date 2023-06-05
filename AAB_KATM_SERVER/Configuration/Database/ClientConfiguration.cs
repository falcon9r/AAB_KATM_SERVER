using AAB_KATM_SERVER.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AAB_KATM_SERVER.Configuration.Database
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);
            builder.Property(client => client.Id).ValueGeneratedOnAdd();

            builder.HasIndex(client => client.ClientId).IsUnique();
        }
    }
}
