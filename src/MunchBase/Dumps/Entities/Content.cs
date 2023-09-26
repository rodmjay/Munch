using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Dumps.Entities;
public class Content : BaseEntity<Content>
{
    public int Id { get; set; }
    public string Url { get; set; }
    public Dump Dump { get; set; }
    public int ContentDumpId { get; set; }
    public override void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Dump)
            .WithMany(x => x.Content)
            .HasForeignKey(x => x.ContentDumpId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}