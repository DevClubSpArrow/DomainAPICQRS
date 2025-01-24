using Microsoft.AspNetCore.Mvc;
using HindalcoBackend.Application.CommandClass;
using HindalcoBackend.Business.Service;
using HindalcoBackend.Domain.Interface;
using MediatR;
using HindalcoBackend.Application.DataModels;



namespace HindalcoBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenGenerator : ControllerBase
    {
        private readonly HindalcoBackend.Application.Interface.IBusiness _business;
        private readonly IMediator _mediator;
        public TokenGenerator(IMediator mediator, HindalcoBackend.Application.Interface.IBusiness business)
        {
            _business = business;
            _mediator = mediator;
        }
               
        [HttpPost]
        public async Task<HindalcoBackend.Business.ResponseToken> GenerateToken([FromBody] HindalcoBackend.Business.UserModel umodel)
        {
           return await _business.Generatetoken(umodel);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        //{
        //    var id = await _commandService.AddProductAsync(dto.Name, dto.Price);
        //    return CreatedAtAction(nameof(Get), new { id }, id);
        //}

    }
}
