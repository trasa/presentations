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

namespace Lifecycle.Init
{
	/// <summary>
	/// Summary description for InitChain.
	/// </summary>
	public class InitChain : System.Web.UI.Page
	{

		
		override protected void OnInit(EventArgs e)
		{
			// Question: which OnInit fires first:  
			// the page, or the control?
			Trace.Warn("Page_OnInit");
			base.OnInit(e);	
			
		}

		protected override void OnLoad(EventArgs e)
		{
			// Question:  Which page_load fires first:  
			// the page, or the control?
			Trace.Warn("Page_Load");
			base.OnLoad(e);
		}


		
	}
}
