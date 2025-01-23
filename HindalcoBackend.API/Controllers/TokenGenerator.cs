using Microsoft.AspNetCore.Mvc;
using HindalcoBackend.Application.CommandClass;
using HindalcoBackend.Business.Service;
using HindalcoBackend.Domain.Interface;
using MediatR;



namespace HindalcoBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenGenerator : ControllerBase
    {
        private readonly HindalcoBackend.Business.Service.AuditManager _queryService;
        private readonly IMediator _mediator;
        public TokenGenerator(IMediator mediator, HindalcoBackend.Business.Service.AuditManager auditManager)
        {
            _queryService = auditManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new HindalcoBackend.Application.Models.TokenGenerator.Query());
            return Ok(products);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        //{
        //    var id = await _commandService.AddProductAsync(dto.Name, dto.Price);
        //    return CreatedAtAction(nameof(Get), new { id }, id);
        //}

    }
}
