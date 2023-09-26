using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;

namespace Munch.AdminApi.Controllers;

public class ApprovalsController : BaseAdminController
{
    public ApprovalsController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpPatch("{photoSetId}")]
    public Task<Result> ApprovePhotoSet([FromRoute]int photoSetId)
    {
        throw new NotImplementedException();
    }

}