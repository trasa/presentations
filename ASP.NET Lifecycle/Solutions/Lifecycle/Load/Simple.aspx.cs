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
	/// <summary>
	/// Summary description for Simple.
	/// </summary>
	public class Simple : System.Web.UI.Page {
		
		protected TextBox txt;
		protected DropDownList ddl;
		protected Button cmdSubmit;


		protected override void OnInit(EventArgs e)
		{
			// at this point, all controls have their default values 
			// (defined in .aspx)
			Trace.Warn("Init", TextBoxValue);
			Trace.Write("Init", "session is null: " + (Session == null));

			Trace.Warn("Init", DropDownListValue);

			base.OnInit (e);
		}

		protected override void OnLoad(EventArgs e)
		{
			// at this point, ViewState & Postback data has been updated for 
			// each control in the tree.
			Trace.Warn("Page_Load", TextBoxValue);
			Trace.Warn("Page_Load", DropDownListValue);

			base.OnLoad (e);
		}




		#region Changed Events

		protected void txt_TextChanged(object sender, EventArgs e) {
			Trace.Warn("txt_TextChanged", TextBoxValue);
		}

		protected void ddl_SelectedIndexChanged(object sender, EventArgs e) {
			Trace.Warn("ddl_SelectedIndexChanged", DropDownListValue);
		}

		#endregion

		#region Postback Event

		protected void cmdSubmit_Click(object sender, EventArgs e) {
			Trace.Warn("cmdSubmit_Click", "Button Click Event");
		}

		#endregion

		#region helper stuff

		private string TextBoxValue { 
			get { return "txt.Text is '" + txt.Text + "'"; }
		}

		private string DropDownListValue {
			get { return "ddl.SelectedValue is '" + ddl.SelectedValue + "'"; }
		}

		#endregion

	}
}
