using System.Collections.Generic;

namespace SparkEquation.Trial.WebAPI.Resources
{
    public class BrandResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public IList<ProductResource> Products { get; set; }
    }
}
