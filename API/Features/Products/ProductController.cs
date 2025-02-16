using Core.Utils.Handling;
using Data.Features.Products.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Products;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("{id}")]
    public async Task<IActionResult> GetProducts([FromRoute] Guid id)
    {
        var request = new GetProductRequest(id);
        var result = await _mediator.SendAsync(request);

        return Ok(result.Value); // TODO Result extension methodw
    }
}