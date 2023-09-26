#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Accounting.Entities;
using MunchBase.Administration.Entities;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Consumers.Entities;
using MunchBase.Editors.Entities;
using MunchBase.Geography.Entities;
using MunchBase.Languages.Entities;
using MunchBase.Models.Entities;
using MunchBase.Producers.Entities;
using MunchBase.Users.Interfaces;

namespace MunchBase.Users.Entities
{
    public class User : IdentityUser<int>, IEntityTypeConfiguration<User>, IObjectState,
        IUser
    {
        public User()
        {
            UserTokens = new List<UserToken>();
            UserLogins = new List<UserLogin>();
            UserClaims = new List<UserClaim>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;

        public ICollection<UserToken> UserTokens { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserClaim> UserClaims { get; set; }

        public Model Model { get; set; }
        public Consumer Consumer { get; set; }
        public Admin Admin { get; set; }
        public Editor Editor{ get; set; }
        public Producer Producer { get; set; }
        public Account Account { get; set; }
        public string Code3 { get; set; }

        public Language Language { get; set; }
        public string Iso2 { get; set; }
        public Country Country { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.FullName);

            builder.Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.UserTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserLogins)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserClaims)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Model)
                .WithOne(x => x.User)
                .HasForeignKey<Model>(x => x.Id);

            builder.HasOne(x => x.Consumer)
                .WithOne(x => x.User)
                .HasForeignKey<Consumer>(x => x.Id);

            builder.HasOne(x => x.Admin)
                .WithOne(x => x.User)
                .HasForeignKey<Admin>(x => x.Id);

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.Code3);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.Iso2);

            builder.HasOne(x => x.Editor)
                .WithOne(x => x.User)
                .HasForeignKey<Editor>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Producer)
                .WithOne(x => x.User)
                .HasForeignKey<Producer>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
        public string DisplayName { get; set; }
    }
}