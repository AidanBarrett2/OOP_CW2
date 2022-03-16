using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Vote
    {

        static void VoteCandidate1(string[] args)
        {
            String connection = ConfigurationManager.ConnectionStrings["Default"].ToString();
            using (var con = new SQLiteConnection(connection))
            {
                con.Open();
                string stringQuery = "Select Candidate1 from tblvoter where VoteID = ''";
                var SqliteCmd = new SQLiteCommand();
                SqliteCmd = con.CreateCommand();
                SqliteCmd.CommandText = stringQuery;
                SqliteCmd.ExecuteNonQuery();
                con.Close();
            }
        }
        static void VoteCandidate2(string[] args)
        {

        }
        static void VoteCandidate3(string[] args)
        {

        }
        static void VoteCandidate4(string[] args)
        {

        }
    }
}
