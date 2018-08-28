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
    public partial class JudgeLogin : Form
    {
        public JudgeLogin()
        {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            if (tbPcode.Text == "kambrascet2018")
            {
                eventPick ep = new eventPick();
                ep.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Invalid passcode! Please approach technical team for assistance.", "Invalid Passcode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void JudgeLogin_Load(object sender, EventArgs e)
        {

        }

        private void JudgeLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
