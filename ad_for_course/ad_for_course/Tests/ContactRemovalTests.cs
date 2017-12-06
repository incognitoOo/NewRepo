using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contact.IsContactPresent())
            {
                ContactData contact = new ContactData("1", "12", "123Poipoi");
                app.Navigation.OpenContactCreationPage();
                app.Contact.FillContactData(contact);
                app.Contact.SubmitContactCreation();
            }
            
            app.Navigation.OpenHomePage();
            List<ContactData> oldGroups = app.Contact.GetContactList();
            int old_Con_Num = app.Contact.Count_Contacts();
            int lastid = app.Contact.Last_Con_Id();
            app.Contact.OpenContact_by_Id(lastid);
            Thread.Sleep(1000);
            app.Contact.ContactDelete();
            app.Navigation.OpenHomePage();
            Thread.Sleep(1000);
            int new_Con_Num = app.Contact.Count_Contacts() + 1;
            Assert.AreEqual(old_Con_Num, new_Con_Num);
            List<ContactData> newGroups = app.Contact.GetContactList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
