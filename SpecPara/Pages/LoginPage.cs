using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Operations;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecPara.Pages
{
    class LoginPage
    {
        public IWebDriver _driver;

        //Class way of initializing Page via POM concept-Unitil selenium 3.10
//        public LoginPage()
//        {
//            PageFactory.InitElements(Driver,this);
//        }
//        [FindsBy(How = How.XPath,Using = "")]
//        public IWebElement UserName { get; set; }
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement UserName => _driver.FindElement(By.XPath(""));
    }
}