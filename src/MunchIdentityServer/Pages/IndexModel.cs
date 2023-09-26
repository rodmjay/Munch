#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MunchBase.Users.Managers;

namespace Munch.IdentityServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager _signinManager;

        public IndexModel(SignInManager signinManager)
        {
            _signinManager = signinManager;
        }

        public IActionResult OnGet()
        {
            if (_signinManager.IsSignedIn(User)) return LocalRedirect("/Account/Manage");

            return LocalRedirect("/Account/Login");
        }
    }
}