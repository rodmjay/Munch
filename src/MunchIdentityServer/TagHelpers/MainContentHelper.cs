﻿#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Munch.IdentityServer.TagHelpers
{
    [HtmlTargetElement("ss-main-content", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class MainContentHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("ss-main-content", HtmlEncoder.Default);
            output.AddClass("flex-column", HtmlEncoder.Default);
            output.AddClass("d-flex", HtmlEncoder.Default);
            output.AddClass("align-content-center", HtmlEncoder.Default);
            output.AddClass("m-auto", HtmlEncoder.Default);
        }
    }
}