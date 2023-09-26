using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Bases;
using MunchBase.Media.Entities;
using MunchBase.Models.Entities;
using MunchBase.Users.Entities;

namespace MunchBase.Consumers.Entities;

public class Consumer : BaseEntity<Consumer>
{
    public int Id { get; set; }
    public User User { get; set; }
    public bool Active { get; set; }

    public ICollection<ModelSubscription> ModelSubscriptions { get; set; }
    public ICollection<ChannelSubscription> ChannelSubscriptions { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public override void Configure(EntityTypeBuilder<Consumer> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne(x => x.Consumer)
            .HasForeignKey<Consumer>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.ModelSubscriptions)
            .WithOne(x => x.Consumer)
            .HasForeignKey(x => x.ConsumerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.ChannelSubscriptions)
            .WithOne(x => x.Consumer)
            .HasForeignKey(x => x.ConsumerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Consumer)
            .HasForeignKey(x => x.ConsumerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}