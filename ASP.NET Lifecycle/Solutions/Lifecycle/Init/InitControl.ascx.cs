namespace Lifecycle.Init
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for InitControl.
	/// </summary>
	public class InitControl : System.Web.UI.UserControl
	{
	
		override protected void OnInit(EventArgs e)
		{
			base.OnInit(e);	
			Trace.Warn("Control_OnInit");
				
		}

		protected override void OnLoad(EventArgs e)
		{
			Trace.Warn("Control_Load");
			base.OnLoad (e);
		}
	}
}
