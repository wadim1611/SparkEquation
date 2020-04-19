using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Services.Communication;

namespace SparkEquation.Trial.WebAPI.Extensions
{
    public static class ToActionResultConverter
    {
        public static IActionResult MapToActionResult<T>(this PayloadResponse<T> obj)
        {
            if (obj.Success)
            {
                var responseModel = new ApiResponse { Data = obj.Resource, Message = string.Empty };
                return new OkObjectResult(responseModel);
            }
            else
            {
                var responseModel = new ApiResponse { Data = null, Message = obj.Message };
                return new BadRequestObjectResult(responseModel);
            }
        }

        public static IActionResult MapToActionResult(this BaseResponse obj)
        {
            if (obj.Success)
            {
                var responseModel = new ApiResponse { Data = string.Empty, Message = string.Empty };
                return new OkObjectResult(responseModel);
            }
            else
            {
                var responseModel = new ApiResponse { Data = string.Empty, Message = obj.Message };
                return new BadRequestObjectResult(responseModel);
            }
        }
    }
}
