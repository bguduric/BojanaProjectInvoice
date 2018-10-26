using FirstProject.Pages;
using FirstProject.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin
{
    [Binding]
    class LanguageAdminTest : BaseSteps
    {

//User logs in as admin and change languages

        [Given(@"User navigates to Invoice Validator Web application 6")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
        }

        [When(@"User logs in as Admin 6")]
        public void UserLogsInAsAdmin()
        {
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [When(@"Admin is on home page 6")]
        public void AdminIsOnHomePage()
        {
            LanguageAdmin AdminhomePage5 = new LanguageAdmin(Driver);
            Assert.That(AdminhomePage5.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on RS option language is changed")]
        public void AdminClicsOnRsOption()
        {
            LanguageAdmin changeLanguage = new LanguageAdmin(Driver);
            changeLanguage.LanguageButton().Click();
            changeLanguage.RSOption().Click();
        }
        [Then(@"User clicks on EN option and back to english")]
        public void AdminClicksOnEnOption()
        {
            LanguageAdmin changeLanguageEn = new LanguageAdmin(Driver);
            changeLanguageEn.LanguageButton().Click();
            changeLanguageEn.ENOption().Click();
        }
    }
}
