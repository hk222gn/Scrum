using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegister
{
    //förnamn, efternamn och telefonnummer, ett unikt medlemsnummer

    //public struct MemberInformation
    //{
    //    public string PhoneNumber { get; set; }
    //}
    class Member//: IComparable, IComparable<Member>
    {
        //private List<MemberInformation> _memberInformation;
        private string _name; //Full name.
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

        //public IReadOnlyCollection<MemberInformation> MemberInformation
        //{
        //    get { return _memberInformation.AsReadOnly(); }
        //}

        public Member(string name)
        {
            Name = name;
            //Do not think there is need for more.
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
