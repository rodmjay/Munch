using System.Threading.Tasks;
using MunchBase.Administration.ViewModels;

namespace MunchBase.Administration.Interfaces
{
    public interface IAdminService
    {
        Task<T> GetAdmin<T>(IAdmin admin) where T : AdminDto;
    }
}
