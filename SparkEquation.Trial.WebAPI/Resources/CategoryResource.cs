using System.Collections.Generic;

namespace SparkEquation.Trial.WebAPI.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CategoryProductResource> CategoryProducts { get; set; }
    }
}
