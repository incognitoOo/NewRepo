using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests { 

    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.GoToGroupPage();
            if (!app.Group.IsGroupPresent())
            {
                GroupData group = new GroupData("HOPHEY");
                app.Group.InitCreationGroup();
                app.Group.FillGroupForm(group);
                app.Group.SubmitInfo();
            }
            app.Navigation.GoToGroupPage();
            int lastid = app.Group.LastId();
            app.Group.SelectGroup_ById(lastid);
            app.Group.RemoveGroup();
        }


    }
}
