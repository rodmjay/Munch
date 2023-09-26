#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;

namespace MunchBase.Common.Validation.Interfaces
{
    public interface IValidationContainer
    {
        IDictionary<string, IList<string>> ValidationErrors { get; }
        bool IsValid { get; }
    }

    public interface IValidationContainer<out T> : IValidationContainer
    {
        T Entity { get; }
    }
}