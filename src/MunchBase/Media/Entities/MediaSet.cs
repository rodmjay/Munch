using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Bases;
using MunchBase.Editors.Entities;
using MunchBase.Models.Entities;
using MunchBase.Producers.Entities;

namespace MunchBase.Media.Entities;

public class MediaSet : BaseEntity<MediaSet>
{
    public MediaSet()
    {
        this.Media = new List<Media>();
        this.Models = new List<ModelMediaSet>();
        this.Channels = new List<ChannelMediaSet>();
        this.Comments = new List<Comment>();
        this.Providers = new List<MediaSetProvider>();
    }
    public int Id { get; set; }
    public ICollection<Media> Media { get; set; }
    public ICollection<ModelMediaSet> Models { get; set; }
    public ICollection<ChannelMediaSet> Channels { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<MediaSetProvider> Providers { get; set; }
    public int EditorId { get; set; }
    public Editor Editor { get; set; }
    public int ProducerId { get; set; }
    public Producer Producer { get; set; }
    public string Caption { get; set; }
    
    public override void Configure(EntityTypeBuilder<MediaSet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Media)
            .WithOne(x => x.MediaSet)
            .IsRequired(false)
            .HasForeignKey(x => x.MediaSetId);

        builder.HasMany(x => x.Models)
            .WithOne(x => x.MediaSet)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Channels)
            .WithOne(x => x.MediaSet)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.MediaSet)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Editor)
            .WithMany(x => x.MediaSets)
            .HasForeignKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Producer)
            .WithMany(x => x.MediaSets)
            .HasForeignKey(x => x.ProducerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}