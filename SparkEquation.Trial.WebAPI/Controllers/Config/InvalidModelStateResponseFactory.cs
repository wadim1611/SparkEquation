using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Extensions;
using SparkEquation.Trial.WebAPI.Services.Communication;

namespace SparkEquation.Trial.WebAPI.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            return new BaseResponse(string.Join(';', errors)).MapToActionResult();
        }
    }
}
