using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Providers.Interfaces;

public interface IAdminProviderService
{
    Task<List<T>> GetProviders<T>(int modelId) where T : ProviderDto;
}