using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace UsersEntrance
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User();
            string connectionString = "server=Localhost;Trusted_Connection=true";
            u1.ExtractID(connectionString);
            u1.ChooseGate();
            u1.MakeEntry(connectionString);
        }
    }
}
