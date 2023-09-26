#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MunchBase.Common.Validation
{
    public class ValidationResultModel
    {
        public ValidationResultModel()
        {
            Message = "Internal Server Error";
            Errors = new List<ValidationError>();
        }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }

        public string Message { get; }

        public List<ValidationError> Errors { get; }
    }
}