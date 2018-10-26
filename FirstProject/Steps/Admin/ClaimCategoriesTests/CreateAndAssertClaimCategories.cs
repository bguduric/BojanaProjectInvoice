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

//User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);

            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();

            ClaimCategories AdminhomePage3 = new ClaimCategories(Driver);
            Assert.That(AdminhomePage3.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            AdminhomePage3.ClaimCategoriesButton().Click();
            AdminhomePage3.ClaimCategoriesCreateButton().Click();
            Assert.That(AdminhomePage3.IsClaimCatListDisplayed(), Is.True, "Claim category is not displayed.");
        }
        [When(@"Admin enters valid values in create claim category form")]
        public void UserEntersValidValiesInCreateClaimCategoty()
        {
            ClaimCategories adminClaimCategoryCreate = new ClaimCategories(Driver);
            adminClaimCategoryCreate.ClaimCategoryCreateName().Clear();
            adminClaimCategoryCreate.ClaimCategoryCreateName().SendKeys(valid_name);
            adminClaimCategoryCreate.ClaimCategoryPositive().Click();
            adminClaimCategoryCreate.ClaimCategoryCreateButton().Click();
        }
        [Then(@"Admin is redirected on claim categories list")]
        public void UserIsRedirectedOnClaimCatListWithNewClaim()
        {
            ClaimCategories adminClaimCategoryList2 = new ClaimCategories(Driver);
            Assert.AreEqual(valid_name, adminClaimCategoryList2.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name + "')]")).Text);
        }
        [When(@"Admin logs out and logs in as contractor 1")]
        public void AdminLogsOutAndLogsInAsContractor1()
        {
            Precondition homePage = new Precondition(Driver);
            homePage.LogOutAsAdmin().Click();
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Claims contrHomePage = new Claims(Driver);
            Assert.That(contrHomePage.IsCreatePageDisplayed(), Is.True, "Home page is not displayed.");
        }
        [Then(@"On home page new claim category is showed")]
        public void OnHomePageNewClaimCategoryIsShowed()
        {
            Claims contrHomePage = new Claims(Driver);
            Assert.AreEqual(valid_name + " (€)", contrHomePage.HomeForm().FindElement(By.XPath("//div[@class='form-group'][contains(string(), ' "+ valid_name + " (€)" + "')]")).Text);


        }

    }
}
