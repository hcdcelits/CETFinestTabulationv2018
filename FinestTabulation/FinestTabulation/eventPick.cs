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
    public partial class eventPick : Form
    {
        public eventPick()
        {
            InitializeComponent();
        }

        private void eventPick_Load(object sender, EventArgs e)
        {

        }

        private void eventPick_FormClosed(object sender, FormClosedEventArgs e)
        {
            JudgeLogin jl = new JudgeLogin();
            jl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEVENTS.Text)) {
                MessageBox.Show("You have to select an event first!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else if(cmbEVENTS.Text.ToUpper() == "ESSAY WRITING"){
                
            }
        }
    }
}
