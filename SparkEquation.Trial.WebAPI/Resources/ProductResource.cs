using System;
using System.Collections.Generic;

namespace SparkEquation.Trial.WebAPI.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Featured { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int ItemsInStock { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public double Rating { get; set; }

        public int BrandId { get; set; }

        public BrandResource Brand { get; set; }

        public IList<CategoryProductResource> CategoryProducts { get; set; }
    }
}
