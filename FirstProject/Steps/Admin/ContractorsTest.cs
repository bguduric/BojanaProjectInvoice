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

namespace FirstProject.Steps.Admin
{
    [Binding]
    class ContractorsTest : BaseSteps
    {

//We are testing Contractors page, creating and editing new contractor

        string expectedMessage1 = "Input for username is required.";
        string expectedMessage2 = "Input for PCC Id is required.";
        string expectedMessage3 = "Input for first name is required.";
        string expectedMessage4 = "Input for last name is required.";
        string expectedMessage5 = "Input for name must be alphanumeric.";
        string expectedMessage21 = "Please enter a value greater than or equal to 0.";
        string expectedMessage6 = "Input for first name must be alphanumeric.";
        string expectedMessage7 = "Input for last name must be alphanumeric.";
        string expectedMessage8 = "Username already exsits.";
        string expectedMessage9 = "PCC Id already exsits.";

        string expectedMessageRS5 = "Unos korisničkog imena je obavezan.";
        string expectedMessageRS6 = "Unos PCC Id-a je obavezan.";
        string expectedMessageRS7 = "Unos imena je obavezan.";
        string expectedMessageRS8 = "Unos prezimena je obavezan.";
        string expectedMessageRS9 = "Unos za naziv mora biti alfanumerički.";
        string expectedMessageRS10 = "Molimo unesite vrednost vecu ili jednaku 0";
        string expectedMessageRS11 = "Korisničko ime već postoji.";
        string expectedMessageRS12 = "PCC Id već postoji.";
        string expectedMessageRS13 = "Ime mora biti alfanumeričko.";
        string expectedMessageRS14 = "Prezime mora biti alfanumeričko.";

        string invalid_char = GenerateRandomData.GenerateRandomSpecChar(5);
        string random_num = GenerateRandomData.GenerateRandomNumber(4);
        string PCCId = GenerateRandomData.GenerateRandomNumber(7);
        string FirstName = GenerateRandomData.GenerateRandomAlpha(6);
        string LastName = GenerateRandomData.GenerateRandomAlpha(6);
        string username = GenerateRandomData.GenerateRandomAlpha(4) + GenerateRandomData.GenerateRandomNumber(3);
        string PCCId2 = GenerateRandomData.GenerateRandomNumber(6);
        string FirstName2 = GenerateRandomData.GenerateRandomAlpha(6);
        string LastName2 = GenerateRandomData.GenerateRandomAlpha(6);


        private Precondition homePage = new Precondition(Driver);
        private Contractors adminContraCreate = new Contractors(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

//Navigate on Create contractor page
        [Given(@"User logs in as Admin and navigates on Contractors Create page")]
        public void UserNavigatesOnCreateContractorPageTest()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            Assert.That(homePage.IsAdminsHeaderDisplayed(), Is.True, "Admin's home page is not displayed.");
            adminContraCreate.ContractorsButton().Click();
            adminContraCreate.ContractorsCreateButton().Click();
            Assert.That(adminContraCreate.IsCreateFromListDisplayed(), Is.True, "Create page is not displayed.");
        }

//Admin doesn't enter any values and clicks create button. Messages under required inputs are showed.

        [When(@"User doesn't enter values and clicks create button")]
        public void UserDosentEnterValuesAndClicksCreateTest()
        {
            adminContraCreate.ContractorsSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/ContractorDatas/Create", Driver.Url);

        }
        [Then(@"Error messages under inputs are showed")]
        public void ErrorMessagesAreShowedTest()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage1, adminContraCreate.EmptyUsernameField1().Text);
                Assert.AreEqual(expectedMessage2, adminContraCreate.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessage3, adminContraCreate.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessage4, adminContraCreate.EmptyLastnameField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS5, adminContraCreate.EmptyUsernameField1().Text);
                Assert.AreEqual(expectedMessageRS6, adminContraCreate.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS7, adminContraCreate.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessageRS8, adminContraCreate.EmptyLastnameField1().Text);
            }
        }

