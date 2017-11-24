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
    public class GroupCreationTests : AuthBase

    { 

        

        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.GoToGroupPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.InitCreationGroup();
            GroupData group = new GroupData("Group 1") { GroupHeader = "HEADER 1", GroupFooter = "FOOTER 1" };
            app.Group.FillGroupForm(group);
            app.Group.SubmitGroupCreation();
            List<GroupData> newGroups = app.Group.GetGroupList();
            app.Navigation.GoToGroupPage();
            GroupData group1 = app.Group.LastCreatedGroupData();
            Assert.AreEqual(group.GroupName, group1.GroupName);
            if ((group.GroupHeader != null)) Assert.AreEqual(group.GroupHeader, group1.GroupHeader);
            if (group.GroupFooter != null) Assert.AreEqual(group.GroupFooter, group1.GroupFooter);
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }

        

      
        
        
    }
}
