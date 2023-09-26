using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Editors.Entities;

namespace MunchBase.Producers.Entities;

public class FavoriteEditor : BaseEntity<FavoriteEditor>
{
    public int ProducerId { get; set; }
    public Producer Producer { get; set; }
    public int EditorId { get; set; }
    public Editor Editor { get; set; }
    public override void Configure(EntityTypeBuilder<FavoriteEditor> builder)
    {
        builder.HasKey(x => new {x.ProducerId, x.EditorId});

        builder.HasOne(x => x.Editor)
            .WithMany(x => x.Producers)
            .HasForeignKey(x => x.EditorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Producer)
            .WithMany(x => x.FavoriteEditors)
            .HasForeignKey(x => x.ProducerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}