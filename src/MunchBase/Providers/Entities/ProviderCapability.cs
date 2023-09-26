using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Providers.Entities
{
    public class ProviderCapability : BaseEntity<ProviderCapability>
    {
        public int ProviderId { get; set;}
        public Provider Provider { get; set; }
        public int CapabilityId { get; set; }
        public Capability Capability { get; set; }

        public override void Configure(EntityTypeBuilder<ProviderCapability> builder)
        {
            builder.HasKey(x=>new{x.ProviderId, x.CapabilityId});

            builder.HasOne(x => x.Provider)
                .WithMany(x => x.ProviderCapabilities)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Capability)
                .WithMany(x => x.ProviderCapabilities)
                .HasForeignKey(x => x.CapabilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}