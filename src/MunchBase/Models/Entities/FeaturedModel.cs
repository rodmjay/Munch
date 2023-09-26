using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Models.Entities;

public class FeaturedModel : BaseEntity<FeaturedModel>
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Place { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public override void Configure(EntityTypeBuilder<FeaturedModel> builder)
    {
        builder.HasKey(x => new {x.Year, x.Month, x.Place});
        builder.HasOne(x => x.Model)
            .WithMany(x => x.Features)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}