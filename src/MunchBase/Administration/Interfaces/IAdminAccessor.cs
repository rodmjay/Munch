using System.Security.Claims;

namespace MunchBase.Administration.Interfaces;

public interface IAdminAccessor
{
    IAdmin GetAdmin(ClaimsPrincipal principal);
}