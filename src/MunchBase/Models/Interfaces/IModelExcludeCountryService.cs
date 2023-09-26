using System.Threading.Tasks;
using MunchBase.Common.Models;

namespace MunchBase.Models.Interfaces;

public interface IModelExcludeCountryService
{
    Task<Result> IncludeCountry(int modelId, string country);
    Task<Result> ExcludeCountry(int modelId, string country);
}