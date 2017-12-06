using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newcontact = new ContactData("iv1an", "petr1ov", "C1haCHa") { Work = "GOGO1GOG" };

            List<ContactData> oldContacts = app.Contact.GetContactList();
            if (!app.Contact.IsContactPresent())
            {
                app.Navigation.OpenContactCreationPage();
                app.Contact.FillContactData(new ContactData("IVAN", "IVANOVICH", "ChaCHa"));
                app.Contact.SubmitContactCreation();
            }
            app.Navigation.OpenHomePage();
            int last_id_group = app.Contact.Last_Con_Id();
            app.Contact.OpenContact_by_Id(last_id_group);
            app.Contact.FillContactData(newcontact);
            app.Contact.SubmitContactUpdate();
            app.Navigation.OpenHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            ContactData contact = app.Contact.Last_Cont_Data();

            Assert.AreEqual(newcontact.Firstname, contact.Firstname);
            Assert.AreEqual(newcontact.Lastname, contact.Lastname);
            Assert.AreEqual(newcontact.Address, contact.Address);

            if (newcontact.Work != null) Assert.AreEqual(newcontact.Work, contact.Work);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
