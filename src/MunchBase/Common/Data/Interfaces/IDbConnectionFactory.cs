﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Data;

namespace MunchBase.Common.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection DbConnection { get; }
    }
}