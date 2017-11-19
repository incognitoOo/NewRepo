using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  WebAddressbookTests
{
   public class ContactHelper
    {
        private IWebDriver driver;
        public ContactHelper(IWebDriver driver)
        {

            this.driver = driver;
        }
        public void SubmitCreationContact()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
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
        public void OpenContactCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            //driver.Manage().Window.Maximize();
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
    }
}
