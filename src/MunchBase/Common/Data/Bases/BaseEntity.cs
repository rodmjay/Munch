#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Validation;

namespace MunchBase.Common.Data.Bases
{
    public abstract class BaseEntity : ValidatableModel, IObjectState
    {
        [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
    }

    public abstract class BaseEntity<T> : BaseEntity, IEntityTypeConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}