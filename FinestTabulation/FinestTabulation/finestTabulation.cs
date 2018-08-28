using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FinestTabulation
{
    public partial class finestTabulation : Form
    {
        dbConn dCon = new dbConn();
        SqlConnection sqlConnect;
        SqlCommand commnd;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;

        bool left = true;
        bool right = false;

        public finestTabulation()
        {
            InitializeComponent();
        }

        private void finestTabulation_Load(object sender, EventArgs e)
        {
            dgvLeft.Stop();
            dgvRight.Stop();

            btResume.Enabled = true;
            btPause.Enabled = false;
            
            

            sqlConnect = dCon.getCon();

            try {
                sqlConnect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please see this link: " + ex.HelpLink, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (commnd = new SqlCommand("Select BasketballMen as [Basketball Men], BasketballWomen as [Basketball Women], VolleyballMen as [Volleyball Men], VolleyballWomen as [Volleyball Women],  TableTennisMen as [Table Tennis Men], TableTennisWomen as [Table Tennis Women], TableTennisMix as [Table Tennis Mix], DartMen as [Dart Men], DartWomen as [Dart Women], DartMix as [Dart Mix], SepakTakraw as [Sepak Takraw], ChessMen as [Chess Men], ChessWomen as [Chess Women], SpokenPoetry as [Spoken Poetry], StoryTelling as [Story Telling], Oration, Extemporaneous, Essay, QuizBowl as [Quiz Bowl], Scrabble, WordFactoryMen as [Word Factory Men], BannerMaking as [Banner Making], LarongLahi as [Larong Lahi], VocalSolo as [Vocal Solo], VocalDuet as [Vocal Duet], DobleKara as [Doble Kara], DanceClash as [Dance Clash], CETICONMEN as [CET ICON MEN], CETICONWOMEN as [CET ICON WOMEN], (BasketballMen + BasketballWomen + VolleyballMen + VolleyballWomen + TableTennisMen + TableTennisWomen + TableTennisMix + DartMen + DartWomen + DartMix + SepakTakraw + ChessMen + ChessWomen + SpokenPoetry + StoryTelling + Oration + Extemporaneous + Essay + QuizBowl + Scrabble + WordFactoryMen + BannerMaking + LarongLahi + VocalSolo + VocalDuet + DobleKara + DanceClash + CETICONMEN + CETICONWOMEN) as Total FROM TABULATION ORDER BY Total DESC", sqlConnect)) {
                dataAdapter = new SqlDataAdapter(commnd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataVContest.DataSource = dt;

                dataVContest.Columns[29].Visible = false;
            }
            using (commnd = new SqlCommand("Select TeamName as [Team Name], (BasketballMen + BasketballWomen + VolleyballMen + VolleyballWomen + TableTennisMen + TableTennisWomen + TableTennisMix + DartMen + DartWomen + DartMix + SepakTakraw + ChessMen + ChessWomen + SpokenPoetry + StoryTelling + Oration + Extemporaneous + Essay + QuizBowl + Scrabble + WordFactoryMen + BannerMaking + LarongLahi + VocalSolo + VocalDuet + DobleKara + DanceClash + CETICONMEN + CETICONWOMEN) as Total FROM TABULATION ORDER BY Total DESC", sqlConnect))
            {
                dataAdapter = new SqlDataAdapter(commnd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dtgRankandTeams.DataSource = dt;
                dtgTotalPts.DataSource = dt;

                dtgTotalPts.Columns[0].Visible = false;
                dtgRankandTeams.Columns[1].Visible = false;
            }

            dtgRankandTeams.Columns[0].Width = 70;
        }

        private void dgvLeft_Tick(object sender, EventArgs e)
        {
            if (dataVContest.Right != dtgTotalPts.Left)
            {
                dataVContest.Location = new Point(dataVContest.Location.X - 1, dataVContest.Location.Y);
                left = true;
                right = false;
            }
            else {
                dgvLeft.Stop();
                dgvRight.Start();
                left = false;
                right = true;
            }
        }

        private void dgvRight_Tick(object sender, EventArgs e)
        {
            if (dataVContest.Left != dtgRankandTeams.Right)
            {
                dataVContest.Location = new Point(dataVContest.Location.X + 1, dataVContest.Location.Y);
                left = false;
                right = true;
            }
            else {
                dgvRight.Stop();
                dgvLeft.Start();
                left = true;
                right = false;
            }
        }
        private void openDBConn() {

        }

        private void closeDBConn() {

        }

        private void dtgRankandTeams_SelectionChanged(object sender, EventArgs e)
        {
            dtgRankandTeams.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataVContest_SelectionChanged(object sender, EventArgs e)
        {
            dataVContest.ClearSelection();
        }

        private void dtgTotalPts_SelectionChanged(object sender, EventArgs e)
        {
            dtgTotalPts.ClearSelection();
        }

        private void btResume_Click(object sender, EventArgs e)
        {
            if (left == true && right == false)
            {
                dgvLeft.Start();
                dgvRight.Stop();
            }
            else if (right == true && left == false)
            {
                dgvRight.Start();
                dgvLeft.Stop();
            }
            btResume.Enabled = false;
            btPause.Enabled = true;
        }

        private void btPause_Click_1(object sender, EventArgs e)
        {
            dgvLeft.Stop();
            dgvRight.Stop();
            btPause.Enabled = false;
            btResume.Enabled = true;
        }

        private void curTime_Tick(object sender, EventArgs e)
        {
        }
    }
}
