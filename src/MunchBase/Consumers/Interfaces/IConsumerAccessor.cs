using System.Security.Claims;

namespace MunchBase.Consumers.Interfaces;

public interface IConsumerAccessor
{
    IConsumer GetConsumer(ClaimsPrincipal principal);
}