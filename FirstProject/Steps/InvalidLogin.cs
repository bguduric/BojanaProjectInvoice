using FirstProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps
{
    class InvalidLogin : BaseSteps
    {
        string expectedErrorMessage = "Invalid username or password.";
        [Given(@"User navigates to Invoice Validator web app")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
        }
        [When(@"User enters username that is not in database and password")]
        public void UserEntersUsernameThatIsNotInDatabaseAndPassword()
        {
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");

            homePage.UsernameInputField().SendKeys("aaaaaa");
            homePage.PasswordInputField().SendKeys("aaaaaaa");
        }
        [When(@"User clicks on signin button 123")]
        public void UserClicksOnSignInButton123()
        {
            Precondition homePage2 = new Precondition(Driver);
            homePage2.SignInButton().Click();
        }
        [Then(@"Error login message is showed")]
        public void ErrorLoginMessageIsShowed()
        {
            Precondition homePage2 = new Precondition(Driver);
            Assert.AreEqual(expectedErrorMessage, homePage2.IsErrorMessageDisplayed().Text);

        }
    }
}
