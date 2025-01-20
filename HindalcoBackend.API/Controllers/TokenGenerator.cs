using Microsoft.AspNetCore.Mvc;

namespace HindalcoBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenGenerator : ControllerBase
    {
        //private readonly IProductQueryService _queryService;
        //private readonly IProductCommandService _commandService;

        //public TokenGenerator(IProductQueryService queryService, IProductCommandService commandService)
        //{
        //    _queryService = queryService;
        //    _commandService = commandService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var products = await _queryService.GetProductsAsync();
        //    return Ok(products);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        //{
        //    var id = await _commandService.AddProductAsync(dto.Name, dto.Price);
        //    return CreatedAtAction(nameof(Get), new { id }, id);
        //}

    }
}
