using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Media.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Media.Interfaces
{
    public interface IModelMediaSetService
    {
        Task<PagedList<T>> GetMediaSetsForModel<T>(IAdmin admin, int modelId, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;
    }
    public interface IMediaSetService
    {
        Task<PagedList<T>> GetMediaSets<T>(IAdmin admin, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;
        Task<PagedList<T>> GetMediaSets<T>(IConsumer consumer, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;
        Task<PagedList<T>> GetMediaSets<T>(IEditor editor, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;
        Task<PagedList<T>> GetMediaSets<T>(IProducer producer, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;
        Task<PagedList<T>> GetMediaSets<T>(IModel model, MediaSetQuery query, PagingQuery paging)
            where T : MediaSetDto;

        Task<T> GetMediaSet<T>(IAdmin admin, int mediaSetId) where T : MediaSetDto;
        Task<T> GetMediaSet<T>(IConsumer consumer, int mediaSetId) where T : MediaSetDto;
        Task<T> GetMediaSet<T>(IEditor editor, int mediaSetId) where T : MediaSetDto;
        Task<T> GetMediaSet<T>(IProducer producer, int mediaSetId) where T : MediaSetDto;
        Task<T> GetMediaSet<T>(IModel model, int mediaSetId) where T : MediaSetDto;

        Task<Result> CreateMediaSet(IEditor editor, MediaSetInput input);

        Task<Result> PublishMediaSet(IModel model, int providerId, int mediaSetId);
    }
}
