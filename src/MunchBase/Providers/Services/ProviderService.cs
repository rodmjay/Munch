using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Providers.Entities;
using MunchBase.Providers.Interfaces;

namespace MunchBase.Providers.Services
{
    public partial class ProviderService : BaseService<Provider>, IProviderService
    {
        private readonly IRepositoryAsync<Provider> _providerRepo;
        private readonly IRepositoryAsync<ModelProvider> _modelProviderRepo;
        public IQueryable<Provider> Providers => Repository.Queryable();
        public ProviderService(IServiceProvider serviceProvider,
            IRepositoryAsync<Provider> providerRepo,
            IRepositoryAsync<ModelProvider> modelProviderRepo) : base(serviceProvider)
        {
            _providerRepo = providerRepo;
            _modelProviderRepo = modelProviderRepo;
        }

        public async Task<Result> EnableProvider(IModel model, int providerId, string username)
        {
            var existing = await _modelProviderRepo.Queryable()
                .Where(x => x.ModelId == model.Id && x.ProviderId == providerId)
                .FirstOrDefaultAsync();

            var provider = await _providerRepo.FirstOrDefaultAsync(x => x.Id == providerId);

            if (existing == null && provider != null)
            {
                var modelProvider = new ModelProvider
                {
                    ProviderId = providerId,
                    ModelId = model.Id,
                    Username = username,
                    ObjectState = ObjectState.Added
                };
                var records = _modelProviderRepo.InsertOrUpdateGraph(modelProvider, true);
                if (records > 0)
                    return Result.Success();
            }

            return Result.Failed();
        }

        public async Task<Result> DisableProvider(IModel model, int providerId)
        {
            var existing = await _modelProviderRepo.Queryable()
                .Where(x => x.ModelId == model.Id && x.ProviderId == providerId)
                .FirstOrDefaultAsync();
            var provider = await _providerRepo.FirstOrDefaultAsync(x => x.Id == providerId);

            if (existing != null && provider != null)
            {
                bool success =await _modelProviderRepo.DeleteAsync(existing, true);
                if(success)
                    return Result.Success();
            }

            return Result.Failed();

        }
    }
}
