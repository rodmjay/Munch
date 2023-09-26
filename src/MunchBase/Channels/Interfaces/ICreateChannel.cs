using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Models;

namespace MunchBase.Channels.Interfaces;

public interface ICreateChannel
{
    Task<Result> CreateChannel([FromBody] ChannelInput input);
}