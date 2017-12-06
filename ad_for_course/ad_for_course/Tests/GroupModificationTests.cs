using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupModificationsTests: AuthBase
    {
        [Test]
        public void GroupModificationsTest()
        {


            app.Navigation.GoToGroupPage();
            if (!app.Group.IsGroupPresent())
            {
                GroupData gr = new GroupData("HOPHEY");
                app.Group.InitCreationGroup();
                app.Group.FillGroupForm(gr);
                app.Group.SubmitInfo();
            }

            GroupData group = new GroupData("Group 2") { GroupHeader = "HEADER 2",GroupFooter = "FOOTER 2" };
            
            app.Navigation.GoToGroupPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.SelectGroup_ById(app.Group.LastId());
            app.Group.OpenGroupEditPage();
            app.Group.FillGroupForm(group);
            app.Group.Submit_Update();
            List<GroupData> newGroups = app.Group.GetGroupList();
            app.Navigation.GoToGroupPage();
            GroupData group1 = app.Group.LastCreatedGroupData();
            Assert.AreEqual(group.GroupName, group1.GroupName);

            if (group.GroupHeader != null) Assert.AreEqual(group.GroupHeader, group1.GroupHeader);
            if (group.GroupFooter != null) Assert.AreEqual(group.GroupFooter, group1.GroupFooter);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }


}
