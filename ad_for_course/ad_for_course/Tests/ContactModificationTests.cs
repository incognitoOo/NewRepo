using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests:TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.OpenContact_by_Id(app.Contact.Last_Con_Id());
            ContactData newcontact = new ContactData("iv1an", "petr1ov", "C1haCHa") { Middlename = "ShiShi", Work = "GOGO1GOG" };
            app.Contact.FillContactData(newcontact);
            // Thread.Sleep(10000);
            app.Contact.SubmitContactUpdate();
        }
    }
}
