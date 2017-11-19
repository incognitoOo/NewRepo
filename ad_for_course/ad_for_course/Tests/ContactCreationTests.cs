using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreationTest : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitCreationContact();
            ContactData contact = new ContactData("FIRSTNAME", "LASTNAME", "ADDRESS");
            contact.Middlename = "MiddleName";
            contact.Work = "Work";
            app.Contact.FillContactData(contact);
            app.Contact.SubmitCreationContact();
            
        }
       
       
       

       



    }
}
