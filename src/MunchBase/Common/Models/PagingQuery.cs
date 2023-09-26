﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion


namespace MunchBase.Common.Models
{
    public class PagingQuery
    {
        public string Sort { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}