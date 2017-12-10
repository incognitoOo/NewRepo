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
            contactCashe = null;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.OpenHomePage();
            InitContactModification(index);
        
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");

            return new ContactData(firstName, lastName, address)
            {
                WorkPhone=workPhone,
                HomePhone=homePhone,
                MobilePhone=mobilePhone
            };
        }

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index].
                FindElements(By.TagName("td"))[7].
                FindElements(By.TagName("a")).Click();
           

        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            InitContactModification(index);
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
          
            string lastName = cells[1].Text;
               string firstName = cells[2].Text;
                string address = cells[3].Text;
                string allPhones = cells[5].Text;
       
 
    
            return new ContactData(firstName, lastName, address)
            {
                AllPhones = allPhones
            };
        } 

        public void FillContactData(ContactData contact)
        {
            Fill_INFO("firstname", contact.Firstname);
            Fill_INFO("lastname", contact.Lastname);
            Fill_INFO("address", contact.Address);
       
         
            if (contact.HomePhone != null)
            {
                Fill_INFO("home", contact.HomePhone);
            }
            if (contact.WorkPhone != null)
            {
                Fill_INFO("work", contact.WorkPhone);
            }
            if (contact.MobilePhone != null)
            {
                Fill_INFO("mobile", contact.MobilePhone);
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
            contactCashe = null;
        }
        public void SubmitContactUpdate()
        {
            // driver.FindElement(By.XPath(".//*[@id='content']/form[1]/input[22]")).Click();
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
        }
        public void SubmitContactCreation()
        {
            //   driver.FindElement(By.XPath(".//*[@id='content']/form/input[21]")).Click();
            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;

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
            string contactWorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string contactHomePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string contactMobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");



            return new ContactData(contactFirstname, contactLastname, contactAddress) { WorkPhone = contactWorkPhone,MobilePhone = contactMobilePhone, HomePhone=contactHomePhone };


        }


        private List<ContactData> contactCashe= null;
        public List<ContactData> GetContactList()
        {

            if (contactCashe == null) {
                contactCashe = new List<ContactData>();
         
            ICollection<IWebElement> elemnts = driver.FindElements(By.CssSelector("table tr"));


            foreach (IWebElement elemnt in elemnts.Skip(1))
            {



                    contactCashe.Add(new ContactData(elemnt.FindElements(By.TagName("td"))[2].Text, elemnt.FindElements(By.TagName("td"))[1].Text));


            }
            }
            return new List<ContactData> (contactCashe);
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
