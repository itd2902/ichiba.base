using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IChiba
{
    public static class ModelExtensions
    {
        public static Dictionary<string, IEnumerable<string>> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(w => w.Value.Errors.Count > 0)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(s => s.ErrorMessage)
                );

            return errors;
        }
    }
}
