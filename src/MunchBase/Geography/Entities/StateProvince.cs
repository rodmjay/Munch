#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Geography.Interfaces;

namespace MunchBase.Geography.Entities
{
    public class StateProvince : BaseEntity<StateProvince>, IStateProvince
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string Iso2 { get; set; }

        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string Code { get; set; }

        public override void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.StateProvinces)
                .HasForeignKey(x => x.Iso2);
        }
    }
}