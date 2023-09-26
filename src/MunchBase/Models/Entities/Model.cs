using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MunchBase.Dumps.Entities;
using MunchBase.Editors.Entities;
using MunchBase.Tasks.Entities;
using MunchBase.Users.Entities;
using MunchBase.Producers.Entities;

namespace MunchBase.Models.Entities
{
    public class Model : BaseEntity<Model>
    {
        public int Id { get; set; }
        public User User { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public ICollection<ModelMediaSet> MediaSets { get; set; }
        public ICollection<ModelProvider> Providers { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<ModelSubscription> Subscriptions { get; set; }
        public ICollection<ModelExcludedCountry> ExcludedCountries { get; set; }
        public ICollection<EditorModel> Editors { get; set; }
        public ICollection<DumpModel> Dumps { get; set; }
        public ICollection<FeaturedModel> Features { get; set; }
        public ICollection<ProducerModel> Producers { get; set; }
        public override void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(x => x.Model)
                .HasForeignKey<Model>(x => x.Id);

            builder.HasMany(x => x.Providers)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tasks)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.MediaSets)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Subscriptions)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ExcludedCountries)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Editors)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Features)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Dumps)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
