using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebAddressbookTests
{
   public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }


        public void InitCreationGroup()
        {
            driver.FindElement(By.Name("new")).Click();
        }
       public int LastId()
        {
           

            ICollection<IWebElement> groups = driver.FindElements(By.CssSelector("input[name='selected[]']"));
            List<int> ids = new List<int>();
            foreach (IWebElement contact in groups)
            {
                ids.Add(Convert.ToInt32(contact.GetAttribute("value")));
            }
            ids.Sort();
            return ids[ids.Count-1];
        }
        public void SelectGroup_ById(int id)
        {
            driver.FindElement(By.CssSelector(".group>input[value='" + id + "']")).Click();
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        public void OpenGroupEditPage()
        {
            driver.FindElement(By.Name("edit")).Click();
        }
        public void Submit_Update()
        {
            driver.FindElement(By.Name("update")).Click();
        }
        public bool IsGroupPresent()
        {

            return IsElementPresent(By.CssSelector("input[name='selected[]']"));
        }
       
        public void FillGroupForm(GroupData group)
        {

            Fill_INFO("group_name", group.GroupName);
            if (group.GroupName != null)
            {
                Fill_INFO("group_header", group.GroupHeader);
            }
            if (group.GroupFooter != null)
            {
                Fill_INFO("group_footer", group.GroupFooter);
            }
        }
        public void SubmitInfo()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        public GroupData GetCreatedGroupData()
        {
            string gr_Name = driver.FindElement(By.Name("group_name")).GetAttribute("value");
            string header = driver.FindElement(By.Name("group_header")).Text;
            string footer = driver.FindElement(By.Name("group_footer")).Text;
            return new GroupData(gr_Name) { GroupHeader = header, GroupFooter = footer };
        }

        public GroupData LastCreatedGroupData()
        {
            SelectGroup_ById(LastId());
            driver.FindElement(By.Name("edit")).Click();
            return GetCreatedGroupData();
        }
        public int Count_Groups()
        {
            return driver.FindElements(By.CssSelector("input[name='selected[]']")).Count;
        }
    }
}
