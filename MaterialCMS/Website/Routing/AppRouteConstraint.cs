using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace MaterialCMS.Website.Routing
{
    public class AppRouteConstraint : IRouteConstraint
    {
        private readonly string _appName;
        private readonly string _area;

        public AppRouteConstraint(string appName, string area)
        {
            _appName = appName;
            _area = area;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string controllerName = Convert.ToString(values["controller"]);
            string actionName = Convert.ToString(values["action"]);
            bool isAdmin = !string.IsNullOrWhiteSpace(_area) && _area.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                var mrCMSControllerFactory = ControllerBuilder.Current.GetControllerFactory() as MaterialCMSControllerFactory;
                if (mrCMSControllerFactory != null)
                {
                    bool isValidControllerType = mrCMSControllerFactory.IsValidControllerType(_appName, controllerName, isAdmin);
                    return isValidControllerType;
                }
                return false;
            }

            var controllers = isAdmin
                ? MaterialCMSControllerFactory.AppAdminControllers
                : MaterialCMSControllerFactory.AppUiControllers;

            Type controllerType = null;
            if (controllers.ContainsKey(_appName))
            {
                controllerType = controllers[_appName].FirstOrDefault(
                type => type.Name.Equals(controllerName + "Controller", StringComparison.OrdinalIgnoreCase));
            }

            if (controllerType == null)
                return false;

            // get controller's methods
            return MaterialCMSControllerFactory.GetActionMethods(controllerType)
                              .Any(info => info.Name.Equals(actionName, StringComparison.OrdinalIgnoreCase));

        }
    }
}