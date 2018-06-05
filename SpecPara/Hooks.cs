using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecPara
{
    [Binding]
    public class Hooks
    {
        //if I want to fo the context injection and  IObjectContainer
        //Hook 用来初始化变量，供所有的binding使用；
        public readonly IObjectContainer _ObjectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer iObjectContainer)
        {
            _ObjectContainer = iObjectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            Console.WriteLine("BeforeScenario");
            //先初始化在进行注册
            _driver = new ChromeDriver();
            //the most important step
            //register the instance object
            //在运行之前将driver注册到容器
            _ObjectContainer.RegisterInstanceAs<IWebDriver>(_driver);

        }

        [AfterScenario]
        public void ClearUp()
        {
            Console.WriteLine("AfterScenario");
//            Driver.Quit();
        }
    }
}