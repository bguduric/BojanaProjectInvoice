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
        private Precondition homePage = new Precondition(Driver);
        private LanguageContractor contrHomePage = new LanguageContractor(Driver);

        [Given(@"User logs in as Contractor")]
        public void UserLogsInAsAdmin()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsContractor();
        }
        [When(@"Contractor is on home page")]
        public void AdminIsOnHomePage()
        {
            Assert.That(contrHomePage.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
        }
        [When(@"User clicks on RS option language is changed 2")]
        public void AdminClicsOnRsOption()
        {
            contrHomePage.LanguageConButton().Click();
            contrHomePage.RSOptionCon().Click();
        }
        [Then(@"User clicks on EN option and back to english 2")]
        public void AdminClicksOnEnOption()
        {
            contrHomePage.LanguageConButton().Click();
            contrHomePage.ENOptionCon().Click();
        }
    }
}
