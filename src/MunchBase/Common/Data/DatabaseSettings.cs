#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Diagnostics.CodeAnalysis;

namespace MunchBase.Common.Data
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings
    {
        public int Timeout { get; set; }
        public string ConnectionStringName { get; set; }
    }
}