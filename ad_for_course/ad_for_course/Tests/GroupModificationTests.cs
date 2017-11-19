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
   public class GroupModificationsTests: TestBase
    {
        [Test]
        public void GroupModificationsTest()
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
            
            GroupData gr = new GroupData("Group 2");
            gr.GroupHeader = "HEADER 2";
            gr.GroupFooter = "FOOTER 2";
            app.Navigation.GoToGroupPage();
            app.Group.SelectGroup_ById(app.Group.LastId());
            app.Group.OpenGroupEditPage();
            app.Group.FillGroupForm(gr);
            app.Group.Submit_Update();
        }

    }


}
