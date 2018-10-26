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

namespace FirstProject.Steps.Admin
{
    class EditAdminsProfileTests : BaseSteps
    {

        string expectedMessage22 = "Input for first name is required.";
        string expectedMessage23 = "Input for last name is required.";
        string expectedMessage24 = "Input for first name must be alphanumeric.";
        string expectedMessage25 = "Input for last name must be alphanumeric.";

        string expectedMessageRS1 = "Unos imena je obavezan.";
        string expectedMessageRS2 = "Unos prezimena je obavezan.";
        string expectedMessageRS3 = "Ime mora biti alfanumeričko.";
        string expectedMessageRS4 = "Prezime mora biti alfanumeričko.";

        string name = GenerateRandomData.GenerateRandomAlpha(6);
        string invalid_char = GenerateRandomData.GenerateRandomSpecChar(5);

//User logs in as admin and navigate on profile page.

        [Given(@"User navigates to Invoice Validator web application 14")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
        }
        [When(@"User logs in as Admin 14")]
        public void UserLogsInAsAdmin()
        {
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [When(@"Admin is on home page 14")]
        public void AdminIsOnHomePage()
        {
            ProfileAdmin AdminhomePage3 = new ProfileAdmin(Driver);
            Assert.That(AdminhomePage3.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }

//Admin deletes all values from the fields and clicks on save button.
//Error messages should be showed under inputs.

        [When(@"Admin navigates on Profile page and delete First name and Last name")]
        public void AdminNavigatesOnProfilePageAndDeleteFirstNameAndLastName()
        {
            ProfileAdmin EditProfileInvalid = new ProfileAdmin(Driver);
            EditProfileInvalid.ProfileButton().Click();
            EditProfileInvalid.ProfileNameInput().Clear();
            EditProfileInvalid.ProfileLastnameInput().Clear();
            EditProfileInvalid.ProfileSaveButton().Click();
        }
        [Then(@"Error messages are showed 10")]
        public void ErrorMessagesAreShowed10()
        {
            ProfileAdmin EditProfileInvalid2 = new ProfileAdmin(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage22, EditProfileInvalid2.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessage23, EditProfileInvalid2.EmptyProfileLastName().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS1, EditProfileInvalid2.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessageRS2, EditProfileInvalid2.EmptyProfileLastName().Text);
            }
        }

//Admin enters values that are not alphanumeric in first name and last name fields.
//Error messages should be showed under inputs.

        [When(@"User enters invalid values in edit profile page")]
        public void UserEntersInvalidValuesInEditProfilePage()
        {
            ProfileAdmin EditProfileInvalid3 = new ProfileAdmin(Driver);
            EditProfileInvalid3.ProfileNameInput().SendKeys(invalid_char);
            EditProfileInvalid3.ProfileLastnameInput().SendKeys(invalid_char);
            EditProfileInvalid3.ProfileSaveButton().Click();
        }
        [Then(@"Error messages are showed 11")]
        public void ErrorMessagesAreShowed11()
        {
            ProfileAdmin EditProfileInvalid4 = new ProfileAdmin(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage24, EditProfileInvalid4.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessage25, EditProfileInvalid4.EmptyProfileLastName().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS3, EditProfileInvalid4.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessageRS4, EditProfileInvalid4.EmptyProfileLastName().Text);
            }
        }

//Valid Values Edit Admin's profile

        [Given(@"User Logs in as admin and navigate on Profile page")]
        public void UserLogsInAsAdminAndNavOnProfilePage()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            ProfileAdmin EditProfileInvalid = new ProfileAdmin(Driver);
            EditProfileInvalid.ProfileButton().Click();
        }
//Admin changes first name and last name and clicks on save button

        [When(@"User changes name and last name")]
        public void UserChangesNameAndLastname()
        {
            ProfileAdmin changeInputs = new ProfileAdmin(Driver);
            //changeInputs.ProfileButton().Click();
            //changeInputs.ProfileButton().Click();
            changeInputs.ProfileNameInput().Clear();
            changeInputs.ProfileNameInput().SendKeys(name);
            changeInputs.ProfileLastnameInput().Clear();
            changeInputs.ProfileLastnameInput().SendKeys(name);
            changeInputs.ProfileSaveButton().Click();
        }
        [Then(@"User's changes are saved and he is redirected in Home page")]
        public void ChangesAreSavedAndAdminIsOnHomePage()
        {
            ProfileAdmin AdminhomePage8 = new ProfileAdmin(Driver);
            Assert.That(AdminhomePage8.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }

//He checks if new informations are saved. When he opens again profile page, name and last name inputs
//contain new values

        [When(@"User navigates on profile Page and clicks on back button")]
        public void UserNavigatesOnProfilePageAndClicksBack()
        {
            ProfileAdmin assertProfile = new ProfileAdmin(Driver);
            assertProfile.ProfileButton().Click();
            Assert.AreEqual(name, assertProfile.ProfileNameInput().GetAttribute("value"));
            Assert.AreEqual(name, assertProfile.ProfileLastnameInput().GetAttribute("value"));
            //backProfile.ProfileBackButton().Click();
        }

    }
}
