#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace MunchBase.Common.Caching
{
    [ExcludeFromCodeCoverage]
    public class CacheSettings
    {
        public TimeSpan? DefaultExpiration { get; set; }
    }
}