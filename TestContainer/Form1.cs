using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestContainer
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void xmCheckBox1_Click(object sender, EventArgs e)
        {
            xmPushButton1.Enabled = xmCheckBox1.Checked;
        }

        private void xmPushButton2_Click(object sender, EventArgs e)
        {
            ++count;
            xmPushButton2.Text = count.ToString();
        }
    }
}
