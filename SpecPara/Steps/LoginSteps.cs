using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecPara.Steps
{
    [Binding]
    public class LoginSteps
    {
        //Here I want to use the _driver in the Hooks
        private readonly IWebDriver _driver;


        //下面的deiver 变量就是ChromeDriver
        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to the application")]
        public void GivenINavigateToTheApplication()
        {
            _driver.Navigate().GoToUrl("http://www.executeautomation.com/demosite/Login.html");
        }

        [Given(@"I enter tne username and password")]
        public void GivenIEnterTneUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            foreach (var VARIABLE in data)
            {
                _driver.FindElement(By.Name("UserName")).SendKeys(VARIABLE.UserName);
                _driver.FindElement(By.Name("Password")).SendKeys(VARIABLE.Password);
            }
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            _driver.FindElement(By.Name("Login")).Submit();
        }


        [Then(@"I should see the user login into the application")]
        public void ThenIShouldSeeTheUserLoginIntoTheApplication()
        {
            Console.WriteLine("I Login");
            IWebElement element = _driver.FindElement(By.XPath("/html/body/h1"));
            //if the test is null ,  "Header is not fount" print out.
            Assert.That(element.Text, Is.Not.Null, "Header is not fount");
        }
    }
}