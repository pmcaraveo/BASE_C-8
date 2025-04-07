using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcCore.Helpers
{
    public static class HtmlExtensions
    {

        #region Bootstrap buttons
        public static string LinkReturnToIndex()
        {
            string back = "<div>" +
                              "<div class=\"btn-group-sm\" role=\"group\">" +
                                  "<a asp-action=\"Index\" class=\"btn btn-outline-primary\">" +
                                        "<i class=\"fas fa-arrow-left\"></i> Regresar</a>" +
                              "</div>" +
                          "</div>";
            return back;
        }
        #endregion
    }
}