using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Dumps.Entities;
using MunchBase.Media.Entities;
using MunchBase.Media.Interfaces;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;
using MunchBase.Providers.Entities;

namespace MunchBase.Media.Services;

public partial class MediaSetService : BaseService<MediaSet>, IMediaSetService
{
    private readonly MediaErrorDescriber _errorDescriber;
    private readonly IRepositoryAsync<Provider> _providerRepo;
    private readonly IRepositoryAsync<Dump> _dumpRepo;
    private readonly IRepositoryAsync<Channel> _channelRepo;
    private readonly IRepositoryAsync<ModelMediaSet> _modelMediaSetRepo;
    private readonly IRepositoryAsync<MediaSetProvider> _mediaSetProviderRepo;
    private readonly IRepositoryAsync<ModelProviderMediaSet> _modelProviderMediaSetRepo;
    private readonly IRepositoryAsync<Model> _modelRepo;


    public MediaSetService(IServiceProvider serviceProvider,
        MediaErrorDescriber errorDescriber,
        IRepositoryAsync<Provider> providerRepo,
        IRepositoryAsync<Dump> dumpRepo,
        IRepositoryAsync<Channel> channelRepo,
        IRepositoryAsync<ModelMediaSet> modelMediaSetRepo,
        IRepositoryAsync<MediaSetProvider> mediaSetProviderRepo,
        IRepositoryAsync<ModelProviderMediaSet> modelProviderMediaSetRepo,
        IRepositoryAsync<Model> modelRepo) : base(serviceProvider)
    {
        _errorDescriber = errorDescriber;
        _providerRepo = providerRepo;
        _dumpRepo = dumpRepo;
        _channelRepo = channelRepo;
        _modelMediaSetRepo = modelMediaSetRepo;
        _mediaSetProviderRepo = mediaSetProviderRepo;
        _modelProviderMediaSetRepo = modelProviderMediaSetRepo;
        _modelRepo = modelRepo;
    }

    public IQueryable<MediaSet> MediaSets => Repository.Queryable();
    public IQueryable<Provider> Providers => _providerRepo.Queryable();
    public IQueryable<Model> Models => _modelRepo.Queryable();
    public IQueryable<Channel> Channels => _channelRepo.Queryable();
    public IQueryable<Dump> Dumps => _dumpRepo.Queryable();
    public async Task<Result> PublishMediaSet(IModel model, int providerId, int mediaSetId)
    {
        var mediaSet = await Repository.Queryable().Where(x => x.Id == mediaSetId)
            .Include(x => x.Providers.Where(a => a.ProviderId == providerId))
            .ThenInclude(x => x.PublishedMediaSets.Where(a => a.ModelId == model.Id))
            .Include(x => x.Models.Where(a => a.ModelId == model.Id))
            .FirstOrDefaultAsync();

        if (mediaSet == null)
            return Result.Failed(_errorDescriber.PhotosetDoesntExist());

        var photoSetProvider = mediaSet.Providers.FirstOrDefault();
        var existsModel = mediaSet.Models.Any();

        if (!existsModel)
        {
            return Result.Failed(_errorDescriber.ModelDoesntExistInPhotoSet());
        }

        if (photoSetProvider == null)
        {
            return Result.Failed(_errorDescriber.PhotoSetNotAllowedForProvider());
        }

        if (photoSetProvider.PublishedMediaSets.Any())
        {
            return Result.Failed(_errorDescriber.PhotoSetAlreadyPublished());
        }

        var publication = new ModelProviderMediaSet()
        {
            ModelId = model.Id,
            ProviderId = providerId,
            MediaSetId = mediaSetId,
            ObjectState = ObjectState.Added
        };

        var records = await _modelProviderMediaSetRepo.InsertAsync(publication, true);
        if (records > 0)
            return Result.Success();

        return Result.Failed();
    }
}