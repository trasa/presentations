using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UnitTester.BusinessObjects;

namespace UnitTester.Web
{
	/// <summary>
	/// Summary description for ViewAccounts.
	/// </summary>
	public class ViewAccounts : System.Web.UI.Page
	{
		protected DataGrid grdAccounts;
		protected TextBox txtName;
		protected TextBox txtBalance;
		protected Button btnCreate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack) 
			{
				BindGrid();
			}
		}

		private void BindGrid() 
		{
			grdAccounts.DataSource = AccountFactory.GetAccounts();
			grdAccounts.DataBind();
		}

		protected void btnCreate_Click(object sender, EventArgs e) 
		{
			if (IsValid) 
			{
				Account a = AccountFactory.CreateAccount();
				a.Name = txtName.Text;
				a.Balance = decimal.Parse(txtBalance.Text);
				a.Save();
				// show results
				BindGrid();

				txtName.Text = "";
				txtBalance.Text = "";
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
