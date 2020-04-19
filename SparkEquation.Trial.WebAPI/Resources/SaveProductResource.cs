using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SparkEquation.Trial.WebAPI.Resources.Attributes;

namespace SparkEquation.Trial.WebAPI.Resources
{
    public class SaveProductResource
    {
        [Required, StringLength(15)]
        public string Name { get; set; }

        public bool Featured { get; set; }

        [MinimalExpirePeriod(30)]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemsInStock { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReceiptDate { get; set; }

        [Range(0, int.MaxValue)]
        public double Rating { get; set; }

        [Range(0, int.MaxValue)]
        public int BrandId { get; set; }

        public BrandResource Brand { get; set; }

        [Required,
            MinLength(1, ErrorMessage = "A product can have from 1 to 5 categories"),
            MaxLength(5, ErrorMessage = "A product can have from 1 to 5 categories")]
        public IList<CategoryProductResource> CategoryProducts { get; set; }
    }
}
