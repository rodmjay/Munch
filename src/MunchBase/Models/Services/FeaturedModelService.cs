using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;

namespace MunchBase.Models.Services;

public class FeaturedModelService : BaseService<FeaturedModel>, IFeaturedModelService
{
    private readonly IRepositoryAsync<Model> _modelRepo;

    public FeaturedModelService(IServiceProvider serviceProvider, IRepositoryAsync<Model> modelRepo) : base(serviceProvider)
    {
        _modelRepo = modelRepo;
    }

    public async Task<Result> FeatureModel(IAdmin admin, int modelId)
    {


        var model = await _modelRepo.Queryable().Where(x => x.Id == modelId)
            .FirstAsync();

        var featuredModel = new FeaturedModel()
        {
            ModelId = model.Id,
            Year = DateTime.Now.Year,
            Month = DateTime.Now.Month,
            ObjectState = ObjectState.Added
        };

        var records = Repository.InsertOrUpdateGraph(featuredModel, true);

        if (records > 0)
            return Result.Success(modelId);

        return Result.Failed();
    }
}