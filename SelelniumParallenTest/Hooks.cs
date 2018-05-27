using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SelelniumParallenTest
{
    public enum BroserType
    {
        Chrome,
        Firefox
    }

    [TestFixture]
    public class Hooks : Base
    {
        public BroserType _broserType;

        //initialize the browser for now
        public Hooks(BroserType broser)
        {
            _broserType = broser;
        }

        [SetUp]
        public void Initialize()
        {
            ChooseDriverInstance(_broserType);
        }

        public void ChooseDriverInstance(BroserType broserType)
        {
            if (broserType == BroserType.Chrome)
            {
                Driver = new ChromeDriver();
            }

            if (broserType == BroserType.Firefox)
            {
                Driver = new FirefoxDriver();
            }
        }
    }
}