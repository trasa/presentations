using System;
using System.Web.UI;

namespace Dry.Services
{
    public class InjectablePage : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            IoC.WireUpInjectableProperties(this);
            base.OnPreInit(e);
        }

    }
}
