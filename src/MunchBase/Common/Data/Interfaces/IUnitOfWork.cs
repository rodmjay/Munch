#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Data.Enums;
using System;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        event EventHandler OnSaveChanges;
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(DbIsolationLevel isolationLevel = DbIsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}