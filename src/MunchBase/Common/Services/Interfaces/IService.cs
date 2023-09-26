#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using AutoMapper;
using MunchBase.Common.Data.Interfaces;

namespace MunchBase.Common.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class, IObjectState
    {
        public MapperConfiguration ProjectionMapping { get; }
        public IRepositoryAsync<TEntity> Repository { get; }
    }
}