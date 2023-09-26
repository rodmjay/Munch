using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Models.Interfaces;
using MunchBase.Providers.ViewModels;

namespace MunchBase.Providers.Services;

public partial class ProviderService
{
    public async Task<List<T>> GetProviders<T>(IModel model) where T : ProviderDto
    {
        var list = await Repository.Queryable()
            .Include(x => x.ModelProviders.Where(a => a.ModelId == model.Id))
            .Include(x => x.ProviderCapabilities)
            .ThenInclude(x => x.Capability).ToListAsync();

        return Mapper.Map<List<T>>(list);
    }

    public Task<List<T>> GetProviders<T>(IAdmin admin) where T : ProviderDto
    {
        return Providers.ProjectTo<T>(ProjectionMapping).ToListAsync();
    }
}