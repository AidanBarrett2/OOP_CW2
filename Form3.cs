using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CW2

{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            combooptions();
            label1.Text = Login.sendtext;
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public string btnchoice = "";
        public int only1;
        public string VoteType = "";
        SQLiteDataReader dr;

        public void button1_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                totally();
                if (only1 > 0)
                {
                    MessageBox.Show("You have already voted", "Error");
                }
                else
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate3Votes = Candidate3Votes + 1 where VoteName = @Votename";
                    SqliteCmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                    btnchoice = "3";
                    Limit();
                    Checkbox();
                }
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                totally();
                if (only1 > 0)
                {
                    MessageBox.Show("You have already voted", "Error");
                }
                else
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate2Votes = Candidate2Votes + 1 where VoteName = @Votename";
                    SqliteCmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                    btnchoice = "2";
                    Limit();
                    Checkbox();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                totally();
                if (only1 > 0)
                {
                    MessageBox.Show("You have already voted", "Error");
                }
                else
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate4Votes = Candidate4Votes + 1 where VoteName = @Votename";
                    SqliteCmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                    btnchoice = "4";
                    Limit();
                    Checkbox();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var con = new SQLiteConnection(connection))
            {
                totally();
                if (only1 > 0)
                {
                    MessageBox.Show("You have already voted", "Error");
                }
                else
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate1Votes = Candidate1Votes + 1 where VoteName = @Votename";
                    SqliteCmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                    btnchoice = "1";
                    Limit();
                    Checkbox();
                }
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
                listBox1.Show();
                listBox2.Show();
                pictureBox1.Show();
                pictureBox2.Show();
                checkBox1.Hide();
                checkBox2.Hide();
                checkBox3.Hide();
                checkBox4.Hide();
                Candidate1.Hide();
                Candidate2.Hide();
                Candidate3.Hide();
                Candidate4.Hide();
                listbox();
                button2.Show();
            }
            else
            {
                button2.Hide();
                listBox1.Hide();
                listBox2.Hide();
                pictureBox1.Hide();
                pictureBox2.Hide();
                checkBox1.Show();
                checkBox2.Show();
                checkBox3.Show();
                checkBox4.Show();
                Candidate1.Show();
                Candidate2.Show();
                Candidate3.Show();
                Candidate4.Show();
                options();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }
        public void options()
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate1 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate1.Text = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate2 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate2.Text = result.ToString();

            }
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select Candidate3 from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                Candidate3.Text = result.ToString();
                if (Candidate3.Text.Length > 0)
                {
                    Candidate3.Visible = true;
                    checkBox3.Visible = true;
                }
                else if (Candidate3.Text.Length < 1)
                {
                    Candidate3.Visible = false;
                    checkBox3.Visible = false;
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
                Candidate4.Text = result.ToString();
                if (Candidate4.Text.Length > 0)
                {
                    Candidate4.Visible = true;
                    checkBox4.Visible = true;
                }
                else if (Candidate4.Text.Length < 1)
                {
                    Candidate4.Visible = false;
                    checkBox4.Visible = false;
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void Limit()
        {
            string userID = "";
            string voteID = "";
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
        public void totally()
        {
            string userID = "";
            string voteID = "";
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
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID and VoterID from tblVotes where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                only1 = i;

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string userID = "";
            string voteID = "";
            string candidateID = "";
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
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "select VoteID and VoterID from tblVotes where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                only1 = i;

            }
            if (only1 > 0)
            {
                ChangeVote();
                using (var con = new SQLiteConnection(connection))
                {
                    SQLiteCommand cmd = new SQLiteCommand(con);
                    cmd.CommandText = "select CandidateID from tblVotes where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    con.Close();
                    candidateID = result.ToString();

                }
                using (var con = new SQLiteConnection(connection))
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Delete from tblVotes where VoteID = '" + voteID + "'and VoterID ='" + userID + "'and CandidateID ='" + candidateID + "'";
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;

                }
            }
            else
            {
            }
        }
        public void Checkbox()
        {
            string userID = "";
            string voteID = "";
            int candidateID;
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
            candidateID = Int32.Parse(btnchoice);

            if (candidateID == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (candidateID == 2)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (candidateID == 3)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (candidateID == 4)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void ChangeVote()
        {
            string VoteName;
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
                cmd.CommandText = "Select CandidateID from tblVotes where VoterID = @Votename and VoteID = @Username";
                cmd.Parameters.AddWithValue("@Votename", voterid);
                cmd.Parameters.AddWithValue("@Username", voteid);
                con.Open();
                var result = cmd.ExecuteScalar();
                con.Close();
                VoteName = result.ToString();

            }
            if (VoteName == "1")
            {
                using (var con = new SQLiteConnection(connection))
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate1Votes = Candidate1Votes - 1 where VoteID =" + voteid + "";
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (VoteName == "2")
            {
                using (var con = new SQLiteConnection(connection))
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate2Votes = Candidate2Votes - 1 where VoteID = " + voteid + "";
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (VoteName == "3")
            {
                using (var con = new SQLiteConnection(connection))
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate3Votes = Candidate3Votes - 1 where VoteID =" + voteid + "";
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (VoteName == "4")
            {
                using (var con = new SQLiteConnection(connection))
                {
                    con.Open();
                    var SqliteCmd = new SQLiteCommand();
                    SqliteCmd = con.CreateCommand();
                    SqliteCmd.CommandText = "Update tblCandidateVote set Candidate4Votes = Candidate4Votes - 1 where VoteID =" + voteid + "";
                    SqliteCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {

            }
            else
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {

            }
            else
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
        public void listbox()
            {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["Candidate1"]);
                    listBox1.Items.Add(dr["Candidate2"]);
                    listBox1.Items.Add(dr["Candidate3"]);
                    listBox1.Items.Add(dr["Candidate4"]);
                }
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Insert into tblPreferential (Vote1, Vote2, Vote3, Vote4)values(@Vote1, @Vote2, @Vote3, @Vote4)";
                cmd.Parameters.AddWithValue("@Vote1", listBox2.Items[0]);
                cmd.Parameters.AddWithValue("@Vote2", listBox2.Items[1]);
                cmd.Parameters.AddWithValue("@Vote3", listBox2.Items[2]);
                cmd.Parameters.AddWithValue("@Vote4", listBox2.Items[3]);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}