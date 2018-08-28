using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinestTabulation
{
    public partial class CountdownRes : Form
    {
        public CountdownRes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            timer1.Start();
        }

        private void CountdownRes_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        int x = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x >= 0)
            {
                if (x == 0)
                {
                    pictureBox1.Visible = true;
                    label1.Visible = false;
                }
                else {
                    label1.Text = x.ToString();
                }
                x--;
            }
            else {
                timer1.Stop();
                finestTabulation ft = new finestTabulation();
                ft.Show();
                this.Hide();
            }
        }
    }
}
