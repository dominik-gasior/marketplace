using Data.Utils.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Utils.Extensions;

internal static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T?> result)
        => result.IsSuccess 
            ? new OkObjectResult(result.Value) 
            : new BadRequestObjectResult(result.ErrorMessage);
}