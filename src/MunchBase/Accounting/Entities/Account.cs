using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Users.Entities;

namespace MunchBase.Accounting.Entities
{
    public class Account : BaseEntity<Account>
    {
        public int Id { get; set; }
        public User User { get; set; }
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.Id);
        }
    }
}
