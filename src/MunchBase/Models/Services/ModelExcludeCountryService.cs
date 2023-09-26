using System;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;

namespace MunchBase.Models.Services;

public class ModelExcludeCountryService : BaseService<ModelExcludedCountry>, IModelExcludeCountryService
{
    public ModelExcludeCountryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<Result> IncludeCountry(int modelId, string country)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ExcludeCountry(int modelId, string country)
    {
        throw new NotImplementedException();
    }
}