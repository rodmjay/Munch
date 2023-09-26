using MunchBase.Administration.Interfaces;

namespace MunchBase.Administration.ViewModels
{
    public class AdminDto : IAdmin
    {
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
    }
}
