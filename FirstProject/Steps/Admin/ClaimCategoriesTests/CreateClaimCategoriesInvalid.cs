using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.ClaimCategoriesTests
{
    [Binding]
    class CreateClaimCategoriesInvalid : BaseSteps
    {

//Admin wants to create claim category but he enters invalid values.
//Admin is unable to create claim category.

        string expectedMessage18 = "Input for name is required.";
        string expectedMessage19 = "Claim category with specified name already exists.";
        string expectedMessage20 = "Input for name must be alphanumeric.";

        string expectedMessageRS22 = "Unos naziva je obavezan.";
        string expectedMessageRS23 = "Unos za naziv mora biti alfanumerički.";
        string expectedMessageRS24 = "Tip naknade sa izabranim imenom već postoji.";

        string invalid_claim = GenerateRandomData.GenerateRandomSpecChar(5);
        string valid_name = GenerateRandomData.GenerateRandomAlpha(7);
        string valid_name2 = GenerateRandomData.GenerateRandomAlpha(7);

//User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 1")]
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

//Admin clear name field and clicks on create button. Error message under input should show

        [When(@"User doesn't enter anything and clicks on create claim category button")]
        public void UserDoesntEnterAnythingAndClicksCreateClaimCategoryButton()
        {
            ClaimCategories InvalidClaimCategoriesCreate2 = new ClaimCategories(Driver);
            InvalidClaimCategoriesCreate2.ClaimCategoryCreateButton().Click();
        }
        [Then(@"Error message is showed 5")]
        public void ErrorMessageIsShowed5()
        {
            ClaimCategories InvalidClaimCategoriesCreate3 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage18, InvalidClaimCategoriesCreate3.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS22, InvalidClaimCategoriesCreate3.EmptyClaimCategory().Text);
            }
        }

//Admin enters values that are not alphanumeric. Error message under claim should show.

        [When(@"User enters invalid values in Claim categories name field")]
        public void UserEntersInvalidValuesInClaimCategoriesNameField()
        {
            ClaimCategories InvalidClaimCategoriesCreate4 = new ClaimCategories(Driver);
            InvalidClaimCategoriesCreate4.ClaimCategoryCreateName().SendKeys(invalid_claim);
            InvalidClaimCategoriesCreate4.ClaimCategoryCreateButton().Click();
        }
        [Then(@"Error message is showed 6")]
        public void ErrorMessageIsShowed6()
        {
            ClaimCategories InvalidClaimCategoriesCreate5 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage20, InvalidClaimCategoriesCreate5.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS23, InvalidClaimCategoriesCreate5.EmptyClaimCategory().Text);
            }
        }

//Admin enters name that already exist. Error message is showed

        [When(@"User enters claim category name")]
        public void UserEntersClaimCategoryName()
        {
            ClaimCategories InvalidClaimCategoriesCreate6 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                InvalidClaimCategoriesCreate6.ClaimCategoryCreateName().Clear();
                InvalidClaimCategoriesCreate6.ClaimCategoryCreateName().SendKeys("Monthly Claim");
                InvalidClaimCategoriesCreate6.ClaimCategoryCreateButton().Click();
            }
            else
            {
                InvalidClaimCategoriesCreate6.ClaimCategoryCreateName().Clear();
                InvalidClaimCategoriesCreate6.ClaimCategoryCreateName().SendKeys("DJBcmbi");
                InvalidClaimCategoriesCreate6.ClaimCategoryEditSaveButton().Click();
                
            }
        }
        [Then(@"Error message is showed 7")]
        public void ErrorMessageIsShowed7()
        {
            ClaimCategories InvalidClaimCategoriesCreate7 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage19, InvalidClaimCategoriesCreate7.ExistsClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS24, InvalidClaimCategoriesCreate7.ExistsClaimCategory2RS().Text);
            }
        }
    }
}
