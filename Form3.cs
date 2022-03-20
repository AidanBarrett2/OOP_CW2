using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Threading;

namespace CW2

{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            combooptions();
            label1.Text = Login.sendtext;
            NumberOfClick = 0;
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        public string btnchoice = "";
        public int only1;
        public int onlypr;
        public int onlywe;
        public string VoteType = "";
        string Permission;
        int NumberOfClick = 0;
        int Cand1 = 0;
        int Cand2 = 0;
        int Cand3 = 0;
        int Cand4 = 0;
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
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select VoterPermissions from tblVoter where VoterUsername = @Username";
                cmd.Parameters.AddWithValue("@Username", label1.Text);
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
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                button1.Hide();
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
                button4.Hide();
                button6.Hide();
                label2.Hide();
                radioButton1.Hide();
                radioButton2.Hide();
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton5.Hide();
                listbox();
                button2.Show();
            }
            else if (VoteType == "Plurality")
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                button1.Show();
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
                button4.Hide();
                button6.Hide();
                label2.Hide();
                radioButton1.Hide();
                radioButton2.Hide();
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton5.Hide();
                options();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            else if (VoteType == "Weighted")
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                button1.Hide();
                listBox1.Hide();
                listBox2.Hide();
                pictureBox1.Hide();
                pictureBox2.Hide();
                checkBox1.Hide();
                checkBox2.Hide();
                checkBox3.Hide();
                checkBox4.Hide();
                Candidate1.Hide();
                Candidate2.Hide();
                Candidate3.Hide();
                Candidate4.Hide();
                button2.Hide();
                button4.Show();
                button6.Show();
                label2.Show();
                radioButton1.Show();
                radioButton2.Show();
                radioButton3.Show();
                radioButton4.Show();
                radioButton5.Show();
                button6.Enabled = true;
                Cand1 = 0;
                Cand2 = 0;
                Cand3 = 0;
                Cand4 = 0;
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
        public void totallypreferential()
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
                cmd.CommandText = "select VoteID and VoterID from tblPreferential where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                onlypr = i;

            }

        }
        public void totallyweighted()
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
                cmd.CommandText = "select VoteID and VoterID from tblWeighed where VoteID = '" + voteID + "'and VoterID ='" + userID + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                onlywe = i;

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
            string C3;
            string C4;
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Select * from tblCandidateVote where VoteName = @Votename";
                cmd.Parameters.AddWithValue("@Votename", comboBox1.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                if (listBox1.Items.Count == 0)
                {
                    while (dr.Read())
                    {
                        C3 = dr["Candidate3"].ToString();
                        C4 = dr["Candidate4"].ToString();
                        listBox1.Items.Add("1. " + dr["Candidate1"]);
                        listBox1.Items.Add("2. " + dr["Candidate2"]);
                        if(C3 == "")
                        {

                        }
                        else
                        {
                            listBox1.Items.Add("3. " + C3);
                            if (C4 == "")
                            {

                            }
                            else
                            {
                                listBox1.Items.Add("4. " + C4);
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string item1 = listBox2.Items[0].ToString();
            string item2 = listBox2.Items[1].ToString();
            string item3 = "";
                string item4 = "";
            if (listBox2.Items.Count == 3)
            {
                item3 = listBox2.Items[2].ToString();
            }
            else if (listBox2.Items.Count == 4)
            {
                item3 = listBox2.Items[2].ToString();
                item4 = listBox2.Items[3].ToString();
            }
                string voterid;
                string voteid;
            totallypreferential();
            if (onlypr > 0)
            {
                MessageBox.Show("You have already voted", "Error");
            }
            else
            {
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
                    cmd.CommandText = "Insert into tblPreferential (Vote1, Vote2, Vote3, Vote4, VoterID, VoteID)values(@Vote1, @Vote2, @Vote3, @Vote4, @Voterid, @Voteid)";
                    cmd.Parameters.AddWithValue("@Vote1", item1.Substring(0, 1));
                    cmd.Parameters.AddWithValue("@Vote2", item2.Substring(0, 1));
                    cmd.Parameters.AddWithValue("@Vote3", 0);
                    cmd.Parameters.AddWithValue("@Vote4", 0);
                    if (listBox2.Items.Count == 3)
                    {
                        cmd.Parameters.AddWithValue("@Vote3", item3.Substring(0, 1));
                    }
                    else if (listBox2.Items.Count == 4)
                    {
                        cmd.Parameters.AddWithValue("@Vote3", item3.Substring(0, 1));
                        cmd.Parameters.AddWithValue("@Vote4", item4.Substring(0, 1));
                    }
                    cmd.Parameters.AddWithValue("@Voterid", voterid);
                    cmd.Parameters.AddWithValue("@Voteid", voteid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            combooptions();
            label1.Text = Login.sendtext;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            weighed_voting f1 = new weighed_voting();
            f1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
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
                            button6.Enabled = false;
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
                            button6.Enabled = false;
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
                        button6.Enabled = false;
                        radio4();
                    }
                    break;
            }
        }
        public void Radio()
        {
            if (radioButton1.Checked == true)
            {
                Cand1 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Cand1 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Cand1 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Cand1 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Cand1 = 1;
            }
        }
        public void radio2()
        {
            if (radioButton1.Checked == true)
            {
                Cand2 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Cand2 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Cand2 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Cand2 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Cand2 = 1;
            }
        }
        public void radio3()
        {
            if (radioButton1.Checked == true)
            {
                Cand3 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Cand3 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Cand3 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Cand3 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Cand3 = 1;
            }
        }
        public void radio4()
        {
            if (radioButton1.Checked == true)
            {
                Cand4 = 5;
            }
            else if (radioButton2.Checked == true)
            {
                Cand4 = 4;
            }
            else if (radioButton3.Checked == true)
            {
                Cand4 = 3;
            }
            else if (radioButton4.Checked == true)
            {
                Cand4 = 2;
            }
            else if (radioButton5.Checked == true)
            {
                Cand4 = 1;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string voterid;
            string voteid;
            totallyweighted();
            if (onlywe > 0)
            {
                MessageBox.Show("You have already voted", "Error");
            }
            else
            {
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
                    cmd.Parameters.AddWithValue("@Vote1", Cand1);
                    cmd.Parameters.AddWithValue("@Vote2", Cand2);
                    cmd.Parameters.AddWithValue("@Vote3", Cand3);
                    cmd.Parameters.AddWithValue("@Vote4", Cand4);
                    cmd.Parameters.AddWithValue("@Voterid", voterid);
                    cmd.Parameters.AddWithValue("@Voteid", voteid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}