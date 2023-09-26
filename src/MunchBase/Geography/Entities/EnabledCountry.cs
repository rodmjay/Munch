#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Geography.Entities
{
    public class EnabledCountry : BaseEntity<EnabledCountry>
    {
        public string Iso2 { get; set; }
        public Country Country { get; set; }

        public override void Configure(EntityTypeBuilder<EnabledCountry> builder)
        {
            builder.HasKey(x => x.Iso2);

            builder.HasOne(x => x.Country)
                .WithOne(x => x.EnabledCountry)
                .HasForeignKey<EnabledCountry>(x => x.Iso2);
        }
    }
}