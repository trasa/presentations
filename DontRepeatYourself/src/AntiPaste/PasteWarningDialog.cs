using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AntiPaste
{
    public partial class PasteWarningDialog : Form
    {
        private const string Oath = "I solemnly swear that I understand the ramifications of what I am doing.";

        public PasteWarningDialog()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, EventArgs e)
        {
            if (!txt.Text.Equals(Oath, StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Try Again - I didn't hear you...", "Get the Oath Right");
                return;
            }
            // yay, success.
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnDoIt_Click(this, e);
            }
        }
    }
}
