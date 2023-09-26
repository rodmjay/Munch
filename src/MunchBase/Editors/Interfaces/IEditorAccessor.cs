using System.Security.Claims;

namespace MunchBase.Editors.Interfaces;

public interface IEditorAccessor
{
    IEditor GetEditor(ClaimsPrincipal principal);
}