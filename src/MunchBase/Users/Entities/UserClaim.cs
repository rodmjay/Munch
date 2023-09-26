#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;

namespace MunchBase.Users.Entities
{
    public class UserClaim : IdentityUserClaim<int>, IEntityTypeConfiguration<UserClaim>, IObjectState
    {
        public User User { get; set; }

        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.UserId);
        }

        [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
    }
}