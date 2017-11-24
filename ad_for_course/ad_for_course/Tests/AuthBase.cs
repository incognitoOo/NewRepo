using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class AuthBase : TestBase
    {
        

        [SetUp]
        public void SetupLogin()
        {
            app.Navigation.OpenHomePage();
            AccountData user = new AccountData("admin","secret");
            app.Auth.Login(user);
        }

        [TearDown]
        public void AuthTearDown()
        {
            app.Auth.Logout();
        }
    }
}
