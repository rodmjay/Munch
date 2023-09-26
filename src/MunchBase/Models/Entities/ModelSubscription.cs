using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Consumers.Entities;

namespace MunchBase.Models.Entities
{
    public class ModelSubscription : BaseEntity<ModelSubscription>
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public Consumer Consumer { get; set; }
        public int ConsumerId { get; set; }
        public override void Configure(EntityTypeBuilder<ModelSubscription> builder)
        {
            builder.HasKey(x => new { x.ModelId, x.ConsumerId });

            builder.HasOne(x => x.Consumer)
                .WithMany(x => x.ModelSubscriptions)
                .HasForeignKey(x => x.ConsumerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
