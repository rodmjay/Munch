#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TemplateBase.IntegrationTests.Extensions
{
    public static class ObjectExtensions
    {
        public static StringContent SerializeToUTF8Json(this object model)
        {
            return new(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }
    }
}