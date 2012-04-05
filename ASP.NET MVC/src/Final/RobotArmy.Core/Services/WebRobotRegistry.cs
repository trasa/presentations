using System.Security.Principal;
using System.Web;
using System.Web.Security;
using StructureMap.Attributes;

namespace RobotArmy.Core.Services
{
    public class WebRobotRegistry : RobotRegistry
    {
        public WebRobotRegistry() 
        {
            ForRequestedType<IPrincipal>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefault.Is.ConstructedBy(ctx => HttpContext.Current.User);


            ForRequestedType<IMembershipService>()
                .CacheBy(InstanceScope.HttpContext)
                .TheDefaultIsConcreteType<MembershipService>();

            ForRequestedType<MembershipProvider>()
                .TheDefault.IsThis(Membership.Provider);

        }
    }
}
