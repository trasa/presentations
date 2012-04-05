using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;

namespace Lifecycle 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			TraceMsg("Global constructor");
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			TraceMsg("Application_Start");
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			TraceMsg("Session_Start");
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			TraceMsg("Application_BeginRequest");
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			TraceMsg("Application_EndRequest");
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			TraceMsg("Application_AuthenticateRequest");
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			TraceMsg("Application_Error");
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			TraceMsg("Session_End");
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			TraceMsg("Application_End");
		}
			

		[Conditional("VERBOSE_TRACE")]
		private void TraceMsg(string caller) {
			if (Context != null && Context.Trace != null) {
				Context.Trace.Write(caller, caller);
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

