using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MissileCommand.Core;

namespace MissileCommand.Web
{
    public partial class Satellites : Page
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
                Satellite sat = new Satellite();
                sat.Name = txtSatName.Text;
                sat.Altitude = double.Parse(txtAltitude.Text);
                sat.Save();

                txtSatName.Text = "";
                txtAltitude.Text = "";
            }
        }
    }
}