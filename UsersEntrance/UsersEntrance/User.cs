using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersEntrance
{
    class User
    {
        public User()
        {
     
        }

        public User(int userID, string firstName, string lastName, int gate)
        {
            _userID = userID;
            _firstName = firstName;
            _lastName = lastName;
            _gate = gate;
        }

        internal void ChooseGate()
        {
            Console.WriteLine("Please enter the number of the gate you're entering from (1/2):");
            try
            {
                this.Gate = Int32.Parse(Console.ReadLine());
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Please input a valid number");
                Console.WriteLine(ex.Message);
            }
             finally
            {
                InputGateNumber();
            }

            InputGateNumber();
        }

        private void InputGateNumber()
        {
            while (this.Gate != 1 && this.Gate != 2)
            {
                Console.WriteLine("Please enter a valid gate number (1/2):");
                this.Gate = Int32.Parse(Console.ReadLine());
            }
        }

        internal void MakeEntry(string connectionString)
        {
            string insertQuery = $"INSERT INTO [UsersEntrance].[dbo].[UsersEntrance]([UserID], [Gate], [TimeStamp]) VALUES ({this.UserID}, {this.Gate}, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")}')";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(insertQuery);
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("An Error occured while connecting to the database:");
                Console.WriteLine(sqlEx.Message);
                System.Environment.Exit(1);
            }
        }

        internal void ExtractID(string connectionString)
        {
            Console.WriteLine("Please enter your First Name");
            this.Firstname = Console.ReadLine();
            Console.WriteLine("Please enter your Last Name");
            this.Lastname = Console.ReadLine();
            string query = $"SELECT TOP 1 [UserID]  FROM [UsersEntrance].[dbo].[Users] where [FirstName] = '{this.Firstname}' and [LastName] = '{this.Lastname}'";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    if (connection.Query<int>(query).ToArray().Length != 0)
                    {
                        this.UserID = connection.Query<int>(query).ElementAt(0);
                    }
                    else
                    {
                        Console.WriteLine("User Not found in table");
                        System.Environment.Exit(1);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("An Error occured while connecting to the database:");
                Console.WriteLine(sqlEx.Message);
                System.Environment.Exit(1);
            }

            
        }

        public int UserID
        {
            get
            {
                return _userID;
            }

            set
            {
                _userID = value;
            }
        }

        public string Firstname
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public int Gate
        {
            get
            {
                return _gate;
            }
            set
            {
                _gate = value;
            }
        }
        private int _userID;
        private string _firstName;
        private string _lastName;
        private int _gate;
    }
}
