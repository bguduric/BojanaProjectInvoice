using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps
{

        [Binding]
        public class BaseSteps
        {
            public static IWebDriver Driver { get; private set; }

            [BeforeScenario]
            public static void BeforeScenario()
            {
                Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();
            Driver.Url = ConfigurationManager.AppSettings["URL"];

        }

        [AfterScenario]
            public static void AfterScenario()
            {
                Driver.Quit();
            }
        }
    
}
