using System;
using System.Security.Policy;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SelelniumParallenTest
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting() : base(BroserType.Firefox)
        {
        }

        [Test]
        public void FirefoxGoogleTest()
        {
            string url = "https://www.google.co.nz/";
            Driver.Navigate().GoToUrl(url);
            Driver.FindElement(By.Name("q")).SendKeys("Selenium");
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "selennium does not exist.");
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BroserType.Chrome)
        {
            
        }

        [Test]
        public void CHromeGoogleTest()
        {
            string url = "https://www.google.co.nz/";
            Thread.Sleep(2000);
            Driver.Navigate().GoToUrl(url);
            Driver.FindElement(By.Name("q")).SendKeys("Selenium");
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "selennium does not exist.");
        }
    }
}