using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Channels.Entities
{
    public class Channel : BaseEntity<Channel>
    {
        public Channel()
        {
            Producers = new List<ChannelProducer>();
            Providers = new List<ChannelProvider>();
            ChannelIntents = new List<ChannelIntent>();
            Subscriptions = new List<ChannelSubscription>();
            MediaSets = new List<ChannelMediaSet>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChannelMediaSet> MediaSets { get; set; } 
        public ICollection<ChannelSubscription> Subscriptions { get; set; }
        public ICollection<ChannelIntent> ChannelIntents { get; set; }
        public ICollection<ChannelProvider> Providers { get; set; }
        public ICollection<ChannelProducer> Producers { get; set; }

        public override void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.MediaSets)
                .WithOne(x => x.Channel)
                .HasForeignKey(x => x.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Subscriptions)
                .WithOne(x => x.Channel)
                .HasForeignKey(x => x.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
