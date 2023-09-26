using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Editors.ViewModels;

namespace MunchBase.Editors.Interfaces;

public interface IAdminEditorService
{
    Task<List<T>> GetEditors<T>(int adminId, PagingQuery paging, EditorQuery query) where T : EditorDto;
    Task<Result> CreateEditor(int adminId);
    Task<Result> AssignEditorToModel(int adminId, int editorId, int modelId);
}