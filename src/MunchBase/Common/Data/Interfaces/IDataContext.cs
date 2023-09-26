#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IDataContext : IDisposable
    {
        DatabaseFacade DatabaseFacade { get; }
        object GetKey<TEntity>(TEntity entity);
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}