using FirstProject.Pages;
using FirstProject.Pages.Admin;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin
{
    [Binding]
    class CheckRequest : BaseSteps
    {

//User logs in as admin and download request

        [Given(@"User navigates to Invoice Validator web application 1")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
        }
        [When(@"User logs in as Admin 1")]
        public void UserLogsInAsAdmin()
        {
            Precondition homePage = new Precondition(Driver);
            //homePage.SignInLink().Click();
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [When(@"Admin is on home page 1")]
        public void AdminIsOnHomePage()
        {
            InvoiceValidator AdminhomePage = new InvoiceValidator(Driver);
            Assert.That(AdminhomePage.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on Invoice Validator button and select accounting period")]
        public void UserSelectAccountingPeriod()
        {
            InvoiceValidator adminHome = new InvoiceValidator(Driver);
            adminHome.InvoiceButton().Click();
            Assert.That(adminHome.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            adminHome.RandomAccountingPeriod();
        }
        [Then(@"User clicks on Check request button and downloads request")]
        public void UserClicksOnCheckRequestButton()
        {
            InvoiceValidator adminHomeCheck = new InvoiceValidator(Driver);
            adminHomeCheck.CheckRequest().Click();
            Assert.That(adminHomeCheck.CheckFileDownloaded(), Is.True, "Report is not downloaded");
        }
    }
}
