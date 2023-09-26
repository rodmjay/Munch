using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Models.Entities;

namespace MunchBase.Editors.Entities;

public class EditorModel : BaseEntity<EditorModel>
{
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public int EditorId { get; set; }
    public Editor Editor { get; set; }

    public override void Configure(EntityTypeBuilder<EditorModel> builder)
    {
        builder.HasKey(x => new { x.ModelId, x.EditorId });

        builder.HasOne(x => x.Model)
            .WithMany(x => x.Editors)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Editor)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.EditorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}