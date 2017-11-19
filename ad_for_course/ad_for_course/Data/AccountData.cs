using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AccountData

    {
        private string username;
        private string userpassword;
        public AccountData(string username,string userpassword) { this.username = username; this.userpassword = userpassword; }
        public string Username { get { return username; } set { username = value; } }
        public string Userpassword { get { return userpassword; } set { userpassword = value; } }
    }
}
