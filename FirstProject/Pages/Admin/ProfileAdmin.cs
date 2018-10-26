using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class ProfileAdmin
    {
     
           private IWebDriver driver;

            public ProfileAdmin(IWebDriver driver)
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
            public IWebElement ProfileButton()
            {
                By languageButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[6]//li[3]//a");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageButton));
            }
            public bool IsEditProfileDisplayed()
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/users/edit/"));
            }
            //Edit
            public IWebElement ProfileNameInput()
            {
                By profileName = By.XPath("//input[@id='Firstname']");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileName));
            }
            public IWebElement ProfileLastnameInput()
            {
                By profileLastname = By.XPath("//input[@id='Surname']");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileLastname));
            }
            public IWebElement ProfileSaveButton()
            {
                By profileSaveButton = By.XPath("//input[@type='submit']");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileSaveButton));
            }
            public IWebElement ProfileBackButton()
            {
                By profileBackButton = By.XPath("//div[@class='container body-content']//div//a");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileBackButton));
            }
            //ERROR MESSAGES
            public IWebElement EmptyProfileName()
            {
                By empty_profile_name = By.Id("Firstname-error");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_profile_name));
            }
            public IWebElement EmptyProfileLastName()
            {
                By empty_profile_lastname = By.Id("Surname-error");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_profile_lastname));
            }
        }
}