//Admin enters values that are not alphanumeric and enters negative number in PCCId input. 
//Error messages under inputs should be showed.

        [When(@"User enters invalid values and clicks create button")]
        public void InvalidValuesCreateContractorTest()
        {
            adminContraCreate.CreateContractorsInputUsername().SendKeys(invalid_char);
            adminContraCreate.CreateContractorsInputPCCId().SendKeys("-" + random_num);
            adminContraCreate.CreateContractorsValidName().SendKeys(invalid_char);
            adminContraCreate.CreateContractorsValidLastName().SendKeys(invalid_char);
            adminContraCreate.ContractorsSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/ContractorDatas/Create", Driver.Url);

        }
        [Then(@"Error messages are showed 2")]
        public void ErrorMessagesAreShowd2Test()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage5, adminContraCreate.InvalidUsernameField1().Text);
                Assert.AreEqual(expectedMessage21, adminContraCreate.InvalidPCCIdField1().Text);
                Assert.AreEqual(expectedMessage6, adminContraCreate.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessage7, adminContraCreate.EmptyLastnameField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS9, adminContraCreate.InvalidUsernameField1().Text);
                Assert.AreEqual(expectedMessageRS10, adminContraCreate.InvalidPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS13, adminContraCreate.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessageRS14, adminContraCreate.EmptyLastnameField1().Text);
            }
        }

//Admin enters username and pccid that already exists. Error message under input are showed.

        [When(@"User enters username and pccid that already exist")]
        public void UserEntersUsernameAndPccidThatAlreadyExistCreateTest()
        {
            adminContraCreate.CreateContractorsInputUsername().Clear();
            adminContraCreate.CreateContractorsInputUsername().SendKeys("IQService.contractor2");
            adminContraCreate.CreateContractorsInputPCCId().Clear();
            adminContraCreate.CreateContractorsInputPCCId().SendKeys("34243");
            adminContraCreate.ContractorsSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/ContractorDatas/Create", Driver.Url);

        }
        [Then(@"Error messages are showed 3")]
        public void ErrorMessagesAreShowed3Test()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage8, adminContraCreate.ExistUsernameField1().Text);
                Assert.AreEqual(expectedMessage9, adminContraCreate.ExistPccIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS11, adminContraCreate.ExistUsernameField1RS().Text);
                Assert.AreEqual(expectedMessageRS12, adminContraCreate.ExistPccIdField1RS().Text);
            }
        }

//Admin enters valid values in create contractor form and clicks on create button. 
//New contractor should be visible in the table.

        [Given(@"User logs in as Admin and navigates on Contractors Create page 1")]
        public void UserNavigatesOnCreateContractorPageTest1()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            Assert.That(homePage.IsAdminsHeaderDisplayed(), Is.True, "Admin's home page is not displayed.");
            adminContraCreate.ContractorsButton().Click();
            adminContraCreate.ContractorsCreateButton().Click();
            Assert.That(adminContraCreate.IsCreateFromListDisplayed(), Is.True, "Create contractor page is not displayed.");
        }

        [When(@"User enters valid values in create contractors page")]
        public void UserEntersValidValuesInCreateContractorsPageTest()
        {
            adminContraCreate.CreateContractorsInputUsername().SendKeys("Tester." + username);
            adminContraCreate.CreateContractorsInputPCCId().SendKeys(PCCId);
            adminContraCreate.CreateContractorsValidName().SendKeys(FirstName);
            adminContraCreate.CreateContractorsValidLastName().SendKeys(LastName);
            adminContraCreate.ContractorsSaveButton().Click();
            Assert.AreEqual("http://intnstest:50080/ContractorDatas", Driver.Url);

        }
        [Then(@"Contractor is successfully created")]
        public void ContractorIsSuccessfullyCreatedTest()
        {
            Assert.AreEqual("Tester." + username, adminContraCreate.TableContractors().FindElement(By.XPath("//td[2][contains(string(), '" + "Tester." + username + "')]")).Text);
            Assert.AreEqual(FirstName,
             adminContraCreate.TableContractors().FindElement(By.XPath("//td[4][contains(string(), '" + FirstName + "')]")).Text);
            Assert.AreEqual(LastName,
             adminContraCreate.TableContractors().FindElement(By.XPath("//td[5][contains(string(), '" + LastName + "')]")).Text);
            Assert.AreEqual(PCCId,
            adminContraCreate.TableContractors().FindElement(By.XPath("//td[6][contains(string(), '" + PCCId + "')]")).Text);
        }

//Admin clicks on detais link in the table. Details page should be visible.

        [When(@"User clicks on Details about contractor and back to list button")]
        public void DetailsAboutContractorAndBackTest()
        {
            adminContraCreate.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[2]")).Click();
            Assert.That(adminContraCreate.IsDetailsPageDisplayed(), Is.True, "Details about new contractor are not displayed");
            adminContraCreate.ContractorsDetailsBackButton().Click();
        }

