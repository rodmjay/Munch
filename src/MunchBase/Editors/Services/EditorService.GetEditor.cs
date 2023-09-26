using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Editors.Services;

public partial class EditorService
{
    public Task<T> GetEditor<T>(IEditor editor) where T : EditorDto
    {
        return GetEditor<T>(editor.Id);
    }

    public Task<T> GetEditor<T>(IAdmin admin, int editorId) where T : EditorDto
    {
        return GetEditor<T>(editorId);
    }

    public Task<T> GetEditor<T>(IProducer producer, int editorId) where T : EditorDto
    {
        return GetEditor<T>(editorId);
    }

    public Task<T> GetEditor<T>(IModel model, int editorId) where T : EditorDto
    {
        return GetEditor<T>(editorId);
    }

    private Task<T> GetEditor<T>(int editorId) where T : EditorDto
    {
        return Repository.Queryable().Where(x => x.Id == editorId)
            .ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

}