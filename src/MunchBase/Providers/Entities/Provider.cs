using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Bases;
using MunchBase.Dumps.Entities;
using MunchBase.Media.Entities;
using MunchBase.Models.Entities;
using MunchBase.Tasks.Entities;

namespace MunchBase.Providers.Entities
{
    public class Provider : BaseEntity<Provider>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelProvider> ModelProviders { get; set; }
        public ICollection<ProviderCapability> ProviderCapabilities { get; set; } 
        public ICollection<TaskMaster> TaskMasters { get; set; }
        public ICollection<DumpProvider> ContentDumps { get; set; }
        public ICollection<MediaSetProvider> MediaSets { get; set; }
        public ICollection<ChannelProvider> Channels { get; set; }

        public override void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ModelProviders)
                .WithOne(x => x.Provider)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProviderCapabilities)
                .WithOne(x => x.Provider)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
