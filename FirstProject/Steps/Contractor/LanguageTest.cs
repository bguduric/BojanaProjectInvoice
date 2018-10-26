using FirstProject.Pages;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Contractor
{
    [Binding]
    class LanguageTest : BaseSteps
    {
        [Given(@"User navigates to Invoice Validator web app 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
        }

        [When(@"User logs in as Contractor")]
        public void UserLogsInAsAdmin()
        {
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");

            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [When(@"Contractor is on home page")]
        public void AdminIsOnHomePage()
        {
            LanguageContractor contrHomePage = new LanguageContractor(Driver);
            Assert.That(contrHomePage.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on RS option language is changed 2")]
        public void AdminClicsOnRsOption()
        {
            LanguageContractor changeLanguage = new LanguageContractor(Driver);
            changeLanguage.LanguageConButton().Click();
            changeLanguage.RSOptionCon().Click();
        }
        [Then(@"User clicks on EN option and back to english 2")]
        public void AdminClicksOnEnOption()
        {
            LanguageContractor changeLanguageEn = new LanguageContractor(Driver);
            changeLanguageEn.LanguageConButton().Click();
            changeLanguageEn.ENOptionCon().Click();
        }
    }
}
