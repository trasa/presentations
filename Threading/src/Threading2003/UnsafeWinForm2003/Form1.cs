using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace UnsafeWinForm2003
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnLaunch;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnLaunch = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(280, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// btnLaunch
			// 
			this.btnLaunch.Location = new System.Drawing.Point(104, 80);
			this.btnLaunch.Name = "btnLaunch";
			this.btnLaunch.Size = new System.Drawing.Size(112, 23);
			this.btnLaunch.TabIndex = 1;
			this.btnLaunch.Text = "Launch Threads";
			this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnLaunch);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnLaunch_Click(object sender, System.EventArgs e)
		{
			Random r = new Random();
			for (int i=0; i < 25; i++)
			{
				Thread t = new Thread(new ThreadStart(UpdateTime));
				t.Start();
				Thread.Sleep(r.Next(10, 250));
			}
		}
		
		private void UpdateTime()
		{
			while(true)
			{
				// Wrong!  Can't work with window objects created on a 
				// different thread.  
				//
				// textBox1.InvokeRequired is true here.
				//
				// In .Net 1.x, you don't automatically get an exception here...
				// this gives a false sense of security.
				textBox1.Text = DateTime.Now.ToString();
				Thread.Sleep(1000);
			}
		}
	}
}
