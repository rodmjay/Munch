using MunchBase.Editors.Interfaces;

namespace MunchBase.Editors.ViewModels
{
    public class EditorDto : IEditor
    {
        public bool Active { get; set; }
        public string DisplayName { get; set; }
        public int Id { get; set; }
    }
    
}
