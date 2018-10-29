using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.ClaimCategoriesTests
{
    [Binding]
    class CreateAndEditClaimCategories : BaseSteps
    {

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
        private ClaimCategories AdminClaimCategory = new ClaimCategories(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

        //User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 3")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            Assert.That(AdminClaimCategory.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
            AdminClaimCategory.ClaimCategoriesButton().Click();
            AdminClaimCategory.ClaimCategoriesCreateButton().Click();
            Assert.That(AdminClaimCategory.IsCreateClaimFromListDisplayed(), Is.True, "Claim categories list is not displayed.");
        }
        [When(@"User enters valid values in create claim category form 2")]
        public void UserEntersValidValiesInCreateClaimCategoty()
        {
            AdminClaimCategory.ClaimCategoryCreateName().Clear();
            AdminClaimCategory.ClaimCategoryCreateName().SendKeys(valid_name);
            AdminClaimCategory.ClaimCategoryPositive().Click();
            AdminClaimCategory.ClaimCategoryCreateButton().Click();

        }
        [Then(@"User is redirected on claim categories list 3")]
        public void UserIsRedirectedOnClaimCatListWithNewClaim()
        {
            Assert.AreEqual("http://intnstest:50080/ClaimCategories", Driver.Url);
            Assert.AreEqual(valid_name, AdminClaimCategory.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name + "')]")).Text);
        }
//Admin deltes claim category name and clicks on save button. Error message should be showed.

        [When(@"User navigates on edit link and deletes Claim category name and clicks on save button")]
        public void UserDelatesClaimCategoryNameAndClicksOnSaveButton()
        {
            AdminClaimCategory.TableClaimCategories().FindElement(By.XPath("//tr[contains(string(), '" + valid_name + "')]//td[3]//a[1]")).Click();
            AdminClaimCategory.ClaimCategoryCreateName().Clear();
            AdminClaimCategory.ClaimCategoryEditSaveButton().Click();
        }
        [Then(@"Error message is showed 8")]
        public void ErrorMessageIsShowed8()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage18, AdminClaimCategory.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS22, AdminClaimCategory.EmptyClaimCategory().Text);
            }
        }

//Admin enters values that are not alphanumeric in claim category name field and clicks save button. 
//Error message under name input should be showed.

        [When(@"User enters invalid values in Claim category edit name")]
        public void UserEntersInvalidValuesInClaimCategoryEditName()
        {
            AdminClaimCategory.ClaimCategoryCreateName().SendKeys(invalid_claim);
            AdminClaimCategory.ClaimCategoryEditSaveButton().Click();
        }
        [Then(@"Error message is showed 9")]
        public void ErrorMessageIsShowed9()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage20, AdminClaimCategory.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS23, AdminClaimCategory.EmptyClaimCategory().Text);
            }
        }

//Admin enters name that already exists and clicks save button. Error message should be showed.

        [When(@"User changes name in name that already exists in edit claim category")]
        public void UserChangesNameInNameThatAlreadyExistsInEditClaimCategory()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AdminClaimCategory.ClaimCategoryCreateName().Clear();
                AdminClaimCategory.ClaimCategoryCreateName().SendKeys("Monthly Claim");
                AdminClaimCategory.ClaimCategoryEditSaveButton().Click();
            }
            else
            {
                AdminClaimCategory.ClaimCategoryCreateName().Clear();
                AdminClaimCategory.ClaimCategoryCreateName().SendKeys("DJBcmbi");
                AdminClaimCategory.ClaimCategoryEditSaveButton().Click();
            }
        }
        [Then(@"Error message is showed 10")]
        public void ErrorMessageIsShowed10()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage19, AdminClaimCategory.ExistsClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS24, AdminClaimCategory.ExistsClaimCategoryRS().Text);

            }
        }
        [When(@"Admin enters valid values and change the name od claim category")]
        public void AdminEditClaimCategory()
        {
            AdminClaimCategory.ClaimCategoryCreateName().Clear();
            AdminClaimCategory.ClaimCategoryCreateName().SendKeys(valid_name2);
            AdminClaimCategory.ClaimCategoryEditSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/ClaimCategories", Driver.Url);

        }
        [Then(@"Claim category is successfully changed")]
        public void ClaimCategoryIsSuccessfullyChanged()
        {
            Assert.AreEqual(valid_name2, AdminClaimCategory.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name2 + "')]")).Text);
        }

//Admin wants to delete changed claim. Deleted claim shouldn't be in the list.

        [When(@"Admin clicks on delete link and clicks on delete button")]
        public void AdminClicksOnDeleteLinkAndClicksOnDeleteButton()
        {
            AdminClaimCategory.TableClaimCategories().FindElement(By.XPath("//tr[contains(string(), '" + valid_name + "')]//td[3]//a[2]")).Click();
            AdminClaimCategory.ClaimCategoryDeleteButton().Click();
            Assert.AreEqual("http://intnstest:50080/ClaimCategories", Driver.Url);
            Assert.IsFalse(AdminClaimCategory.TableClaimCategories().Text.Contains(valid_name));
        }
    }
}