//Admin navigates on edit page and deletes all values and clicks save button. Error messages should be showed under inputs.

        [When(@"User navigates on edit page and deletes values")]
        public void EditContractorsPageDeleteTest()
        {
            adminContraCreate.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[1]")).Click();
            Assert.That(adminContraCreate.IsEditPageDisplayed(), Is.True, "Edit page for new contractor is not displayed");

            adminContraCreate.ClearAllFieldsEdit();
            adminContraCreate.EditContractorsSave().Click();
        }
        [Then(@"Error messages are showed 4")]
        public void ErrorMessagesAreShowed4Test()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage2, adminContraCreate.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessage3, adminContraCreate.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessage4, adminContraCreate.EmptyLastnameField2().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS6, adminContraCreate.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS7, adminContraCreate.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessageRS8, adminContraCreate.EmptyLastnameField2().Text);

            }
        }

//Admin enters invalid values in all fields and negativ number in PCCId field.
//Error messages should be shouwd under inputs.

        [When(@"User enters negativ pcc id and invalid first name and last name")]
        public void UserEntersInvalidPccIdAndFirstAndLastNameTest()
        {
            adminContraCreate.EditContractorsPccId().SendKeys("-" + random_num);
            adminContraCreate.EditContractorsFirstname().SendKeys(invalid_char);
            adminContraCreate.EditContractorsLastname().SendKeys(invalid_char);
            adminContraCreate.EditContractorsSave().Click();
        }
        [Then(@"Error messages are showed 5")]
        public void ErrorMessagesAreShowed5Test()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage6, adminContraCreate.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessage7, adminContraCreate.EmptyLastnameField2().Text);
                Assert.AreEqual(expectedMessage21, adminContraCreate.InvalidPCCIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS13, adminContraCreate.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessageRS14, adminContraCreate.EmptyLastnameField2().Text);
                Assert.AreEqual(expectedMessageRS10, adminContraCreate.InvalidPCCIdField1().Text);
            }
        }

//Admin enters pccid that already exists. Error message should be showed.

        [When(@"User enters pccid that already exists")]
        public void UserEnterPccIdThatAlreadyExistsEditTest()
        {
            adminContraCreate.ClearAllFieldsEdit();
            adminContraCreate.CreateContractorsInputPCCId().SendKeys("34243");
            adminContraCreate.EditContractorsFirstname().SendKeys(FirstName2);
            adminContraCreate.EditContractorsLastname().SendKeys(FirstName2);
            adminContraCreate.EditContractorsSave().Click();
        }
        [Then(@"Error message is showed")]
        public void ErrorMessageIsShowedTest()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage9, adminContraCreate.ExistPccIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS12, adminContraCreate.ExistPccIdField1RS().Text);

            }
        }

//Admin enters valid values in edit form inputs, and clicks Save button. Contractor is changed

        [When(@"Admin change values in contractors edit form and saves them")]
        public void AdminEditContractorTest()
        {
            adminContraCreate.ClearAllFieldsEdit();
            adminContraCreate.EditContractorsPccId().SendKeys(PCCId2);
            adminContraCreate.EditContractorsFirstname().SendKeys(FirstName2);
            adminContraCreate.EditContractorsLastname().SendKeys(LastName2);
            adminContraCreate.EditContractorsSave().Click();
            Assert.AreEqual("http://intnstest:50080/ContractorDatas", Driver.Url);

        }
        [Then(@"Edited Contractor is changed in list")]
        public void EditedContractorIsChangedInListTest()
        {
            Assert.AreEqual("Tester." + username,
               adminContraCreate.TableContractors().FindElement(By.XPath("//td[2][contains(string(), '" + "Tester." + username + "')]")).Text);
            Assert.AreEqual(FirstName2,
              adminContraCreate.TableContractors().FindElement(By.XPath("//td[4][contains(string(), '" + FirstName2 + "')]")).Text);
            Assert.AreEqual(LastName2,
             adminContraCreate.TableContractors().FindElement(By.XPath("//td[5][contains(string(), '" + LastName2 + "')]")).Text);
            Assert.AreEqual(PCCId2,
            adminContraCreate.TableContractors().FindElement(By.XPath("//td[6][contains(string(), '" + PCCId2 + "')]")).Text);

        }

//Admin wants to delete changed contractor. When he unchecks active checkbox and clicks on save button.
//Contractor should not be visible in the table.

        [When(@"Admin navigates again in contractors edit page and uncheck active checkbox")]
        public void AdminUncheckActivContractorTest()
        {
            adminContraCreate.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[1]")).Click();
            adminContraCreate.EditContractorsActive().Click();
            adminContraCreate.EditContractorsSave().Click();
        }
        [Then(@"Contractor is not visible in table")]
        public void ContractorIsNotVisibleTest()
        {
            Assert.IsFalse(adminContraCreate.TableContractors().Text.Contains(PCCId2));

        }

    }
}
