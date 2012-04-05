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
	/// Incredibly Contrived Example of Why You Might Overide OnPreRender
	/// </summary>
	public class MultiDropDownList : System.Web.UI.Page {

		protected DropDownList ddlTop;
		protected DropDownList ddlMid;
		protected DropDownList ddlBottom;
		protected Label lblComplicatedResults;

		// just some variables to indicate "work" of some sort...
		bool topChange, midChange, botChange;



		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) {
				// first time - fill dropdownlists with data
				SampleDDLData.BindDropDownList(ddlTop, "top");
				SampleDDLData.BindDropDownList(ddlMid, "mid");
				SampleDDLData.BindDropDownList(ddlBottom, "bottom");
			}
		}

		protected override void OnPreRender(EventArgs e) {
			// “This is a good time for controls to perform any last minute update 
			// operations that need to take place immediately before the view state 
			// is saved and the output rendered.”
			if (Page.IsPostBack) { 
				// some work might have happened, if so report about it in this label.
				lblComplicatedResults.Text = topChange + " " + midChange + " " + botChange;
			}
			base.OnPreRender (e);
		}




		protected void ddlTop_SelectedIndexChanged(object sender, EventArgs e) {
			// do some sort of work, but only when values change
			topChange = true;
		}

		protected void ddlMid_SelectedIndexChanged(object sender, EventArgs e) {
			// do some sort of work, but only when values change
			midChange = true;
		}
		
		protected void ddlBottom_SelectedIndexChanged(object sender, EventArgs e) {
			// do some sort of work, but only when values change
			botChange = true;
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



	/// <summary>
	/// Used in MultiDropDownlist.aspx and MultiDropDownListNoEvent.aspx
	/// </summary>
	public struct SampleDDLData { 
		int id;
		string name;

		public SampleDDLData(int id, string name) {
			this.id = id;
			this.name = name;
		}

		public int ID { get { return id; } }
		public string Name { get  { return id + " - " + name; } }

		public static void BindDropDownList(DropDownList ddl, string name) {
			SampleDDLData[] data = new SampleDDLData[] { new SampleDDLData(0, name), 
														   new SampleDDLData(1, name), 
														   new SampleDDLData(2, name) };
			ddl.DataSource = data;
			ddl.DataTextField = "Name";
			ddl.DataValueField = "ID";
			ddl.DataBind();
		}
	}
}
