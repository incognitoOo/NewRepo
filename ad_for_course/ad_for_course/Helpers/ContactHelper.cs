using OpenQA.Selenium;
using System;
using System.Collections;
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
        public ContactData GetContactData()
        {
            string contactFirstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string contactLastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string contactAddress = driver.FindElement(By.Name("address")).GetAttribute("value");
            string contactWork = driver.FindElement(By.Name("work")).GetAttribute("value");
            string contactMiddlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            return new ContactData(contactFirstname, contactLastname, contactAddress) { Work = contactWork };


        }
        public List<ContactData> GetContactList()
        {

            List<ContactData> contact = new List<ContactData>();


            ICollection<IWebElement> rows = driver.FindElements(By.CssSelector("table tr"));
            
            foreach (IWebElement row in rows.Skip(1))
            {

              IList td = row.FindElements(By.CssSelector("tr td"));
                ICollection<IWebElement> td2 = row.FindElements(By.CssSelector("tr td"));

                //var a = row.T;
                foreach (IWebElement td1 in td2.Skip(1).Take(2))
                {
                    contact.Add(new ContactData(td1.Text));
                }
                
            }
            return contact; // country not found
                          //OpenContact_by_Id(1);
                          //  ICollection<IWebElement> elemnts = driver.FindElements(By.CssSelector("input[name='selected[]']"));
                          //  ICollection <IWebElement> table = driver.FindElements(By.Id("maintable"));

            //забрал эти элементы

            //  foreach (IWebElement elemnt in table)
            // {
            //    IList cells = elemnt.FindElements(By.TagName("tr"));


          //   var a = new ContactData(elemnt.Text);

            // IList cells = elemnt.FindElements(By.TagName("td"));

            /* Char delimiter = ' ';
             String[] substrings = a.Split(delimiter);
             foreach (var substring in substrings)
                 Console.WriteLine(substring);*/

            //  contact.Add(new ContactData(elemnt.Text));

            // }
            // return contact;
        }
        public ContactData Last_Cont_Data()
        {
            OpenContact_by_Id(Last_Con_Id());
            return GetContactData();
        }
        public int Count_Contacts()
        {
            return driver.FindElements(By.CssSelector("input[name='selected[]']")).Count;
        }
    }
}
