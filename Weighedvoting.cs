using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;
using System.Threading;

namespace CW2
{
    public partial class weighed_voting : Form
    {
        public weighed_voting()
        {
            InitializeComponent();
            combooptions();
            NumberOfClick = 0;
            label1.Text = Login.sendtext;
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        int NumberOfClick = 0;
        int Candidate1 = 0;
        int Candidate2 = 0;
        int Candidate3 = 0;
        int Candidate4 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    using (var con = new SQLiteConnection(connection))
                    {
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "Select Candidate2 from tblCandidateVote where VoteName = @Votename";
                        cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                        con.Open();
                        var result = cmd.ExecuteScalar();
                        con.Close();
                        label2.Text = result.ToString();
                        Radio();
                    }
                    break;
                case 2:
                    using (var con = new SQLiteConnection(connection))
                    {
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "Select Candidate3 from tblCandidateVote where VoteName = @Votename";
                        cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                        con.Open();
                        var result = cmd.ExecuteScalar();
                        con.Close();
                        if (result.ToString() == "")
                        {
                            button1.Enabled = false;
                        }
                        else
                        {
                            radio2();
                            label2.Text = result.ToString();
                        }
                    }
                    break;
                case 3:
                    using (var con = new SQLiteConnection(connection))
                    {
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "Select Candidate4 from tblCandidateVote where VoteName = @Votename";
                        cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                        con.Open();
                        var result = cmd.ExecuteScalar();
                        con.Close();
                        if (result.ToString() == "")
                        {
                            button1.Enabled = false;
                        }
                        else
                        {
                            radio3();
                            label2.Text = result.ToString();
                        }
                    }
                    break;
                case 4:
                    {
                        button1.Enabled = false;
                        radio4();
                    }
                    break;
            }
        }
        public void Limit()
        {
            string userID = "";
            string voteID = "";
            string btnchoice = "";
            using (var con = new SQLiteConnection(connection))
            {

                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoterID from tblVoter where VoterUsername = @username";
                cmd.Parameters.AddWithValue("@username", label1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                userID = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteID = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
                var Cmd = new SQLiteCommand();
                Cmd = con.CreateCommand();
                Cmd.CommandText = "Insert into tblVotes (VoteID, CandidateID, VoterID) values (@Voteid, @Candidateid, @Voterid)";
                Cmd.Parameters.AddWithValue("@Voterid", userID);
                Cmd.Parameters.AddWithValue("@Voteid", voteID);
                Cmd.Parameters.AddWithValue("@Candidateid", btnchoice);
                Cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void combooptions()
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
                NumberOfClick = 0;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate1 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                label2.Text = result.ToString();
            }
            NumberOfClick = 0;
            button1.Enabled = true;
            Candidate1 = 0;
            Candidate2 = 0;
            Candidate3 = 0;
            Candidate4 = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void Radio()
        {
            if(radioButton1.Checked == true)
            {
                Candidate1 = 5;
            }
            else if(radioButton2.Checked == true)
            {
                Candidate1 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Candidate1 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Candidate1 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Candidate1 = 1;
            }
        }
        public void radio2()
        {
            if (radioButton1.Checked == true)
            {
                Candidate2 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Candidate2 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Candidate2 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Candidate2 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Candidate2 = 1;
            }
        }
        public void radio3()
        {
            if (radioButton1.Checked == true)
            {
                Candidate3 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Candidate3 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Candidate3 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Candidate3 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Candidate3 = 1;
            }
        }
        public void radio4()
        {
            if (radioButton1.Checked == true)
            {
                Candidate4 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Candidate4 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Candidate4 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Candidate4 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Candidate4 = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string voterid;
            string voteid;
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoterID from tblVoter where VoterUsername = @username";
                cmd.Parameters.AddWithValue("@username", label1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voterid = result.ToString();

            }
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
                cmd.CommandText = "Insert into tblWeighed (VoteID, VoterID, Candidate1Choice, Candidate2Choice, Candidate3Choice, Candidate4Choice)values(@Voteid, @Voterid, @Vote1, @Vote2, @Vote3, @Vote4)";
                cmd.Parameters.AddWithValue("@Vote1", Candidate1);
                cmd.Parameters.AddWithValue("@Vote2", Candidate2);
                cmd.Parameters.AddWithValue("@Vote3", Candidate3);
                cmd.Parameters.AddWithValue("@Vote4", Candidate4);
                cmd.Parameters.AddWithValue("@Voterid", voterid);
                cmd.Parameters.AddWithValue("@Voteid", voteid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

