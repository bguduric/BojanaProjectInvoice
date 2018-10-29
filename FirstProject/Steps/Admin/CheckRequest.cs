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

        private Precondition homePage = new Precondition(Driver);
        private InvoiceValidator AdminhomePage = new InvoiceValidator(Driver);

        [Given(@"User logs in as Admin 1")]
        public void UserLogsInAsAdmin()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();

        }
        [When(@"Admin is on home page 1")]
        public void AdminIsOnHomePage()
        {
            Assert.That(AdminhomePage.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on Invoice Validator button and select accounting period")]
        public void UserSelectAccountingPeriod()
        {
            AdminhomePage.InvoiceButton().Click();
            Assert.That(AdminhomePage.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            AdminhomePage.RandomAccountingPeriod();
        }
        [Then(@"User clicks on Check request button and downloads request")]
        public void UserClicksOnCheckRequestButton()
        {
            AdminhomePage.CheckRequest().Click();
            Assert.That(AdminhomePage.CheckFileDownloaded(), Is.True, "Report is not downloaded");
        }
    }
}
