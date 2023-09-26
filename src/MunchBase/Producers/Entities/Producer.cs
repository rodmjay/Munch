using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Bases;
using MunchBase.Dumps.Entities;
using MunchBase.Media.Entities;
using MunchBase.Users.Entities;

namespace MunchBase.Producers.Entities
{
    public class Producer : BaseEntity<Producer>
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public ICollection<Dump> Dumps { get; set; }
        public ICollection<FavoriteEditor> FavoriteEditors { get; set; }
        public ICollection<ProducerModel> FavoriteModels { get; set; }
        public ICollection<MediaSet> MediaSets { get; set; }
        public ICollection<ChannelProducer> Channels { get; set; }
        public override void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(x => x.Producer)
                .HasForeignKey<Producer>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Dumps)
                .WithOne(x => x.Producer)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MediaSets)
                .WithOne(x => x.Producer)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.FavoriteEditors)
                .WithOne(x => x.Producer)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
