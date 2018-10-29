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

        private Precondition homePage = new Precondition(Driver);
        private ClaimCategories AdminhomePage = new ClaimCategories(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

        //User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 1")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            Assert.That(AdminhomePage.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            AdminhomePage.ClaimCategoriesButton().Click();
            AdminhomePage.ClaimCategoriesCreateButton().Click();
        }

//Admin clear name field and clicks on create button. Error message under input should show

        [When(@"User doesn't enter anything and clicks on create claim category button")]
        public void UserDoesntEnterAnythingAndClicksCreateClaimCategoryButton()
        {
            AdminhomePage.ClaimCategoryCreateButton().Click();
        }
        [Then(@"Error message is showed 5")]
        public void ErrorMessageIsShowed5()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage18, AdminhomePage.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS22, AdminhomePage.EmptyClaimCategory().Text);
            }
        }

//Admin enters values that are not alphanumeric. Error message under claim should show.

        [When(@"User enters invalid values in Claim categories name field")]
        public void UserEntersInvalidValuesInClaimCategoriesNameField()
        {
            AdminhomePage.ClaimCategoryCreateName().SendKeys(invalid_claim);
            AdminhomePage.ClaimCategoryCreateButton().Click();
        }
        [Then(@"Error message is showed 6")]
        public void ErrorMessageIsShowed6()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage20, AdminhomePage.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS23, AdminhomePage.EmptyClaimCategory().Text);
            }
        }

//Admin enters name that already exist. Error message is showed

        [When(@"User enters claim category name")]
        public void UserEntersClaimCategoryName()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AdminhomePage.ClaimCategoryCreateName().Clear();
                AdminhomePage.ClaimCategoryCreateName().SendKeys("Monthly Claim");
                AdminhomePage.ClaimCategoryCreateButton().Click();
            }
            else
            {
                AdminhomePage.ClaimCategoryCreateName().Clear();
                AdminhomePage.ClaimCategoryCreateName().SendKeys("DJBcmbi");
                AdminhomePage.ClaimCategoryEditSaveButton().Click();
                
            }
        }
        [Then(@"Error message is showed 7")]
        public void ErrorMessageIsShowed7()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage19, AdminhomePage.ExistsClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS24, AdminhomePage.ExistsClaimCategory2RS().Text);
            }
        }
    }
}
