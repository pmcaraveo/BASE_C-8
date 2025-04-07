using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MvcCore.Helpers
{
    public class BaseController : Controller
    {
        public int Area { get; set; }
        public void MessageSuccess(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Success, message, dismissable, "fas fa-check-circle");
        }

        public void MessageInformation(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Information, message, dismissable, "fas fa-info-circle");
        }

        public void MessageWarning(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Warning, message, dismissable, "fas fa-exclamation-circle");
        }

        public void MessageDanger(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Danger, message, dismissable, "fas fa-exclamation-triangle");
        }

        private void AddAlert(string alertStyle, string message, bool dismissable, string iconClass)
        {
            var alerts = TempData.Get<List<Alert>>(Alert.TempDataKey);

            if (alerts == null)
            {
                alerts = new List<Alert>();
            }

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable,
                IconClass = iconClass
            });

            TempData.Put(Alert.TempDataKey, alerts);
        }
    }
}