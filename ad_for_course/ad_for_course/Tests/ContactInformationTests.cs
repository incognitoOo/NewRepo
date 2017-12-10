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
    public class ContactInformationTests: AuthBase
    {
        [Test]
     public void ContactInformationTest()
        {
          
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);
            ContactData fromTable =  app.Contact.GetContactInformationFromTable(0);


            //verifacation

            Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);




        }


    }
}
