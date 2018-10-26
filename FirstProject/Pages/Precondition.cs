using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages
{
    class Precondition
    {
        private IWebDriver driver;

        public Precondition(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }

        public bool IsSignInDisplayed()
        {
            By signInVisible = By.CssSelector("div[class='navbar-collapse collapse']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signInVisible)).Displayed;
        }
        public IWebElement UsernameInputField()
        {
            By username = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(username));
        }

        public IWebElement PasswordInputField()
        {
            By password = By.Id("Password");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(password));
        }

        public IWebElement SignInButton()
        {
            By signIn = By.XPath("//button[@class='btn btn-default btn-primary']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(signIn));
        }
        public bool IsAdminsHeaderDisplayed()
        {
            By headerVisible = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(headerVisible)).Displayed;
        }
        public IWebElement IsErrorMessageDisplayed()
        {
            By errorVisible = By.XPath("//div[@class='alert alert-warning']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorVisible));
        }
        public IWebElement LogOutAsAdmin()
        {
            By logout_as_admin = By.XPath("//div[@class='navbar-collapse collapse']//ul//li[4]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(logout_as_admin));
        }
       
    }
}
