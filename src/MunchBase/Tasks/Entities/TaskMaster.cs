using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Providers.Entities;

namespace MunchBase.Tasks.Entities
{
    public class TaskMaster : BaseEntity<TaskMaster>
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskType TaskType { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public string Recurrence { get; set; }

        public override void Configure(EntityTypeBuilder<TaskMaster> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Tasks)
                .WithOne(x => x.TaskMaster)
                .HasForeignKey(x => x.TaskMasterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Provider)
                .WithMany(x => x.TaskMasters)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}