#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Timezones.Entities
{
    public class Timezone : BaseEntity<Timezone>
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public override void Configure(EntityTypeBuilder<Timezone> builder)
        {
            builder.HasKey(x => new { x.Name, x.Code });
        }
    }
}