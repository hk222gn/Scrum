using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegister
{
    class Member
    {
        private string _name;
        private string _phoneNumber;
        private int _ID;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }

        public Member(string name)
        {
            Name = name;
        }

        public Member(string name, string phoneNumber, int id)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            ID = id;
        }

        public void AddNumber(string number)
        {
            PhoneNumber = number;
        }

        public void AddID(int id)
        {
            ID = id;
        }
    }
}
