using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.ViewModels;

namespace MunchBase.Media.Interfaces;

public interface IReadMediaSets<T> where T : MediaSetDto
{
    Task<PagedList<T>> GetMediaSets([FromQuery] PagingQuery paging, [FromQuery]MediaSetQuery query);
    Task<T> GetMediaSet([FromRoute]int mediaSetId);
}