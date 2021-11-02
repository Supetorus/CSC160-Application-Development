using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Button btnGoodbye = new Button();
            btnGoodbye.Location = new Point(100, 100);
            btnGoodbye.Text = "goodbye";
            btnGoodbye.Size = new Size(200, 100);
            Controls.Add(btnGoodbye);
            btnGoodbye.Click += btnGoodBye_Click;
        }

        private void btnGoodBye_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Size = new Size(btn.Size.Width + 10, btn.Size.Height + 10);
        }
    }
}
