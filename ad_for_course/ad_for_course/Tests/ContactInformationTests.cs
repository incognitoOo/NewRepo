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
            int last_id_group = app.Contact.Last_Con_Id();
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(last_id_group);
            ContactData fromTable =  app.Contact.GetContactInformationFromTable(last_id_group);


            //verifacation

            Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);




        }


    }
}
