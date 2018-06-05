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
        }

        [Given(@"I Verify the entered the form detail in the application database")]
        public void GivenIVerifyTheEnteredTheFormDetailInTheApplicationDatabase(Table table)
        {
            //autDatabases is a collection
            List<AUTDatabase> autDatabases=new List<AUTDatabase>()
            {
                //也可以有多个元素（raw）
                new AUTDatabase()
                {
                    Initial = "huamin",
                    FirstName = "zhang",
                    MiddleName = "hello"
                }
            };
            //compare table with the autDatabases to check if they are the same
            var result = table.FindAllInSet(autDatabases);
            Console.WriteLine(result);
        }
    }

    public class AUTDatabase
    {
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
    }
}