using System;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Editors.Entities;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.ViewModels;

namespace MunchBase.Editors.Services
{
    public partial class EditorService : BaseService<Editor>, IEditorService
    {
        public EditorService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<Result> UpdateEditorProfile(IEditor editor, EditorInput input)
        {
            throw new NotImplementedException();
        }
    }
}
