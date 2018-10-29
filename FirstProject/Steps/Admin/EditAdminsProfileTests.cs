using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        private Precondition homePage = new Precondition(Driver);
        private ProfileAdmin EditProfileAdmin = new ProfileAdmin(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);


        //User logs in as admin and navigate on profile page.


        [Given(@"User logs in as Admin 14")]
        public void UserLogsInAsAdmin()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
       
        }
        [When(@"Admin is on home page 14")]
        public void AdminIsOnHomePage()
        {
            Assert.That(EditProfileAdmin.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }

//Admin deletes all values from the fields and clicks on save button.
//Error messages should be showed under inputs.

        [When(@"Admin navigates on Profile page and delete First name and Last name")]
        public void AdminNavigatesOnProfilePageAndDeleteFirstNameAndLastName()
        {
            EditProfileAdmin.ProfileButton().Click();
            EditProfileAdmin.ProfileNameInput().Clear();
            EditProfileAdmin.ProfileLastnameInput().Clear();
            EditProfileAdmin.ProfileSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/users/edit/442", Driver.Url);

        }
        [Then(@"Error messages are showed 10")]
        public void ErrorMessagesAreShowed10()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage22, EditProfileAdmin.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessage23, EditProfileAdmin.EmptyProfileLastName().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS1, EditProfileAdmin.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessageRS2, EditProfileAdmin.EmptyProfileLastName().Text);
            }
        }

//Admin enters values that are not alphanumeric in first name and last name fields.
//Error messages should be showed under inputs.

        [When(@"User enters invalid values in edit profile page")]
        public void UserEntersInvalidValuesInEditProfilePage()
        {
            EditProfileAdmin.ProfileNameInput().SendKeys(invalid_char);
            EditProfileAdmin.ProfileLastnameInput().SendKeys(invalid_char);
            EditProfileAdmin.ProfileSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/users/edit/442", Driver.Url);
        }
        [Then(@"Error messages are showed 11")]
        public void ErrorMessagesAreShowed11()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage24, EditProfileAdmin.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessage25, EditProfileAdmin.EmptyProfileLastName().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS3, EditProfileAdmin.EmptyProfileName().Text);
                Assert.AreEqual(expectedMessageRS4, EditProfileAdmin.EmptyProfileLastName().Text);
            }
        }

//Valid Values Edit Admin's profile

        [Given(@"User Logs in as admin and navigate on Profile page")]
        public void UserLogsInAsAdminAndNavOnProfilePage()
        {

            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();

        }
        //Admin changes first name and last name and clicks on save button

        [When(@"User changes name and last name")]
        public void UserChangesNameAndLastname()
        {
            EditProfileAdmin.ProfileButton().Click();
            Assert.AreEqual("http://intnstest:50080/users/edit/442", Driver.Url);
            EditProfileAdmin.ProfileNameInput().Clear();
            EditProfileAdmin.ProfileNameInput().SendKeys(name);
            EditProfileAdmin.ProfileLastnameInput().Clear();
            EditProfileAdmin.ProfileLastnameInput().SendKeys(name);
            EditProfileAdmin.ProfileSaveButton().Click();
        }
        [Then(@"User's changes are saved and he is redirected in Home page")]
        public void ChangesAreSavedAndAdminIsOnHomePage()
        {
            Assert.That(EditProfileAdmin.IsAdminPageDisplayed(), Is.True, "My account page is not displayed.");
        }

//He checks if new informations are saved. When he opens again profile page, name and last name inputs
//contain new values

        [When(@"User navigates on profile Page and clicks on back button")]
        public void UserNavigatesOnProfilePageAndClicksBack()
        {
            EditProfileAdmin.ProfileButton().Click();
            Assert.AreEqual("http://intnstest:50080/users/edit/442", Driver.Url);
            Assert.AreEqual(name, EditProfileAdmin.ProfileNameInput().GetAttribute("value"));
            Assert.AreEqual(name, EditProfileAdmin.ProfileLastnameInput().GetAttribute("value"));
            //backProfile.ProfileBackButton().Click();
        }

    }
}
