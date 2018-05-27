using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SelelniumParallenTest
{

    [TestFixture]
    public class Hooks : Base
    {
        //initialize the browser for now
        public  Hooks()
        {
            Driver = new ChromeDriver();
        }
    }
}