using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;

namespace MunchBase.Models.Interfaces;

public interface IFeaturedModelService
{
    Task<Result> FeatureModel(IAdmin admin, int modelId);
}