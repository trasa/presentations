using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace RobotArmy.Core.Services
{

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext context, string controllerName)
        {
            Type controllerType = base.GetControllerType(controllerName);
            if (controllerType == null)
                return null;
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
