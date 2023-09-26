#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Geography.Interfaces;
using MunchBase.Languages.Entities;
using MunchBase.Models.Entities;
using MunchBase.Users.Entities;

namespace MunchBase.Geography.Entities
{
    public class Country : BaseEntity<Country>, ICountry
    {
        public ICollection<StateProvince> StateProvinces { get; set; }
        public virtual ICollection<LanguageCountry> Languages { get; set; }
        public virtual EnabledCountry EnabledCountry { get; set; }
        public string Iso2 { get; set; }

        public string Name { get; set; }
        public string CapsName { get; set; }
        public string Iso3 { get; set; }
        public int? NumberCode { get; set; }
        public int PhoneCode { get; set; }
        public ICollection<ModelExcludedCountry> ModelExcludedCountries { get; set; }
        public ICollection<User> Users { get; set; }

        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Iso2);

            builder.Property(x => x.Iso2)
                .HasMaxLength(2);

            builder.Property(x => x.Iso3)
                .HasMaxLength(3);

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasIndex(x => x.Iso2);

            builder.HasIndex(x => x.Iso3);

            builder.HasMany(x => x.StateProvinces)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Iso2);

            builder.HasOne(x => x.EnabledCountry)
                .WithOne(x => x.Country)
                .HasForeignKey<EnabledCountry>(x => x.Iso2);

            builder.HasMany(x => x.Languages)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Iso2);

            builder.HasMany(x => x.ModelExcludedCountries)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Iso2)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Iso2);
        }
    }
}