using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CW2
{
    public partial class Preferential : Form
    {
        public Preferential()
        {
            InitializeComponent();
            label17.Text = Form2.combo;
            countprefered();
            label18.Text = Login.sendtext;
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        string VoteID;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        public void countprefered()
        {
            string Vote1;
            string Vote2;
            string Vote3;
            string Vote4;
            string Vote5;
            string Vote6;
            string Vote7;
            string Vote8;
            using (var con = new SQLiteConnection(connection))
            {

                    SQLiteCommand cmd11 = new SQLiteCommand(con);
                    cmd11.CommandText = "select VoteID from tblCandidateVote where VoteName = @Votename";
                    cmd11.Parameters.AddWithValue("@Votename", label17.Text);
                    con.Open();
                    var votename = cmd11.ExecuteScalar();
                    con.Close();
                    VoteID = votename.ToString();

                String Query = "Select count(*) from tblPreferential where Vote1 = 1 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand command = new SQLiteCommand(Query, con);
                command.Parameters.AddWithValue("@VoteID", VoteID);
                var voteid = command.ExecuteScalar();
                con.Close();
                Vote1 = voteid.ToString();
                label9.Text = Vote1;

                String Qry = "Select count(*) from tblPreferential where Vote2 = 1 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(Qry, con);
                cmd.Parameters.AddWithValue("@VoteID", VoteID);
                var answer = cmd.ExecuteScalar();
                con.Close();
                Vote2 = answer.ToString();
                label10.Text = Vote2;

                String V3 = "Select count(*) from tblPreferential where Vote3 = 1 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand comd = new SQLiteCommand(V3, con);
                comd.Parameters.AddWithValue("@VoteID", VoteID);
                var vote3 = comd.ExecuteScalar();
                con.Close();
                Vote3 = vote3.ToString();
                label11.Text = Vote3;

                String V4 = "Select count(*) from tblPreferential where Vote4 = 1 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand Cmd = new SQLiteCommand(V4, con);
                Cmd.Parameters.AddWithValue("@VoteID", VoteID);
                var vote4 = Cmd.ExecuteScalar();
                con.Close();
                Vote4 = vote4.ToString();
                label12.Text = Vote4;

                String V5 = "Select count(*) from tblPreferential where Vote1 = 2 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand Comd = new SQLiteCommand(V5, con);
                Comd.Parameters.AddWithValue("@VoteID", VoteID);
                var vote5 = Comd.ExecuteScalar();
                con.Close();
                Vote5 = vote5.ToString();
                label1.Text = Vote5;

                String V6 = "Select count(*) from tblPreferential where Vote2 = 2 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand Command = new SQLiteCommand(V6, con);
                Command.Parameters.AddWithValue("@VoteID", VoteID);
                var vote6 = Command.ExecuteScalar();
                con.Close();
                Vote6 = vote6.ToString();
                label2.Text = Vote6;

                String V7 = "Select count(*) from tblPreferential where Vote3 = 2 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand comma = new SQLiteCommand(V7, con);
                comma.Parameters.AddWithValue("@VoteID", VoteID);
                var vote7 = comma.ExecuteScalar();
                con.Close();
                Vote7 = vote7.ToString();
                label3.Text = Vote7;

                String V8 = "Select count(*) from tblPreferential where Vote4 = 2 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand Comman = new SQLiteCommand(V8, con);
                Comman.Parameters.AddWithValue("@VoteID", VoteID);
                var vote8 = Comman.ExecuteScalar();
                con.Close();
                Vote8 = vote8.ToString();
                label4.Text = Vote8;

                String V9 = "Select count(*) from tblPreferential where Vote1 = 3 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm1 = new SQLiteCommand(V9, con);
                cm1.Parameters.AddWithValue("@VoteID", VoteID);
                var vote9 = cm1.ExecuteScalar();
                con.Close();
                label5.Text = vote9.ToString();

                String V10 = "Select count(*) from tblPreferential where Vote2 = 3 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm2 = new SQLiteCommand(V10, con);
                cm2.Parameters.AddWithValue("@VoteID", VoteID);
                var vote10 = cm2.ExecuteScalar();
                con.Close();
                label6.Text = vote10.ToString();

                String V11 = "Select count(*) from tblPreferential where Vote3 = 3 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm3 = new SQLiteCommand(V11, con);
                cm3.Parameters.AddWithValue("@VoteID", VoteID);
                var vote11 = cm3.ExecuteScalar();
                con.Close();
                label7.Text = vote11.ToString();

                String V12 = "Select count(*) from tblPreferential where Vote4 = 3 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm4 = new SQLiteCommand(V12, con);
                cm4.Parameters.AddWithValue("@VoteID", VoteID);
                var vote12 = cm4.ExecuteScalar();
                con.Close();
                label8.Text = vote12.ToString();

                String V13 = "Select count(*) from tblPreferential where Vote1 = 4 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm5 = new SQLiteCommand(V13, con);
                cm5.Parameters.AddWithValue("@VoteID", VoteID);
                var vote13 = cm5.ExecuteScalar();
                con.Close();
                label13.Text = vote13.ToString();

                String V14 = "Select count(*) from tblPreferential where Vote2 = 4 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm6 = new SQLiteCommand(V14, con);
                cm6.Parameters.AddWithValue("@VoteID", VoteID);
                var vote14 = cm6.ExecuteScalar();
                con.Close();
                label14.Text = vote14.ToString();

                String V15 = "Select count(*) from tblPreferential where Vote3 = 4 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm7 = new SQLiteCommand(V15, con);
                cm7.Parameters.AddWithValue("@VoteID", VoteID);
                var vote15 = cm7.ExecuteScalar();
                con.Close();
                label15.Text = vote15.ToString();

                String V16 = "Select count(*) from tblPreferential where Vote4 = 4 and VoteID = @VoteID";
                con.Open();
                SQLiteCommand cm8 = new SQLiteCommand(V16, con);
                cm8.Parameters.AddWithValue("@VoteID", VoteID);
                var vote16 = cm8.ExecuteScalar();
                con.Close();
                label16.Text = vote16.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Preferential_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
