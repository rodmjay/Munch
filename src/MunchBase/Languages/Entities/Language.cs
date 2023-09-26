#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Users.Entities;

namespace MunchBase.Languages.Entities
{
    public class Language : BaseEntity<Language>
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public virtual ICollection<LanguageCountry> Countries { get; set; }
        public ICollection<User> Users { get; set; }

        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code3);

            builder.HasMany(x => x.Countries)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.Code3);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.Code3);
        }
    }
}