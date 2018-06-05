using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecPara.Steps
{
    [Binding]
    public class UserFormSteps
    {

        private readonly IWebDriver _driver;

        public UserFormSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I start entering user form details like")]
        public void GivenIStartEnteringUserFormDetailsLike(Table table)
        {
            
            dynamic data = table.CreateDynamicSet();
            foreach (var VARIABLE in data)
            {
                _driver.FindElement(By.Id("Initial")).SendKeys(VARIABLE.Initial);
                _driver.FindElement(By.Id("FirstName")).SendKeys(VARIABLE.FirstName);
                _driver.FindElement(By.Id("MiddleName")).SendKeys(VARIABLE.MiddleName);
                Thread.Sleep(2000);
            }
        }

        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
    }
}