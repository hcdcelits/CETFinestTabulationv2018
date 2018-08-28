using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FinestTabulation
{
    public partial class EssayWriting : Form
   
    {
        SqlConnection conn;
        SqlCommand cmd;
        dbConn con = new dbConn();
        public EssayWriting()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btCpe1_Click(object sender, EventArgs e)
        {

        }

        private void btITa1_Click(object sender, EventArgs e)
        {

        }

        private void btITb1_Click(object sender, EventArgs e)
        {

        }

        private void btEce1_Click(object sender, EventArgs e)
        {

        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            conn = con.getCon();
            conn.Open();



            if (txtBSCPE.Text == "" || txtTeamA.Text == "" || txtTeamB.Text == "" || txtECE.Text == "")
            {
                MessageBox.Show("Please indicate your score to 0 to 100", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    double teamBSCPE = Double.Parse(txtBSCPE.Text);
                    double teamA = Double.Parse(txtTeamA.Text);
                    double teamB = Double.Parse(txtTeamB.Text);
                    double teamECE = Double.Parse(txtECE.Text);

                    if (teamBSCPE > 100 || teamBSCPE < 0)
                    {
                        MessageBox.Show("Input out of range please try again", "TEAM BSCPE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBSCPE.Text = "";
                        txtBSCPE.Focus();
                    }
                    else if (teamA > 100 || teamA < 0)
                    {
                        MessageBox.Show("Input out of range please try again", "TEAM BSIT-A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTeamA.Text = "";
                        txtTeamA.Focus();
                    }
                    else if (teamB > 100 || teamB < 0)
                    {
                        MessageBox.Show("Input out of range please try again", "TEAM BSIT-B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTeamB.Text = "";
                        txtTeamB.Focus();
                    }
                    else if (teamECE > 100 || teamECE < 0)
                    {
                        MessageBox.Show("Input out of range please try again", "TEAM BSECE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtECE.Text = "";
                        txtECE.Focus();
                    }
                    else
                    {

                        using (cmd = new SqlCommand("Insert into Scores(teamID,EventID,Score)VALUES(@ti, @ei, @sc)", conn))
                        {
                            cmd.Parameters.AddWithValue("@ti", 1);
                            cmd.Parameters.AddWithValue("@ei", 22);
                            cmd.Parameters.AddWithValue("@sc", txtBSCPE.Text);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Scores added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Invalid Input");
                }
                

            }
            
            
            
        }
    }
}
