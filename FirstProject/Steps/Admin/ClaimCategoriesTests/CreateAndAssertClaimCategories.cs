using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.ClaimCategoriesTests
{
    [Binding]
    class CreateAndAssertClaimCategories : BaseSteps
    {
        string invalid_claim = GenerateRandomData.GenerateRandomSpecChar(5);
        string valid_name = GenerateRandomData.GenerateRandomAlpha(7);
        string valid_name2 = GenerateRandomData.GenerateRandomAlpha(7);

        private Precondition homePage = new Precondition(Driver);
        private ClaimCategories AdminClaimCategories = new ClaimCategories(Driver);
        private Claims contrHomePage = new Claims(Driver);

        //User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            Assert.That(AdminClaimCategories.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            AdminClaimCategories.ClaimCategoriesButton().Click();
            AdminClaimCategories.ClaimCategoriesCreateButton().Click();
            Assert.That(AdminClaimCategories.IsCreateClaimFromListDisplayed(), Is.True, "Claim category list is not displayed.");
        }
        [When(@"Admin enters valid values in create claim category form")]
        public void UserEntersValidValiesInCreateClaimCategoty()
        {
            AdminClaimCategories.ClaimCategoryCreateName().Clear();
            AdminClaimCategories.ClaimCategoryCreateName().SendKeys(valid_name);
            AdminClaimCategories.ClaimCategoryPositive().Click();
            AdminClaimCategories.ClaimCategoryCreateButton().Click();
            Assert.AreEqual("http://intnstest:50080/ClaimCategories", Driver.Url);
        }
        [Then(@"Admin is redirected on claim categories list")]
        public void UserIsRedirectedOnClaimCatListWithNewClaim()
        {
            Assert.AreEqual(valid_name, AdminClaimCategories.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name + "')]")).Text);
        }
        [When(@"Admin logs out and logs in as contractor 1")]
        public void AdminLogsOutAndLogsInAsContractor1()
        {
            homePage.LogOutAsAdmin().Click();
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Assert.That(contrHomePage.IsCreatePageDisplayed(), Is.True, "Home page of contractor is not displayed.");
        }
        [Then(@"On home page new claim category is showed")]
        public void OnHomePageNewClaimCategoryIsShowed()
        {
            Assert.AreEqual(valid_name + " (€)", contrHomePage.HomeForm().FindElement(By.XPath("//div[@class='form-group'][contains(string(), ' "+ valid_name + " (€)" + "')]")).Text);
        }

    }
}
