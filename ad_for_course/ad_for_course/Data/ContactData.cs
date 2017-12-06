using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string address;
        private string work = "";
   

        public ContactData(string firstname, string lastname) { this.firstname = firstname; this.lastname = lastname; }

        public ContactData(string firstname, string lastname, string address ) { this.firstname = firstname; this.lastname = lastname; this.address = address; }

      

        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Work { get { return work; } set { work = value; } }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, null))
            {
                return true;
            }
            return Firstname == other.Firstname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Name/Lastname=" + Firstname + " " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Firstname.CompareTo(other.Firstname));
        }

        
    }
}
