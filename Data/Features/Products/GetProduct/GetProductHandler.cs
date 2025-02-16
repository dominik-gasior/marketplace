using Core.Utils.Handling.Requests;
using Data.Features.Products.GetProduct.DTOs;
using Data.Utils.Results;
using Microsoft.EntityFrameworkCore;

namespace Data.Features.Products.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductRequest, Result<ProductDTO>>
{
    private readonly MarketplaceContext _context;

    public GetProductHandler(MarketplaceContext context)
    {
        _context = context;
    }

    public async Task<Result<ProductDTO>> Handle(GetProductRequest request, CancellationToken token = default)
    {
        var product = await _context.Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductDTO
            {
            })
            .FirstOrDefaultAsync(cancellationToken: token);

        if (product == null)
            return Result<ProductDTO>
                .Fail($"Product with Id: {request.ProductId} not found");
        
        return Result<ProductDTO>.Ok(product);
    }
}