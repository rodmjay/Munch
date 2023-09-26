using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using System;
using Microsoft.EntityFrameworkCore;
using MunchBase.Models.Entities;

namespace MunchBase.Tasks.Entities
{
    public class Task : BaseEntity<Task>
    {
        public int Id { get; set; }
        public int TaskMasterId { get; set; }
        public TaskMaster TaskMaster { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime? TargetDate { get; set; }
        public bool Completed { get; set; }

        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.HasOne(x => x.TaskMaster)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TaskMasterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
