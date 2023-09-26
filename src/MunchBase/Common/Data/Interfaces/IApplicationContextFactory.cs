#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.EntityFrameworkCore.Design;
using MunchBase.Common.Data.Contexts;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
    }
}