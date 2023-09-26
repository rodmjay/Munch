using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Models.Entities;

namespace MunchBase.Dumps.Entities;

public class DumpModel : BaseEntity<DumpModel>
{
    public int DumpId { get; set; }
    public Dump Dump { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public override void Configure(EntityTypeBuilder<DumpModel> builder)
    {
        builder.HasKey(x => new { x.DumpId, x.ModelId });
        builder.HasOne(x => x.Dump)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.DumpId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Model)
            .WithMany(x => x.Dumps)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}