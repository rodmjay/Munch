using System.Security.Claims;

namespace MunchBase.Models.Interfaces;

public interface IModelAccessor
{
    IModel GetModel(ClaimsPrincipal principal);
}