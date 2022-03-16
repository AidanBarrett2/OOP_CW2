using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace CW1
{
        public class CountVotes
    {
        public string Cand1 { get; set; }
        public String Cand2 { get; set; }
        public String Cand3 { get; set; }

        public String Cand4 { get; set; }
        public CountVotes(string C1, String C2, String C3, String C4) 
        {

            this.Cand1 = C1;
            this.Cand2 = C2;
            this.Cand3 = C3;
            this.Cand4 = C4;
            Console.WriteLine("C1");
        }
        
                    
     }
}
