#region Header

// /*
// Copyright (c) 2021 SolutionStream. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System.Diagnostics;
using System.Security.Principal;

namespace MunchBase.Common.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="IPrincipal" /> and
    ///     <see cref="IIdentity" /> .
    /// </summary>
    public static class PrincipalExtensions
    {
        /// <summary>
        ///     Determines whether this instance is authenticated.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <returns>
        ///     <c>true</c> if the specified principal is authenticated; otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsAuthenticated(this IPrincipal principal)
        {
            return principal is { Identity: { IsAuthenticated: true } };
        }
    }
}