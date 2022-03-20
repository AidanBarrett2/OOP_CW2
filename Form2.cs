using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CW2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ComboBox();
            CountVotes Cv = new CountVotes(Candidate1Votes, Candidate2Votes, Candidate3Votes, Candidate4Votes);
            label5.Text = "Votes: " + Cv.Cand1;
            label6.Text = "Votes: " + Cv.Cand2;
            label7.Text = "Votes: " + Cv.Cand3;
            label8.Text = "Votes: " + Cv.Cand4;
            label9.Text = Login.sendtext;
            button2.Hide();
        }

        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public static string combo = "";
        public string Candidate1Votes = "";
        public string Candidate2Votes = "";
        public string Candidate3Votes = "";
        public string Candidate4Votes = "";
        string VoteType;
        string Permission;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteType from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                VoteType = result.ToString();

            }
            if (VoteType == "Preferential")
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button2.Show();
                label10.Hide();
                label11.Hide();
                label12.Hide();
                label13.Hide();
            }
            else if (VoteType == "Plurality")
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                button2.Hide();
                label10.Hide();
                label11.Hide();
                label12.Hide();
                label13.Hide();
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
            else if (VoteType == "Weighted")
            {
                Candidates();
                weighedvotes();
                weighedvotes2();
                weighedvotes3();
                weighedvotes4();
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button2.Hide();
                label10.Show();
                label11.Show();
                label12.Show();
                label13.Show();
            }
        }
        public void ComboBox()
        {
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
                string query = "Select VoteName from tblCandidateVote";
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
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoterPermissions from tblVoter where VoterUsername = @Username";
                cmd.Parameters.AddWithValue("@Username", label9.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Permission = result.ToString();
            }
            if (Permission == "Voter")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            if (Permission == "Administrator")
            {
                this.Hide();
                AdminLandingPage ALP = new AdminLandingPage();
                ALP.ShowDialog();
            }
            if (Permission == "Auditer")
            {
                this.Hide();
                AuditerLandingPage ALP = new AuditerLandingPage();
                ALP.ShowDialog();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            combo = comboBox1.Text.ToString();
            Preferential pr = new Preferential();
            pr.ShowDialog();
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
        }
        public void weighedvotes()
        {
            int vote1 = 0;
            int vote2 = 0;
            int vote3 = 0;
            int vote4 = 0;
            int vote5 = 0;
            int votetotal;
            string voteid = "";
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteid = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate1Choice = 5";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote1 = dt.Rows.Count * 5;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate1Choice = 4";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote2 = dt.Rows.Count * 4;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate1Choice = 3";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote3 = dt.Rows.Count * 3;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate1Choice = 2";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote4 = dt.Rows.Count * 2;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate1Choice = 1";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote5 = dt.Rows.Count * 1;
                }
            }
            votetotal = vote1 + vote2 + vote3 + vote4 + vote5;
            label13.Text = "Total Points: " + votetotal.ToString();
        }
        public void weighedvotes2()
        {
            int vote1 = 0;
            int vote2 = 0;
            int vote3 = 0;
            int vote4 = 0;
            int vote5 = 0;
            int votetotal;
            string voteid = "";
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteid = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate2Choice = 5";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote1 = dt.Rows.Count * 5;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate2Choice = 4";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote2 = dt.Rows.Count * 4;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate2Choice = 3";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote3 = dt.Rows.Count * 3;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate2Choice = 2";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote4 = dt.Rows.Count * 2;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate2Choice = 1";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote5 = dt.Rows.Count * 1;
                }
            }
            votetotal = vote1 + vote2 + vote3 + vote4 + vote5;
            label12.Text = "Total Points: " + votetotal.ToString();
        }
        public void weighedvotes3()
        {
            int vote1 = 0;
            int vote2 = 0;
            int vote3 = 0;
            int vote4 = 0;
            int vote5 = 0;
            int votetotal;
            string voteid = "";
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteid = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate3Choice = 5";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote1 = dt.Rows.Count * 5;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate3Choice = 4";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote2 = dt.Rows.Count * 4;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate3Choice = 3";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote3 = dt.Rows.Count * 3;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate3Choice = 2";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote4 = dt.Rows.Count * 2;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate3Choice = 1";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote5 = dt.Rows.Count * 1;
                }
            }
            votetotal = vote1 + vote2 + vote3 + vote4 + vote5;
            label11.Text = "Total Points: " + votetotal.ToString();
        }
        public void weighedvotes4()
        {
            int vote1 = 0;
            int vote2 = 0;
            int vote3 = 0;
            int vote4 = 0;
            int vote5 = 0;
            int votetotal;
            string voteid = "";
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteid = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate4Choice = 5";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote1 = dt.Rows.Count * 5;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate4Choice = 4";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote2 = dt.Rows.Count * 4;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate4Choice = 3";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote3 = dt.Rows.Count * 3;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate4Choice = 2";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote4 = dt.Rows.Count * 2;
                }
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblWeighed where VoteID = @VoteID and Candidate4Choice = 1";
                con.Open();
                cmd.Parameters.AddWithValue("@VoteID", voteid);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    vote5 = dt.Rows.Count * 1;
                }
            }
            votetotal = vote1 + vote2 + vote3 + vote4 + vote5;
            label10.Text = "Total Points: " + votetotal.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
