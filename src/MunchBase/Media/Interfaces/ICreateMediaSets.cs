using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Media.ViewModels;

namespace MunchBase.Media.Interfaces;

public interface ICreateMediaSets
{
    Task<Result> CreateMediaSet([FromBody] MediaSetInput input);
}