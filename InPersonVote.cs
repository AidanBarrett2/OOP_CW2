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

namespace CW2
{
    public partial class InPersonVote : Form
    {
        public InPersonVote()
        {
            InitializeComponent();
            textBox1.MaxLength = 6;
            label2.Text = InPersonStart.sendtextnew;
            options();
            Candidate1.Hide();
            Candidate2.Hide();
            Candidate3.Hide();
            Candidate4.Hide();
            label1.Hide();
            textBox1.Hide();
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public int only1;
        public string btnchoice = "";
        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            button1.Hide();
            Candidate1.Show();
            Candidate2.Show();
            Candidate3.Show();
            Candidate4.Show();
            label1.Show();
            label2.Show();
            textBox1.Show();
            textBox1.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void Candidate2_Click(object sender, EventArgs e)
        {
            {

                using (var con = new SQLiteConnection(connection))
                {
                    String Query = "Select * From tblVoter where VoterID = @Voter";
                    SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@Voter", textBox1.Text);
                    SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        totally();
                        if (only1 > 0)
                        {
                            MessageBox.Show("You have already voted, Please leave the queue", "Error");
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to vote for this Candidate?", "Message", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.No)
                            {
                            }
                            else
                            {
                                con.Open();
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = con.CreateCommand();
                                SqliteCmd.CommandText = "Update tblCandidateVote set Candidate2Votes = Candidate2Votes + 1 where VoteName = @Votename";
                                SqliteCmd.Parameters.AddWithValue("@Votename", label2.Text);
                                SqliteCmd.ExecuteNonQuery();
                                con.Close();
                                btnchoice = "2";
                                Limit();
                                await Task.Delay(300);
                                Candidate1.Hide();
                                Candidate2.Hide();
                                Candidate3.Hide();
                                Candidate4.Hide();
                                label1.Hide();
                                textBox1.Hide();
                                button1.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Voter ID");
                    }
                }
            }
        }

        private async void Candidate1_Click(object sender, EventArgs e)
        {
            {

                using (var con = new SQLiteConnection(connection))
                {
                    String Query = "Select * From tblVoter where VoterID = @Voter";
                    SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@Voter", textBox1.Text);
                    SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        totally();
                        if (only1 > 0)
                        {
                            MessageBox.Show("You have already voted, Please leave the queue", "Error");
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to vote for this Candidate?", "Message", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.No)
                            {
                            }
                            else
                            {
                                con.Open();
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = con.CreateCommand();
                                SqliteCmd.CommandText = "Update tblCandidateVote set Candidate1Votes = Candidate1Votes + 1 where VoteName = @Votename";
                                SqliteCmd.Parameters.AddWithValue("@Votename", label2.Text);
                                SqliteCmd.ExecuteNonQuery();
                                con.Close();
                                btnchoice = "1";
                                Limit();
                                await Task.Delay(300);
                                Candidate1.Hide();
                                Candidate2.Hide();
                                Candidate3.Hide();
                                Candidate4.Hide();
                                label1.Hide();
                                textBox1.Hide();
                                button1.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Voter ID");
                    }
                }
            }
        }

        private async void Candidate4_Click(object sender, EventArgs e)
        {
            {

                using (var con = new SQLiteConnection(connection))
                {
                    String Query = "Select * From tblVoter where VoterID = @Voter";
                    SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@Voter", textBox1.Text);
                    SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        totally();
                        if (only1 > 0)
                        {
                            MessageBox.Show("You have already voted, Please leave the queue", "Error");
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to vote for this Candidate?", "Message", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.No)
                            {
                            }
                            else
                            {
                                con.Open();
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = con.CreateCommand();
                                SqliteCmd.CommandText = "Update tblCandidateVote set Candidate4Votes = Candidate4Votes + 1 where VoteName = @Votename";
                                SqliteCmd.Parameters.AddWithValue("@Votename", label2.Text);
                                SqliteCmd.ExecuteNonQuery();
                                con.Close();
                                btnchoice = "4";
                                Limit();
                                await Task.Delay(300);
                                Candidate1.Hide();
                                Candidate2.Hide();
                                Candidate3.Hide();
                                Candidate4.Hide();
                                label1.Hide();
                                textBox1.Hide();
                                button1.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Voter ID");
                    }
                }
            }
        }

        private async void Candidate3_Click(object sender, EventArgs e)
        {
            {

                using (var con = new SQLiteConnection(connection))
                {
                    String Query = "Select * From tblVoter where VoterID = @Voter";
                    SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@Voter", textBox1.Text);
                    SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        totally();
                        if (only1 > 0)
                        {
                            MessageBox.Show("You have already voted, Please leave the queue", "Error");
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to vote for this Candidate?", "Message", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.No)
                            {
                            }
                            else
                            {
                                con.Open();
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = con.CreateCommand();
                                SqliteCmd.CommandText = "Update tblCandidateVote set Candidate3Votes = Candidate3Votes + 1 where VoteName = @Votename";
                                SqliteCmd.Parameters.AddWithValue("@Votename", label2.Text);
                                SqliteCmd.ExecuteNonQuery();
                                con.Close();
                                btnchoice = "3";
                                Limit();
                                await Task.Delay(300);
                                Candidate1.Hide();
                                Candidate2.Hide();
                                Candidate3.Hide();
                                Candidate4.Hide();
                                label1.Hide();
                                textBox1.Hide();
                                button1.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Voter ID");
                    }
                }
            }
        }
        public void options()
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate1 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate1.Text = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate2 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate2.Text = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate3 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate3.Text = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate4 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate4.Text = result.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void totally()
        {
            string userID = textBox1.Text;
            string voteID = "";

            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                voteID = result.ToString();
            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID and VoterID from tblVotes where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                only1 = i;

            }

        }
        public void Limit()
        {
            string voteID = "";
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", label2.Text);
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
                Cmd.Parameters.AddWithValue("@Voterid", textBox1.Text);
                Cmd.Parameters.AddWithValue("@Voteid", voteID);
                Cmd.Parameters.AddWithValue("@Candidateid", btnchoice);
                Cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

}
