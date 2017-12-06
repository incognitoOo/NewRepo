using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests { 

    [TestFixture]
    public class GroupRemovalTests: AuthBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupPage();
            if (!app.Group.IsGroupPresent())
            {
                GroupData group = new GroupData("HOPHEY");
                app.Group.InitCreationGroup();
                app.Group.FillGroupForm(group);
                app.Group.SubmitInfo();
            }
           
            app.Navigation.GoToGroupPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            int oldGroupsNumber = app.Group.Count_Groups();
            int lastid = app.Group.LastId();
            app.Group.SelectGroup_ById(lastid);
            app.Group.RemoveGroup();
            int newGroupsNumber = app.Group.Count_Groups() + 1;
            Assert.AreEqual(oldGroupsNumber, newGroupsNumber);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        
        }


    }
}
