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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            ComboBox();
            DOBPicker.Format = DateTimePickerFormat.Custom;
            DOBPicker.CustomFormat = "yyyy-MM-dd";
        }
        String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
        SQLiteDataReader dr;


        private void DOBPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int es;
            int pass;
            int age;
            if (PasswordText.Text.Length < 5)
            {
                MessageBox.Show("Password length must be at least 5 characters", "Error");
            }
            else
            {
                if (UsernameText.Text.Length == 0 || PasswordText.Text.Length == 0 || NameText.Text.Length == 0)
                {
                    MessageBox.Show("Fields are Empty", "Error");
                }
                else
                {
                    using (var con = new SQLiteConnection(connection))
                    {
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "Select CountryVotingAge from tblCountry where CountryName = @Country";
                        cmd.Parameters.AddWithValue("@Country", comboBox1.Text);
                        con.Open();
                        var result = cmd.ExecuteScalar();
                        con.Close();
                        age = Convert.ToInt32(result);
                        MessageBox.Show(age.ToString());
                    }
                    int years = DateTime.Now.Year - DOBPicker.Value.Year;
                    if (DOBPicker.Value.AddYears(years) > DateTime.Now) years--;
                    {
                        if (years >= age)
                        {
                            using (var con = new SQLiteConnection(connection))
                            {
                                con.Open();
                                string stringQuery = "Select COUNT(VoterName) from tblVoter where VoterUsername = '" + UsernameText.Text + "'";
                                SQLiteCommand command = new SQLiteCommand(stringQuery, con);
                                es = Convert.ToInt32(command.ExecuteScalar());
                                if (es == 1)
                                {
                                    MessageBox.Show("This Username is already taken.");
                                }
                                else
                                {
                                }
                                con.Close();
                            }
                            using (var con = new SQLiteConnection(connection))
                            {
                                con.Open();
                                string stringQuery = "Select COUNT(VoterName) from tblVoter where VoterPassword = '" + PasswordText.Text + "'";
                                SQLiteCommand command = new SQLiteCommand(stringQuery, con);
                                pass = Convert.ToInt32(command.ExecuteScalar());
                                if (pass == 1)
                                {
                                    MessageBox.Show("This Password is already taken.");
                                }
                                else
                                {
                                }
                                con.Close();
                            }
                            using (var con = new SQLiteConnection(connection))
                            {
                                con.Open();
                                string stringQuery = "INSERT INTO tblVoter" + "(VoterName, VoterDOB, VoterUsername, VoterPassword, VoterCountry)" + "Values('" + NameText.Text + "','" + DOBPicker.Text + "','" + UsernameText.Text + "','" + PasswordText.Text + "','" + comboBox1.Text + "') ON conflict do update set VoterName = VoterName";
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = con.CreateCommand();
                                SqliteCmd.CommandText = stringQuery;
                                SqliteCmd.ExecuteNonQuery();
                                con.Close();
                                UsernameText.Text = "";
                                PasswordText.Text = "";
                                NameText.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are too young to vote", "Error");
                        }
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f1 = new Login();
            f1.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void ComboBox()
        {
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
                string query = "Select CountryName from tblCountry";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();

                comboBox1.DisplayMember = "CountryName";
                comboBox1.ValueMember = "CountryName";
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.Enabled = true;
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
        }
    }
}

