using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
   public class GroupHelper
    {
        private IWebDriver driver;
        public GroupHelper(IWebDriver driver)
        {

            this.driver = driver;
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillGroupData(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.GroupName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter);
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
            return ids[ids.Count - 1];
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
    }
}
