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

namespace CW2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        public static string sendtext = "";
        string Permission = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (UsernameText.Text.Trim() == "" && PasswordText.Text.Trim() == "")
            {
                MessageBox.Show("Your Username and Password combination are incorrect", "Error");
            }
            else
            {
                String Query = "Select * From tblVoter Where VoterUsername = @user and VoterPassword = @Pass";
                SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(Query, connection);
                command.Parameters.AddWithValue("@User", UsernameText.Text);
                command.Parameters.AddWithValue("@Pass", PasswordText.Text);
                SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    using (var con = new SQLiteConnection(connection))
                    {
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "Select VoterPermissions from tblVoter where VoterUsername = @Username";
                        cmd.Parameters.AddWithValue("@Username", UsernameText.Text);
                        var result = cmd.ExecuteScalar();
                        con.Close();
                        Permission = result.ToString();
                    }
                    if (Permission == "Voter")
                    {
                        sendtext = UsernameText.Text;
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.ShowDialog();
                    }
                    if(Permission == "Administrator")
                    {
                        sendtext = UsernameText.Text;
                        this.Hide();
                        AdminLandingPage ALP= new AdminLandingPage();
                        ALP.ShowDialog();
                    }
                    if (Permission == "Auditer")
                    {
                        sendtext = UsernameText.Text;
                        this.Hide();
                        AuditerLandingPage ALP = new AuditerLandingPage();
                        ALP.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register RG = new Register();
            RG.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
