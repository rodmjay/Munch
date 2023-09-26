#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Geography.Entities;

namespace MunchBase.Languages.Entities
{
    public class LanguageCountry : BaseEntity<LanguageCountry>
    {
        public string Iso2 { get; set; }
        public Country Country { get; set; }
        public string Code3 { get; set; }
        public Language Language { get; set; }
        public bool Default { get; set; }

        public override void Configure(EntityTypeBuilder<LanguageCountry> builder)
        {
            builder.HasKey(x => new { x.Iso2, x.Code3 });

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Languages)
                .HasForeignKey(x => x.Iso2);
        }
    }
}