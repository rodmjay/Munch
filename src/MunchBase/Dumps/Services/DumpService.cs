using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Data.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Dumps.Entities;
using MunchBase.Dumps.Interfaces;
using MunchBase.Dumps.ViewModels;
using MunchBase.Editors.Entities;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Entities;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Services;

public partial class DumpService : BaseService<Dump>, IDumpService
{
    private readonly IRepositoryAsync<Model> _modelRepository;
    private readonly IRepositoryAsync<Channel> _channelRepository;
    private readonly IRepositoryAsync<Editor> _editorRepo;

    public DumpService(IServiceProvider serviceProvider,
        IRepositoryAsync<Model> modelRepository,
        IRepositoryAsync<Channel> channelRepository,
        IRepositoryAsync<Editor> editorRepo) : base(serviceProvider)
    {
        _modelRepository = modelRepository;
        _channelRepository = channelRepository;
        _editorRepo = editorRepo;
    }
    public IQueryable<Dump> ContentDumps => Repository.Queryable();
    public IQueryable<Channel> Channels => _channelRepository.Queryable();


    public async Task<Result> AssignToEditor(IProducer producer, int contentDumpId, IEditor editor)
    {
        var dump = await Repository.Queryable().Where(x => x.Id == contentDumpId)
            .FirstOrDefaultAsync();

        var ed = await Repository.Queryable().Where(x => x.Id == editor.Id)
            .FirstOrDefaultAsync();

        if (ed != null && dump != null)
        {
            dump.EditorId = ed.Id;
            dump.ObjectState = ObjectState.Added;

            var records = Repository.Commit();

            if(records > 0)
                return Result.Success(contentDumpId);
        }

        return Result.Failed();
    }

    public Task<Result> DeleteDump(IProducer producer, int contentDumpId)
    {
        throw new NotImplementedException();
    }


    public Task<List<T>> GetDumps<T>(int editorId, PagingQuery paging, DumpQuery query)
        where T : DumpDto
    {
        query.EditorId = editorId;
        throw new NotImplementedException();
    }

    public Task<T> GetContentDump<T>(int editorId, int contentDumpId) where T : DumpDto
    {
        return ContentDumps.Where(x => x.EditorId == editorId && x.Id == contentDumpId)
            .ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public async Task<Result> BeginWorkOnContentDump(int editorId, int contentDumpId)
    {
        var contentDump = await ContentDumps.Where(x => x.Id == contentDumpId && x.EditorId == editorId)
            .FirstAsync();



        return Result.Success(contentDumpId);
    }
}