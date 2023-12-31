﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MunchBase.Common.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Result
    {
        private readonly List<Error> _errors = new();

        public bool Succeeded { get; protected set; }
        public object Id { get; protected set; }

        [JsonProperty]
        public IEnumerable<Error> Errors
        {
            get
            {
                if (Succeeded) return null;
                return _errors;
            }
        }

        public static Result Success(object id)
        {
            return new()
            {
                Succeeded = true,
                Id = id
            };
        }

        public static Result Success()
        {
            return new()
            {
                Succeeded = true
            };
        }

        public static Result Failed(params Error[] errors)
        {
            var result = new Result { Succeeded = false };
            if (errors != null) result._errors.AddRange(errors);
            return result;
        }

        public override string ToString()
        {
            return Succeeded
                ? "Succeeded"
                : string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }
}