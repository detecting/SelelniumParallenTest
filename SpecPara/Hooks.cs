using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecPara
{
    [Binding]
    public class Hooks
    {
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extentReports;

        //if I want to fo the context injection and  IObjectContainer
        //Hook 用来初始化变量，供所有的binding使用；
        public readonly IObjectContainer _ObjectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer iObjectContainer)
        {
            _ObjectContainer = iObjectContainer;
        }

        [BeforeTestRun]
        //这里必须是静态的
        public static void InitializeReport()
        {
            Console.WriteLine("BeforeTestRun");
            //Create the html report,//Initialize Extent report before test starts
            var htmlReport =
                new ExtentHtmlReporter(
                    @"C:\Users\hzha321\RiderProjects\SelelniumParallenTest\SpecPara\Report\exReport.html");
            htmlReport.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
//            Attach report to reporter
            var extent = new ExtentReports();
            extentReports.AttachReporter(htmlReport);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            Console.WriteLine("AfterTestRun");
            //Flush report once test completes
            extentReports.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("BeforeFeature");
            //Create dynamic feature name
            featureName =
                extentReports.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current
                    .FeatureInfo
                    .Title);
        }

        [AfterStep]
        public void InserReportSteps()
        {
            Console.WriteLine("AfterStep");

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo =
                typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.ToString());
                        break;
                    case "When":
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.ToString());
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.ToString());
                        break;
                    default:
                        break;
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.ToString())
                            .Fail(ScenarioContext.Current.TestError.InnerException);
                        break;
                    case "When":
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.ToString())
                            .Fail(ScenarioContext.Current.TestError.InnerException);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.ToString())
                            .Fail(ScenarioContext.Current.TestError.Message);
                        break;
                    default:
                        break;
                }
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
            }
        }

        [BeforeScenario]
        public void Initialize()
        {
            Console.WriteLine("BeforeScenario");
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.ToString());
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