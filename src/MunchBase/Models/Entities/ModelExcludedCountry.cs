using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Geography.Entities;

namespace MunchBase.Models.Entities;

public class ModelExcludedCountry : BaseEntity<ModelExcludedCountry>
{
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public string Iso2 { get; set; }
    public Country Country { get; set; }
    public override void Configure(EntityTypeBuilder<ModelExcludedCountry> builder)
    {
        builder.HasKey(x => new {x.ModelId, x.Iso2});

        builder.HasOne(x => x.Model)
            .WithMany(x => x.ExcludedCountries)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.ModelExcludedCountries)
            .HasForeignKey(x => x.Iso2)
            .OnDelete(DeleteBehavior.Cascade);

    }
}