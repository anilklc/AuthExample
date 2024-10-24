using AuthExample.Application.Consts;
using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Features.Commands.Brand.CreateBrand;
using AuthExample.Application.Features.Commands.Brand.RemoveBrand;
using AuthExample.Application.Features.Commands.Brand.UpdateBrand;
using AuthExample.Application.Features.Queries.Brand.GetAllBrand;
using AuthExample.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBrands()
        {
            GetAllBrandQueryResponse response = await _mediator.Send(new GetAllBrandQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdBrand([FromRoute] GetByIdBrandQueryRequest request)
        {
            GetByIdBrandQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

       
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Writing, Definition = "Create Brand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Writing, Definition = "Update Brand")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Deleting, Definition = "Delete Brand")]
        public async Task<IActionResult> RemoveBrand(string Id)
        {
            RemoveBrandCommandRequest request = new RemoveBrandCommandRequest { Id = Id };
            RemoveBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
