using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SafeWinForm
{
    /// <summary>
    /// This example uses a thread to update a textbox - 
    /// but it does so using BeginInvoke() to marshall the update
    /// back to the UI thread, so the update happens safely.
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
            for (int i = 0; i < 5; i++)
            {
                txt.BeginInvoke(new SetTextDelegate(SetText), DateTime.Now);
                //textBox1.Text = DateTime.Now.ToString();
                Thread.Sleep(1000);
            }
        }

        delegate void SetTextDelegate(DateTime dt);
        
        void SetText(DateTime dt)
        {
            System.Diagnostics.Debug.Assert(!txt.InvokeRequired);
            txt.Text = dt.ToString();
        }

    }
}