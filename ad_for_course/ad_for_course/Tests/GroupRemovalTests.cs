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
            
            if (!app.Group.IsGroupPresent())
            {
                GroupData group = new GroupData("HOPHEY");
                app.Group.InitCreationGroup();
                app.Group.FillGroupForm(group);
                app.Group.SubmitInfo();
            }
            app.Navigation.GoToGroupPage();
            int oldGroupsNumber = app.Group.LastId();
            int lastid = app.Group.LastId();
            app.Group.SelectGroup_ById(lastid);
            app.Group.RemoveGroup();
            int newGroupsNumber = app.Group.Count_Groups() + 1;
            Assert.AreEqual(oldGroupsNumber, newGroupsNumber);
        }


    }
}
