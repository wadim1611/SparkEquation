using SparkEquation.Trial.WebAPI.Resources;
using SparkEquation.Trial.WebAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkEquation.Trial.WebAPI.Services
{
    public interface IProductService
    {
        Task<PayloadResponse<List<ProductResource>>> GetAll();
        Task<PayloadResponse<ProductResource>> GetById(int id);
        Task<PayloadResponse<ProductResource>> SaveAsync(SaveProductResource product);
        Task<PayloadResponse<ProductResource>> UpdateAsync(int id, SaveProductResource product);
        Task<BaseResponse> DeleteAsync(int id);
    }
}