﻿using System;
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
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            int lastid = app.Contact.Last_Con_Id();
            app.Contact.OpenContact_by_Id(lastid);
            Thread.Sleep(1000);
            app.Contact.ContactDelete();
        }
    }
}
