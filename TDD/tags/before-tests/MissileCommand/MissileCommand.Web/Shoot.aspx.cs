using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MissileCommand.Core;

namespace MissileCommand.Web
{
    public partial class Shoot : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // do we have a target?
                int satId = SatelliteId;
                if (satId == 0)
                {
                    // nothing to shoot at!  
                    Response.Redirect("default.aspx");
                    return;
                }
                // populate UI:
                Satellite sat = Satellite.Get(satId);
                lblSatName.Text = sat.Name;
                lblSatAlt.Text = sat.Altitude.ToString();
                lblSatVel.Text = sat.OrbitalVelocity.ToString("0.000");

                // determine set of sites that could hit this satellite
                rptLaunchers.DataSource = LaunchSite.LaunchersInRange(sat);
                rptLaunchers.DataBind();
            }
        }


        private int SatelliteId
        {
            get
            {
                string s = Request.QueryString["Id"];
                if (string.IsNullOrEmpty(s))
                    return 0;
                int i;
                if (!int.TryParse(s, out i))
                    return 0;
                return i;
            }
        }

        protected void rptLaunchers_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            int launcherId = int.Parse((string)e.CommandArgument);
            LaunchSite launcher = LaunchSite.Get(launcherId);
            Satellite sat = Satellite.Get(SatelliteId);
            // create a targeting system to hit this:
            TargetingSystem system = new TargetingSystem(sat, launcher, DateTime.Now);
            FiringSolution solution = system.ComputeFiringSolution();
            lblLaunchNotification.Visible = true;
            if (solution.Fire())
            {
                lblLaunchNotification.Text = "Missile Launched!";
            }
            else
            {
                lblLaunchNotification.Text = "Launch Failed!";
            }
        }
    }
}