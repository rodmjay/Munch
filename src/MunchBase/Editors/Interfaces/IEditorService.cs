using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Editors.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Editors.Interfaces;

public interface IEditorService
{
    Task<T> GetEditor<T>(IEditor editor) where T : EditorDto;
    Task<T> GetEditor<T>(IAdmin admin, int editorId) where T : EditorDto;
    Task<T> GetEditor<T>(IProducer producer, int editorId) where T : EditorDto;
    Task<T> GetEditor<T>(IModel model, int editorId) where T : EditorDto;
    Task<Result> UpdateEditorProfile(IEditor editor, EditorInput input);

    Task<PagedList<T>> GetEditors<T>(IAdmin admin, EditorQuery query, PagingQuery paging) where T: EditorDto;
    Task<PagedList<T>> GetEditors<T>(IProducer producers, EditorQuery query, PagingQuery paging) where T: EditorDto;
    Task<PagedList<T>> GetEditors<T>(IModel model, EditorQuery query, PagingQuery paging) where T: EditorDto;
}