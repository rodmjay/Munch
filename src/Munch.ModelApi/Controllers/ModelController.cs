using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Munch.ModelApi.ViewModels;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;

namespace Munch.ModelApi.Controllers
{
    public class ModelController : BaseModelController
    {
        private readonly IModelService _modelService;
        public ModelController(
            IServiceProvider serviceProvider, IModelService modelService) : base(serviceProvider)
        {
            _modelService = modelService;
        }
        
        [HttpGet]
        public Task<ModelModelDetailsDto> GetProfile()
        {
            return _modelService.GetProfile<ModelModelDetailsDto>(Model);
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<Result> CreateProfile(ModelInput input)
        {
            return _modelService.CreateModelAccount(1, input);
        }

        [HttpPut]
        public Task<Result> UpdateProfile(ModelInput input)
        {
            return _modelService.UpdateProfile(Model, input);
        }
    }
}
