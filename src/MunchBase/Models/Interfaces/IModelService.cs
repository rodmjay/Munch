using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.ViewModels;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Models.Interfaces
{
    public interface IModelService
    {
        Task<PagedList<T>> GetModels<T>(IAdmin admin, PagingQuery paging, ModelQuery query) where T : ModelDto;
        Task<PagedList<T>> GetModels<T>(IEditor editor, PagingQuery paging, ModelQuery query) where T : ModelDto;
        Task<PagedList<T>> GetModels<T>(IProducer producer, PagingQuery paging, ModelQuery query) where T : ModelDto;
        Task<PagedList<T>> GetModels<T>(IModel model, PagingQuery paging, ModelQuery query) where T : ModelDto;
        Task<PagedList<T>> GetModels<T>(IConsumer consumer, PagingQuery paging, ModelQuery query) where T : ModelDto;
        Task<T> GetModel<T>(IConsumer consumer, int modelId) where T : ModelDto;
        Task<T> GetModel<T>(IAdmin admin, int modelId) where T : ModelDto;
        Task<T> GetModel<T>(IModel model, int modelId) where T : ModelDto;
        Task<T> GetModel<T>(IEditor editor, int modelId) where T : ModelDto;
        Task<T> GetModel<T>(IProducer producer, int modelId) where T : ModelDto;

        Task<Result> Subscribe(IConsumer consumer, int modelId);
        Task<Result> Unsubscribe(IConsumer consumer, int modelId);
        Task<Result> CreateModelAccount(int userId, ModelInput input);
        Task<T> GetProfile<T>(IModel model) where T : ModelDto;
        Task<Result> UpdateProfile(IModel model, ModelInput input);

    }
}
