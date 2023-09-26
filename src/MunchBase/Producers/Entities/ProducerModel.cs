using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Models.Entities;

namespace MunchBase.Producers.Entities;

public class ProducerModel : BaseEntity<ProducerModel>
{
    public int ProducerId { get; set; }
    public Producer Producer { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public override void Configure(EntityTypeBuilder<ProducerModel> builder)
    {
        builder.HasKey(x => new {x.ProducerId, x.ModelId});

        builder.HasOne(x => x.Producer)
            .WithMany(x => x.FavoriteModels)
            .HasForeignKey(x => x.ProducerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Model)
            .WithMany(x => x.Producers)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}