using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Providers.Entities
{
    public class Capability : BaseEntity<Capability>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProviderCapability> ProviderCapabilities { get; set; }
        public override void Configure(EntityTypeBuilder<Capability> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProviderCapabilities)
                .WithOne(x => x.Capability)
                .HasForeignKey(x => x.CapabilityId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}