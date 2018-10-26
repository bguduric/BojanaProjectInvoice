using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class LanguageAdmin
    {
        private IWebDriver driver;

        public LanguageAdmin(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsAdminPageDisplayed()
        {
            By adminHomePage = By.XPath("//div[@class='form-horizontal']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(adminHomePage)).Displayed;
        }
        public IWebElement LanguageButton()
        {
            By languageButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[6]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageButton));
        }
        public IWebElement RSOption()
        {
            By rsOption = By.XPath("//div[@class='navbar-collapse collapse']//ul[6]//li[1]//ul[1]//li[2]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rsOption));
        }
        public IWebElement ENOption()
        {
            By enOption = By.XPath("//div[@class='navbar-collapse collapse']//ul[6]//li[1]//ul[1]//li[1]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(enOption));
        }

    }
}
