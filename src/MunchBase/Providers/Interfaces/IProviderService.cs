using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Providers.Interfaces
{
    public interface IProviderService
    {
        Task<List<T>> GetProviders<T>(IModel model) where T : ProviderDto;
        Task<List<T>> GetProviders<T>(IAdmin admin) where T : ProviderDto;
        Task<Result> EnableProvider(IModel model, int providerId, string username);
        Task<Result> DisableProvider(IModel model, int providerId);
    }
}
