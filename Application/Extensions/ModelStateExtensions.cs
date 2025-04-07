using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace MvcCore.Helpers
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, List<KeyValuePair<string, string>> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.Key, error.Value);
            }
        }
    }
}