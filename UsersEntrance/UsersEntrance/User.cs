using System;
using System.Collections.Generic;
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

        private int _userID;
        private string _firstName;
        private string _lastName;
        private int _gate;
    }
}
