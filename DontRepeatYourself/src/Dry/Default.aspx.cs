using System;

namespace Dry
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgentContacts.aspx?ReadOnly=" + chkReadOnly.Checked + "&AgentId=" + txtId.Text);
        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            
        }
    }
}
