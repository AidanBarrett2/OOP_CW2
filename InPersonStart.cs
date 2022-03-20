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
    public partial class InPersonStart : Form
    {
        public InPersonStart()
        {
            InitializeComponent();
            combo();
        }
        public static string sendtextnew = "";
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();

        private void button1_Click(object sender, EventArgs e)
        {
            sendtextnew = comboBox1.Text;
            this.Hide();
            InPersonVote IPV = new InPersonVote();
            IPV.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void combo()
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLandingPage ALP = new AdminLandingPage();
            ALP.ShowDialog();
        }
    }
}
