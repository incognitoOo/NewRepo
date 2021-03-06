﻿using System;
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
    public class CreationTest : AuthBase
    {

        [Test]
        public void ContactCreationTest()
        {



            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData contact = new ContactData("FIRSTNAME", "LASTNAME", "ADDRESS") {  WorkPhone="12312322",MobilePhone = "89195656565",HomePhone="222-222-22" };
            app.Contact.InitCreationContact();
            app.Contact.FillContactData(contact);
            app.Contact.SubmitCreationContact();
            app.Navigation.OpenHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            ContactData n_con = app.Contact.Last_Cont_Data();
            Assert.AreEqual(contact.Firstname, n_con.Firstname);
            Assert.AreEqual(contact.Lastname, n_con.Lastname);
            Assert.AreEqual(contact.Address, n_con.Address);
            if (contact.WorkPhone != null)
            Assert.AreEqual(n_con.WorkPhone, contact.WorkPhone);
        
        
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
       
       
       

       



    }
}
