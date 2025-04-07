using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
//using System.Management;
using System.Linq;
using TSJ.Domain;
using TSJ.Infraestructure.Persistence;

namespace TDJ.WebUI.Filters
{
    public class UserFilterAttribute : IActionFilter
    {

        private readonly Con57DbContext _db;
        public UserFilterAttribute(Con57DbContext db)
        {
            _db = db;
        }

        //Método que se ejecuta después de la acción
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var routeData = filterContext.RouteData;
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];
            var url = $"{controller}/{action}";
            var user = filterContext.HttpContext.User.Identity.Name;
            var ipAddress = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            var method = filterContext.HttpContext.Request.Method;
            var macAddress = string.Empty; //GetMacAddress();

            //Valida si la respuesta es un return RedirectToAction
            if (method == "POST" && filterContext.Result.GetType() == typeof(RedirectToActionResult))
            {
                RedirectToActionResult result = (RedirectToActionResult)filterContext.Result;
                if (result.RouteValues != null)
                {
                    //var data = JsonConvert.SerializeObject(result.RouteValues.Values);

                    foreach (var item in result.RouteValues.AsQueryable())
                    {
                        var val = item.Value;
                        var succeeded = (bool)val.GetType().GetProperty("Succeeded").GetValue(val, null);

                        if (succeeded == true)
                        {
                            var entity = (object)val.GetType().GetProperty("Entity").GetValue(val, null);
                            var data = JsonConvert.SerializeObject(entity);

                            SaveUserActivity(data, url, user, ipAddress, macAddress);
                        }
                        break;
                    }
                }
            }

            //Valida si la respuesta es un return Json
            if (method == "POST" && filterContext.Result.GetType() == typeof(JsonResult))
            {
                JsonResult result = (JsonResult)filterContext.Result;
                if (result.Value != null)
                {
                    //var data = JsonConvert.SerializeObject(result.Value);
                    var val = result.Value;
                    var succeeded = (bool)val.GetType().GetProperty("Succeeded").GetValue(val, null);

                    if (succeeded == true)
                    {
                        var entity = (object)val.GetType().GetProperty("Entity").GetValue(val, null);
                        var data = JsonConvert.SerializeObject(entity);
                        SaveUserActivity(data, url, user, ipAddress, macAddress);
                    }
                }
            }
        }

        //Método que de ejecuta antes de la Acción
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public void SaveUserActivity(string data, string url, string user, string ipAddress, string macAddress)
        {
            var userActivity = new UserActivity
            {
                data = data,
                url = url,
                username = user,
                ipAddress = ipAddress,
                macAddress = macAddress,
            };

            _db.UserActivity.Add(userActivity);
            _db.SaveChanges();
        }
/*
        //Obtiene la dirección física del dispositivo
        public string GetMacAddress()
        {
            var managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var managementObjectCollection = managementClass.GetInstances();
            foreach (var managementObject in managementObjectCollection.OfType<ManagementObject>())
            {
                using (managementObject)
                {
                    if ((bool)managementObject["IPEnabled"])
                    {
                        if (managementObject["MacAddress"] == null)
                        {
                            return string.Empty;
                        }

                        return managementObject["MacAddress"].ToString().ToUpper();
                    }
                }
            }
            return string.Empty;
        }
*/
    }
}