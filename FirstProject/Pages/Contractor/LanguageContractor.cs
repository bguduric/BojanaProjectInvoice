using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Contractor
{
    class LanguageContractor
    {
        private IWebDriver driver;

        public LanguageContractor(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsContractorPageDisplayed()
        {
            By contractorHomePage = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//a[@class='navbar-brand']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(contractorHomePage)).Displayed;
        }
        public IWebElement LanguageConButton()
        {
            By languageConButton = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[3]//li[@class='dropdown']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageConButton));
        }
        public IWebElement RSOptionCon()
        {
            By rsOption2 = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[3]//li[1]//ul//li[2]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rsOption2));
        }
        public IWebElement ENOptionCon()
        {
            By enOption2 = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[3]//li[1]//ul//li[1]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(enOption2));
        }
        public IWebElement LanguageDropDown()
        {
            By languageDropdown = By.XPath("//ul[@class='nav navbar-nav navbar-right']//li[@class='dropdown']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(languageDropdown));

        }
    }
}
