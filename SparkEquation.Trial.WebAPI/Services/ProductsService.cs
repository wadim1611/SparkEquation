using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SparkEquation.Trial.WebAPI.Data.Factory;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Resources;
using SparkEquation.Trial.WebAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkEquation.Trial.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IContextFactory _factory;
        private readonly IMapper _mapper;
        private const int FEATURED_PRODUCT_RATING = 8;

        public ProductService(IContextFactory contextFactory, IMapper mapper)
        {
            _factory = contextFactory;
            _mapper = mapper;
        }

        public async Task<PayloadResponse<List<ProductResource>>> GetAll()
        {
            try
            {
                var products = new List<Product>();
                using (var context = _factory.GetContext())
                {
                    products = await context.Products.ToListAsync();
                }

                var productsList = _mapper.Map<List<Product>, List<ProductResource>>(products);
                return new PayloadResponse<List<ProductResource>>(productsList);
            }
            catch(Exception ex)
            {
                return new PayloadResponse<List<ProductResource>>(ex.Message);
            }
        }

        public async Task<PayloadResponse<ProductResource>> GetById(int id)
        {
            try
            {
                using (var context = _factory.GetContext())
                {
                    var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                    if(product == null) return new PayloadResponse<ProductResource>($"Product with id {id} not found");

                    var productResource = _mapper.Map<Product, ProductResource>(product);
                    return new PayloadResponse<ProductResource>(productResource);
                }
            }
            catch(Exception ex)
            {
                return new PayloadResponse<ProductResource>(ex.Message);
            }
        }

        public async Task<PayloadResponse<ProductResource>> SaveAsync(SaveProductResource saveProductResource)
        {
            try
            {
                var product = _mapper.Map<SaveProductResource, Product>(saveProductResource);
                using (var context = _factory.GetContext())
                {
                    await context.Products.AddAsync(product);
                    await context.SaveChangesAsync();
                    var newProductResource = _mapper.Map<Product, ProductResource>(product);
                    return new PayloadResponse<ProductResource>(newProductResource);
                }
            }
            catch(Exception ex)
            {
                return new PayloadResponse<ProductResource>(ex.Message);
            }
        }

        public async Task<PayloadResponse<ProductResource>> UpdateAsync(int id, SaveProductResource saveProductResource)
        {
            try
            {
                var product = _mapper.Map<SaveProductResource, Product>(saveProductResource);
                using (var context = _factory.GetContext())
                {
                    var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                    if (existingProduct == null) return new PayloadResponse<ProductResource>($"Product with id {id} not found");

                    product.Featured = product.Rating > FEATURED_PRODUCT_RATING;
                    await context.Products.AddAsync(product);
                    await context.SaveChangesAsync();
                    var newProductResource = _mapper.Map<Product, ProductResource>(product);
                    return new PayloadResponse<ProductResource>(newProductResource);
                }
            }
            catch (Exception ex)
            {
                return new PayloadResponse<ProductResource>(ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            try
            {
                using (var context = _factory.GetContext())
                {
                    var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                    if (existingProduct == null) return new BaseResponse($"Product with id {id} not found");

                    context.Products.Remove(existingProduct);
                    await context.SaveChangesAsync();
                    return new BaseResponse();
                }
            }
            catch(Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}