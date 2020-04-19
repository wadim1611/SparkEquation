using System;
using System.ComponentModel.DataAnnotations;

namespace SparkEquation.Trial.WebAPI.Resources.Attributes
{
    /// <summary>
    /// Specifies the minimum expiration period in days 
    /// </summary>
    class MinimalExpirePeriodAttribute : ValidationAttribute
    {
        private int _minExpirePeriodDays;

        public MinimalExpirePeriodAttribute(int minExpirePeriodDays = 30)
        {
            _minExpirePeriodDays = minExpirePeriodDays;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expirationDate = (DateTime?)value;

            if (expirationDate.HasValue && expirationDate < DateTime.Today.AddDays(_minExpirePeriodDays))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public int MaxExpireperiod => _minExpirePeriodDays;

        public string GetErrorMessage()
        {
            return $"If a product has an expiration date it should expire not less than {_minExpirePeriodDays} days since now";
        }
    }
}
