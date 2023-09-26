using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using MunchBase.Common.Services.Bases;
using MunchBase.Editors.Entities;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.ViewModels;
using MunchBase.Users.Managers;

namespace MunchBase.Editors.Services
{
    public class EditorAccessor : BaseService<Editor>, IEditorAccessor
    {
        private readonly UserManager _userManager;

        public EditorAccessor(
            UserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public IEditor GetEditor(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);

            var userId = int.Parse(id);

            return Repository.Queryable().Where(x => x.Id == userId)
                .ProjectTo<EditorDto>(ProjectionMapping)
                .Cast<IEditor>()
                .First();
        }
    }
}
