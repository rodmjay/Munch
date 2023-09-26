#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Threading;
using System.Threading.Tasks;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IDataContextAsync : IDataContext
    {
        //Task BeginTransactionAsync(DbIsolationLevel isolationLevel);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        Task SyncObjectsStatePostCommitAsync();
        Task<int> ExecuteSqlAsync(string query, params object[] parameters);
    }
}