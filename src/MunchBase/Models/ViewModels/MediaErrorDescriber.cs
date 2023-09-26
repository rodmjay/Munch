using MunchBase.Common.Models;

namespace MunchBase.Models.ViewModels;

public class MediaErrorDescriber
{
    public virtual Error PhotosetDoesntExist()
    {
        return new()
        {
            Code = nameof(PhotosetDoesntExist),
            Description = "Photoset doesn't exist"
        };
    }
    public virtual Error ModelDoesntExistInPhotoSet()
    {
        return new()
        {
            Code = nameof(ModelDoesntExistInPhotoSet),
            Description = "Model doesn't exist in photoset"
        };
    }

    public virtual Error PhotoSetNotAllowedForProvider()
    {
        return new()
        {
            Code = nameof(PhotoSetNotAllowedForProvider),
            Description = "Photoset not allowed for provider"
        };
    }

    public virtual Error PhotoSetAlreadyPublished()
    {
        return new()
        {
            Code = nameof(PhotoSetAlreadyPublished),
            Description = "Photoset already published"
        };
    }
}