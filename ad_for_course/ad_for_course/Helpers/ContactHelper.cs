using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  WebAddressbookTests
{
   public class ContactHelper: HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void SubmitCreationContact()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillContactData(ContactData contact)
        {
            Fill_INFO("firstname", contact.Firstname);
            Fill_INFO("lastname", contact.Lastname);
            Fill_INFO("address", contact.Address);
            if (contact.Middlename != null)
            {
                Fill_INFO("mobile", contact.Middlename);
            }
            if (contact.Work != null)
            {
                Fill_INFO("work", contact.Work);
            }
        }

        public void InitCreationContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
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

        public int Count_Groups()
        {
            return driver.FindElements(By.CssSelector("input[name='selected[]']")).Count;
        }
     
        public int Last_Con_Id()
        {
            ICollection<IWebElement> contacts = driver.FindElements(By.CssSelector("input[name='selected[]']"));
            List<int> ids = new List<int>();
            foreach (IWebElement contact in contacts)
            {
                ids.Add(Convert.ToInt32(contact.GetAttribute("value")));
            }
            ids.Sort();
            return ids[ids.Count - 1];
        }
        public void OpenContact_by_Id(int id)
        {
            driver.FindElement(By.CssSelector("a[href='edit.php?id=" + id + "']>img")).Click();
        }

        public void ContactDelete()
        {
            //driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            //driver.FindElements(By.Name("update"))[2].Click();
            //driver.FindElement(By.Name("update")).Click();
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            driver.FindElement(By.CssSelector("input[value =\"Delete\"]")).Click();
        }
        public void SubmitContactUpdate()
        {
            // driver.FindElement(By.XPath(".//*[@id='content']/form[1]/input[22]")).Click();
            driver.FindElement(By.Name("update")).Click();
        }
        public void SubmitContactCreation()
        {
            //   driver.FindElement(By.XPath(".//*[@id='content']/form/input[21]")).Click();
            driver.FindElement(By.Name("submit")).Click();

        }
        public bool IsContactPresent()
        {
    

            return IsElementPresent(By.XPath(".//*[@id='maintable']/tbody/tr[2]/td[2]"));
        }
    }
}
