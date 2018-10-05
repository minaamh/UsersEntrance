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
            Console.WriteLine("Please enter your First Name");
            u1.Firstname = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter your Last Name");
            u1.Lastname = Console.ReadLine().ToUpper();

            string query = $"SELECT TOP 1 [UserID]  FROM [UsersEntrance].[dbo].[UsersEntrance] where [FirstName] = '{u1.Firstname}' and [LastName] = '{u1.Lastname}'";
            string connectionString = "server=Localhost;Trusted_Connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                u1.UserID = connection.Query<int>(query).ElementAt(0);

                Console.WriteLine(u1.UserID);

            }
        }
    }
}
