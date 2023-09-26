#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MunchBase.Common.Validation.Interfaces
{
    public interface IValidator<T> where T : class, IObjectState
    {
        ValidationResult Validate(IService<T> service, T account, string value);
    }
}