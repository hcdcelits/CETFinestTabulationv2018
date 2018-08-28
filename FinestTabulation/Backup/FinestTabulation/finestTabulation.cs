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
    public partial class finestTabulation : Form
    {
        int x = 158;

        public finestTabulation()
        {
            InitializeComponent();
        }

        private void finestTabulation_Load(object sender, EventArgs e)
        {
            x = dataVContest.Location.X;
            dgvLeft.Start();
            dgvRight.Stop();

            btResume.Enabled = false;
            btStart.Enabled = true;
        }

        private void dgvLeft_Tick(object sender, EventArgs e)
        {
            int n = dataVContest.Location.X;
            if (n >= -2170)
            {
                dataVContest.Location = new Point(dataVContest.Location.X - 12, dataVContest.Location.Y);
            }
            else {
                dgvLeft.Stop();
                dgvRight.Start();
            }
        }

        private void dgvRight_Tick(object sender, EventArgs e)
        {
            int n = dataVContest.Location.X;
            if (n <= 158)
            {
                dataVContest.Location = new Point(dataVContest.Location.X + 1, dataVContest.Location.Y);
            }
            else {
                dgvRight.Stop();
                dgvLeft.Start();
            }
        }

    }
}
