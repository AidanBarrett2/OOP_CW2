using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using System.Threading;

namespace CW2
{
    public partial class Audit : Form
    {
        public Audit()
        {
            InitializeComponent();
            ComboBox();
            CountVotes Cv = new CountVotes(Candidate1Votes, Candidate2Votes, Candidate3Votes, Candidate4Votes);
            label5.Text = "Votes: " + Cv.Cand1;
            label6.Text = "Votes: " + Cv.Cand2;
            label7.Text = "Votes: " + Cv.Cand3;
            label8.Text = "Votes: " + Cv.Cand4;
            label9.Text = Login.sendtext;
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public string Candidate1Votes = "";
        public string Candidate2Votes = "";
        public string Candidate3Votes = "";
        public string Candidate4Votes = "";
        public string Combobox = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Candidates();
            Moon();
            Moon2();
            Moon3();
            Moon4();
            CountVotes Cv = new CountVotes(Candidate1Votes, Candidate2Votes, Candidate3Votes, Candidate4Votes);
            label5.Text = "Votes: " + Cv.Cand1;
            label6.Text = "Votes: " + Cv.Cand2;
            label7.Text = "Votes: " + Cv.Cand3;
            label8.Text = "Votes: " + Cv.Cand4;
        }
        public void ComboBox()
        {
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
                string query = "Select VoteName from tblCandidateVote where VoteType = 'Plurality'";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();

                comboBox1.DisplayMember = "VoteName";
                comboBox1.ValueMember = "VoteName";
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.Enabled = true;
            }
        }
        public void Moon()
        {
            String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate1Votes from tblCandidateVote where VoteName = @Votename";
                con.Open();
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                var result = cmd.ExecuteScalar();
                con.Close();
                var account = result.ToString();
                Candidate1Votes = account.ToString();
            }
        }
        public void Moon2()
        {
            String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate2Votes from tblCandidateVote where VoteName = @Votename";
                con.Open();
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                var result = cmd.ExecuteScalar();
                con.Close();
                var account = result.ToString();
                Candidate2Votes = account.ToString();
            }
        }
        public void Moon3()
        {
            String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate3Votes from tblCandidateVote where VoteName = @Votename";
                con.Open();
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                var result = cmd.ExecuteScalar();
                con.Close();
                var account = result.ToString();
                Candidate3Votes = account.ToString();
            }
        }
        public void Moon4()
        {
            String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate4Votes from tblCandidateVote where VoteName = @Votename";
                con.Open();
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                var result = cmd.ExecuteScalar();
                con.Close();
                var account = result.ToString();
                Candidate4Votes = account.ToString();
            }
        }

        public void Candidates()
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate1 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                label1.Text = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate2 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                label2.Text = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate3 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                label3.Text = result.ToString();
                if (label3.Text.Length > 0)
                {
                    label3.Visible = true;
                    label7.Visible = true;
                }
                else if (label3.Text.Length < 1)
                {
                    label3.Visible = false;
                    label7.Visible = false;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate4 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                label4.Text = result.ToString();
                if (label4.Text.Length > 0)
                {
                    label4.Visible = true;
                    label8.Visible = true;
                }
                else if (label4.Text.Length < 1)
                {
                    label4.Visible = false;
                    label8.Visible = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
            {
                this.Hide();
                AuditerLandingPage ALP = new AuditerLandingPage();
                ALP.ShowDialog();
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Combobox = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
            SQLiteCommand comm = new SQLiteCommand("Select * From tblVotes where VoteID = @Votename", con);
                comm.Parameters.AddWithValue("@Votename", Combobox);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        dataGridView1.Rows.Add(new object[] {
                            read.GetValue(read.GetOrdinal("VoteID")),
                            read.GetValue(read.GetOrdinal("CandidateID")),
                            read.GetValue(read.GetOrdinal("VoterID"))
                        });
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ms-MY");
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();
            ComboBox();
        }

        private void Audit_Load(object sender, EventArgs e)
        {

        }
    }
}
