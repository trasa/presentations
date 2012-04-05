using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UnsafeWinForm
{
    /// <summary>
    /// This attempts to update a windows control from a non-UI thread.
    /// In .NET 2.0, an InvalidOperationException will be thrown.
    /// In .NET 1.x (and everything else), the operation might work - 
    /// or it might cause deadlocks, UI corruption, or who knows what.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(UpdateTime));
            t.Start();
        }
        
        void UpdateTime()
        {
            while(true)
            {
                // Wrong!  Can't work with window objects created on a 
                // different thread.  
                //
                // textBox1.InvokeRequired is true here.
                textBox1.Text = DateTime.Now.ToString();
                Thread.Sleep(1000);
            }
        }
    }
}