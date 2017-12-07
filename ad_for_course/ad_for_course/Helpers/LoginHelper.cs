using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }
            Fill_INFO("user", user.Username);
            Fill_INFO("pass", user.Userpassword);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public bool IsLoggedIn(string username)
        {

            return IsLoggedIn() && GetLoggetUserName() == username;
                //driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + username + ")";
        }
        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
    }
}
