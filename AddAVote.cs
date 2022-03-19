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

namespace CW2
{
    public partial class AddAVote : Form
    {
        public AddAVote()
        {
            InitializeComponent();
            comboBox1.Items.Add("Plurality");
            comboBox1.Items.Add("Preferential");
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(connection))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "Insert into tblCandidateVote (VoteName, Candidate1, Candidate2, Candidate3, Candidate4, VoteType)values(@VoteName, @C1, @C2, @C3, @C4, @VoteType)";
                cmd.Parameters.AddWithValue("@VoteName", textBox1.Text);
                cmd.Parameters.AddWithValue("@C1", textBox2.Text);
                cmd.Parameters.AddWithValue("@C2", textBox3.Text);
                cmd.Parameters.AddWithValue("@C3", textBox3.Text);
                cmd.Parameters.AddWithValue("@C4", textBox4.Text);
                cmd.Parameters.AddWithValue("@VoteType", comboBox1.SelectedItem);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLandingPage ALP = new AdminLandingPage();
            ALP.ShowDialog();
        }
    }
}
