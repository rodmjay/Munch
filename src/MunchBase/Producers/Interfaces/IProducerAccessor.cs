using System.Security.Claims;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Interfaces;

public interface IProducerAccessor
{
    IProducer GetProducer(ClaimsPrincipal principal);
}