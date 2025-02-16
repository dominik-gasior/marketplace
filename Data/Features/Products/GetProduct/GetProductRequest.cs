using Core.Utils.Handling.Requests;
using Data.Features.Products.GetProduct.DTOs;
using Data.Utils.Results;

namespace Data.Features.Products.GetProduct;

public record GetProductRequest(Guid ProductId) : IRequest<Result<ProductDTO>>;