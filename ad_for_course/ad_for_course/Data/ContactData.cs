using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string address;
        private string work = "";
        private IWebElement webElement;
        private string text;

        public ContactData(string lastname,string firstname) { this.lastname = lastname; this.firstname = firstname; }

        public ContactData(string firstname, string lastname, string address ) { this.firstname = firstname; this.lastname = lastname; this.address = address; }

        public ContactData(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public ContactData(string text)
        {
            this.text = text;
        }

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
            return Firstname == other.Firstname && Lastname==other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Person=" + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 0;
            }
            return (Firstname.CompareTo(other.Firstname)) & (Lastname.CompareTo(other.Lastname));
        }

        
    }
}
