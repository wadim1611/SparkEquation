using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace SparkEquation.Trial.WebAPI.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            List<string> errors = new List<string>();
            foreach (var d in dictionary)
            {
                var description = string.Join(';', d.Value.Errors.Select(err => err.ErrorMessage));
                errors.Add($"{d.Key}:{description}");
            }

            return errors;
        }
    }
}
