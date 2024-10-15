using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Interfaces.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("[action]")]
        [AuthorizeDefinition(ActionType = ActionType.Reading,Definition = "Get Authorize Definition",Menu ="Application Service")] 
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
