#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
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
    public class UserToken : IdentityUserToken<int>, IEntityTypeConfiguration<UserToken>, IObjectState
    {
        public User User { get; set; }

        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.LoginProvider,
                x.Name
            });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTokens)
                .HasForeignKey(x => x.UserId);
        }

        [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
    }
}