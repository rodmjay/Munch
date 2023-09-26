using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Dumps.Entities;
using MunchBase.Media.Entities;
using MunchBase.Producers.Entities;
using MunchBase.Users.Entities;

namespace MunchBase.Editors.Entities
{
    public class Editor : BaseEntity<Editor>
    {
        public int Id { get; set; }
        public User User { get; set; }
        public bool Active { get; set; }

        public ICollection<EditSession> Sessions { get; set; }
        public ICollection<EditorModel> Models { get; set; }
        public ICollection<MediaSet> MediaSets { get; set; }
        public ICollection<Dump> ContentDumps { get; set; }
         
        public ICollection<FavoriteEditor> Producers { get; set; }

        public override void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(x => x.Editor)
                .HasForeignKey<Editor>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Models)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Sessions)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.MediaSets)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ContentDumps)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
