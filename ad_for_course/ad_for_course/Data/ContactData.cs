using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string address;
        private string work = "";

        public ContactData(string firstname, string lastname, string address ) { this.firstname = firstname; this.lastname = lastname; this.address = address; }
        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Work { get { return work; } set { work = value; } }






    }
}
