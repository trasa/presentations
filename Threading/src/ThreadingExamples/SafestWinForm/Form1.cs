using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SafestWinForm
{
    /// <summary>
    /// Best Option: work at a higher level of abstraction.
    /// 
    /// Threads are very low level, and in this case all we
    /// want is a timer - so just use a higher level "timer".
    ///
    /// Much simpler, less room for errors.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool b = txt.InvokeRequired;
            txt.Text = DateTime.Now.ToString();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}