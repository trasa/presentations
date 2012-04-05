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

namespace Lifecycle {
	
	public class MultiDropDownListNoEvent : System.Web.UI.Page {

		protected DropDownList ddlTop;
		protected DropDownList ddlMid;
		protected DropDownList ddlBottom;
		protected Label lblComplicatedResults;

		// just some variables to indicate "work" of some sort...
		//bool topChange, midChange, botChange;


		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				// first time - fill dropdownlists with data
				SampleDDLData.BindDropDownList(ddlTop, "top");
				SampleDDLData.BindDropDownList(ddlMid, "mid");
				SampleDDLData.BindDropDownList(ddlBottom, "bottom");
			}
		}

		#region Web Form Designer generated code
		
		override protected void OnInit(EventArgs e) {
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
