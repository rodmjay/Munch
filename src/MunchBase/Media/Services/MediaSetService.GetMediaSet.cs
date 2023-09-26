using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Media.ViewModels;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Media.Services;

public partial class MediaSetService
{
    public Task<T> GetMediaSet<T>(IAdmin admin, int mediaSetId) where T : MediaSetDto
    {
        return GetMediaSet<T>(mediaSetId);
    }

    public Task<T> GetMediaSet<T>(IConsumer consumer, int mediaSetId) where T : MediaSetDto
    {
        return GetMediaSet<T>(mediaSetId);
    }

    public Task<T> GetMediaSet<T>(IEditor editor, int mediaSetId) where T : MediaSetDto
    {
        return GetMediaSet<T>(mediaSetId);
    }

    public Task<T> GetMediaSet<T>(IProducer producer, int mediaSetId) where T : MediaSetDto
    {
        return GetMediaSet<T>(mediaSetId);
    }

    public Task<T> GetMediaSet<T>(IModel model, int mediaSetId) where T : MediaSetDto
    {
        return GetMediaSet<T>(mediaSetId);
    }

    private Task<T> GetMediaSet<T>( int mediaSetId) where T : MediaSetDto
    {
        return MediaSets.Where(x => x.Id == mediaSetId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }
}