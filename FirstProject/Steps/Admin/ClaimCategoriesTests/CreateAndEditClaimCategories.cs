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

//User logs in as admin and navigate on create claim category

        [Given(@"User logs in as admin and navigates on Claim category page 3")]
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
        [When(@"User enters valid values in create claim category form 2")]
        public void UserEntersValidValiesInCreateClaimCategoty()
        {
            ClaimCategories adminClaimCategoryCreate = new ClaimCategories(Driver);
            adminClaimCategoryCreate.ClaimCategoryCreateName().Clear();
            adminClaimCategoryCreate.ClaimCategoryCreateName().SendKeys(valid_name);
            adminClaimCategoryCreate.ClaimCategoryPositive().Click();
            adminClaimCategoryCreate.ClaimCategoryCreateButton().Click();
        }
        [Then(@"User is redirected on claim categories list 3")]
        public void UserIsRedirectedOnClaimCatListWithNewClaim()
        {
            ClaimCategories adminClaimCategoryList2 = new ClaimCategories(Driver);
            Assert.AreEqual(valid_name, adminClaimCategoryList2.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name + "')]")).Text);
        }
//Admin deltes claim category name and clicks on save button. Error message should be showed.

        [When(@"User navigates on edit link and deletes Claim category name and clicks on save button")]
        public void UserDelatesClaimCategoryNameAndClicksOnSaveButton()
        {
            ClaimCategories InvalidClaimCategoriesEdit = new ClaimCategories(Driver);
            InvalidClaimCategoriesEdit.TableClaimCategories().FindElement(By.XPath("//tr[contains(string(), '" + valid_name + "')]//td[3]//a[1]")).Click();
            InvalidClaimCategoriesEdit.ClaimCategoryCreateName().Clear();
            InvalidClaimCategoriesEdit.ClaimCategoryEditSaveButton().Click();
        }
        [Then(@"Error message is showed 8")]
        public void ErrorMessageIsShowed8()
        {
            ClaimCategories InvalidClaimCategoriesEdit2 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage18, InvalidClaimCategoriesEdit2.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS22, InvalidClaimCategoriesEdit2.EmptyClaimCategory().Text);
            }
        }

//Admin enters values that are not alphanumeric in claim category name field and clicks save button. 
//Error message under name input should be showed.

        [When(@"User enters invalid values in Claim category edit name")]
        public void UserEntersInvalidValuesInClaimCategoryEditName()
        {
            ClaimCategories InvalidClaimCategoriesEdit3 = new ClaimCategories(Driver);
            InvalidClaimCategoriesEdit3.ClaimCategoryCreateName().SendKeys(invalid_claim);
            InvalidClaimCategoriesEdit3.ClaimCategoryEditSaveButton().Click();
        }
        [Then(@"Error message is showed 9")]
        public void ErrorMessageIsShowed9()
        {
            ClaimCategories InvalidClaimCategoriesEdit4 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage20, InvalidClaimCategoriesEdit4.EmptyClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS23, InvalidClaimCategoriesEdit4.EmptyClaimCategory().Text);
            }
        }

//Admin enters name that already exists and clicks save button. Error message should be showed.

        [When(@"User changes name in name that already exists in edit claim category")]
        public void UserChangesNameInNameThatAlreadyExistsInEditClaimCategory()
        {
            ClaimCategories InvalidClaimCategoriesEdit5 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                InvalidClaimCategoriesEdit5.ClaimCategoryCreateName().Clear();
                InvalidClaimCategoriesEdit5.ClaimCategoryCreateName().SendKeys("Monthly Claim");
                InvalidClaimCategoriesEdit5.ClaimCategoryEditSaveButton().Click();
            }
            else
            {
                InvalidClaimCategoriesEdit5.ClaimCategoryCreateName().Clear();
                InvalidClaimCategoriesEdit5.ClaimCategoryCreateName().SendKeys("DJBcmbi");
                InvalidClaimCategoriesEdit5.ClaimCategoryEditSaveButton().Click();
            }
        }
        [Then(@"Error message is showed 10")]
        public void ErrorMessageIsShowed10()
        {
            ClaimCategories InvalidClaimCategoriesEdit6 = new ClaimCategories(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage19, InvalidClaimCategoriesEdit6.ExistsClaimCategory().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS24, InvalidClaimCategoriesEdit6.ExistsClaimCategoryRS().Text);

            }
        }
        [When(@"Admin enters valid values and change the name od claim category")]
        public void AdminEditClaimCategory()
        {
            ClaimCategories editClaimCategoryValid = new ClaimCategories(Driver);
            editClaimCategoryValid.ClaimCategoryCreateName().Clear();
            editClaimCategoryValid.ClaimCategoryCreateName().SendKeys(valid_name2);
            editClaimCategoryValid.ClaimCategoryEditSaveButton().Click();
        }
        [Then(@"Claim category is successfully changed")]
        public void ClaimCategoryIsSuccessfullyChanged()
        {
            ClaimCategories editClaimCategoryValid2 = new ClaimCategories(Driver);
            Assert.AreEqual(valid_name2, editClaimCategoryValid2.TableClaimCategories().FindElement(By.XPath("//td[1][contains(string(), '" + valid_name2 + "')]")).Text);
        }

//Admin wants to delete changed claim. Deleted claim shouldn't be in the list.

        [When(@"Admin clicks on delete link and clicks on delete button")]
        public void AdminClicksOnDeleteLinkAndClicksOnDeleteButton()
        {
            ClaimCategories editClaimCategoryValid3 = new ClaimCategories(Driver);
            editClaimCategoryValid3.TableClaimCategories().FindElement(By.XPath("//tr[contains(string(), '" + valid_name + "')]//td[3]//a[2]")).Click();
            editClaimCategoryValid3.ClaimCategoryDeleteButton().Click();
            Assert.IsFalse(editClaimCategoryValid3.TableClaimCategories().Text.Contains(valid_name));
        }
    }
}
