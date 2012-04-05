using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MissileCommand.Core;

namespace MissileCommand.Web
{
    public partial class LaunchSites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvAltitude_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            // TODO: duplicated code
            double d;
            if (double.TryParse(e.Value, out d))
            {
                if (d <= 0)
                    e.IsValid = false;
            }
            else
            {
                e.IsValid = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                LaunchSite site =new LaunchSite();
                site.Name = txtName.Text;
                site.MaxAltitude = double.Parse(txtAltitude.Text);
                site.Save();
                txtName.Text = "";
                txtAltitude.Text = "";
            }
        }
    }
}
