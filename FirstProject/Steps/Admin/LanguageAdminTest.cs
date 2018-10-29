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

        private Precondition homePage = new Precondition(Driver);
        private LanguageAdmin AdminhomePage5 = new LanguageAdmin(Driver);

//User logs in as admin and change languages

        [Given(@"User logs in as Admin 6")]
        public void UserLogsInAsAdmin()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();

        }
        [When(@"Admin is on home page 6")]
        public void AdminIsOnHomePage()
        {
            Assert.That(AdminhomePage5.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on RS option language is changed")]
        public void AdminClicsOnRsOption()
        {
            AdminhomePage5.LanguageButton().Click();
            AdminhomePage5.RSOption().Click();
        }
        [Then(@"User clicks on EN option and back to english")]
        public void AdminClicksOnEnOption()
        {
            AdminhomePage5.LanguageButton().Click();
            AdminhomePage5.ENOption().Click();
        }
    }
}
