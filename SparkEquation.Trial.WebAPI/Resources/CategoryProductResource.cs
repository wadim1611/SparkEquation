namespace SparkEquation.Trial.WebAPI.Resources
{
    public class CategoryProductResource
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public CategoryResource Category { get; set; }
        public ProductResource Product { get; set; }
    }
}
