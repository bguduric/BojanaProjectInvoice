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
        readonly string expectedMessage2 = "Input for PCC Id is required.";
        string expectedMessage3 = "Input for first name is required.";
        readonly string expectedMessage4 = "Input for last name is required.";
        string expectedMessage5 = "Input for name must be alphanumeric.";
        string expectedMessage21 = "Please enter a value greater than or equal to 0.";
        string expectedMessage6 = "Input for first name must be alphanumeric.";
        readonly string expectedMessage7 = "Input for last name must be alphanumeric.";
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

//Navigate on Create contractor page
        [Given(@"User logs in as Admin and navigates on Contractors Create page")]
        public void UserNavigatesOnCreateContractorPageTest()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");

            Precondition homePage = new Precondition(Driver);
            Contractors adminContraCreate = new Contractors(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Assert.That(homePage.IsAdminsHeaderDisplayed(), Is.True, "Admin's home page is not displayed.");
            adminContraCreate.ContractorsButton().Click();
            adminContraCreate.ContractorsCreateButton().Click();
            Assert.That(adminContraCreate.IsCreateFromListDisplayed(), Is.True, "Create page is not displayed.");
        }

//Admin doesn't enter any values and clicks create button. Messages under required inputs are showed.

        [When(@"User doesn't enter values and clicks create button")]
        public void UserDosentEnterValuesAndClicksCreateTest()
        {
            Contractors adminContractCreate = new Contractors(Driver);
            adminContractCreate.ContractorsSaveButton().Click();
        }
        [Then(@"Error messages under inputs are showed")]
        public void ErrorMessagesAreShowedTest()
        {
            Contractors adminContractractorsError1 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage1, adminContractractorsError1.EmptyUsernameField1().Text);
                Assert.AreEqual(expectedMessage2, adminContractractorsError1.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessage3, adminContractractorsError1.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessage4, adminContractractorsError1.EmptyLastnameField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS5, adminContractractorsError1.EmptyUsernameField1().Text);
                Assert.AreEqual(expectedMessageRS6, adminContractractorsError1.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS7, adminContractractorsError1.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessageRS8, adminContractractorsError1.EmptyLastnameField1().Text);
            }
        }

//Admin enters values that are not alphanumeric and enters negative number in PCCId input. 
//Error messages under inputs should be showed.

        [When(@"User enters invalid values and clicks create button")]
        public void InvalidValuesCreateContractorTest()
        {
            Contractors adminContractractorsError2 = new Contractors(Driver);
            adminContractractorsError2.CreateContractorsInputUsername().SendKeys(invalid_char);
            adminContractractorsError2.CreateContractorsInputPCCId().SendKeys("-" + random_num);
            adminContractractorsError2.CreateContractorsValidName().SendKeys(invalid_char);
            adminContractractorsError2.CreateContractorsValidLastName().SendKeys(invalid_char);
            adminContractractorsError2.ContractorsSaveButton().Click();
        }
        [Then(@"Error messages are showed 2")]
        public void ErrorMessagesAreShowd2Test()
        {
            Contractors adminContractractorsError3 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage5, adminContractractorsError3.InvalidUsernameField1().Text);
                Assert.AreEqual(expectedMessage21, adminContractractorsError3.InvalidPCCIdField1().Text);
                Assert.AreEqual(expectedMessage6, adminContractractorsError3.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessage7, adminContractractorsError3.EmptyLastnameField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS9, adminContractractorsError3.InvalidUsernameField1().Text);
                Assert.AreEqual(expectedMessageRS10, adminContractractorsError3.InvalidPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS13, adminContractractorsError3.EmptyFirstnameField1().Text);
                Assert.AreEqual(expectedMessageRS14, adminContractractorsError3.EmptyLastnameField1().Text);
            }
        }

//Admin enters username and pccid that already exists. Error message under input are showed.

        [When(@"User enters username and pccid that already exist")]
        public void UserEntersUsernameAndPccidThatAlreadyExistCreateTest()
        {
            Contractors adminContractractorsError4 = new Contractors(Driver);
            adminContractractorsError4.CreateContractorsInputUsername().Clear();
            adminContractractorsError4.CreateContractorsInputUsername().SendKeys("IQService.contractor2");
            adminContractractorsError4.CreateContractorsInputPCCId().Clear();
            adminContractractorsError4.CreateContractorsInputPCCId().SendKeys("34243");
            adminContractractorsError4.ContractorsSaveButton().Click();
        }
        [Then(@"Error messages are showed 3")]
        public void ErrorMessagesAreShowed3Test()
        {
            Contractors adminContractractorsError5 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage8, adminContractractorsError5.ExistUsernameField1().Text);
                Assert.AreEqual(expectedMessage9, adminContractractorsError5.ExistPccIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS11, adminContractractorsError5.ExistUsernameField1RS().Text);
                Assert.AreEqual(expectedMessageRS12, adminContractractorsError5.ExistPccIdField1RS().Text);
            }
        }

//Admin enters valid values in create contractor form and clicks on create button. 
//New contractor should be visible in the table.

        [Given(@"User logs in as Admin and navigates on Contractors Create page 1")]
        public void UserNavigatesOnCreateContractorPageTest1()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");

            Precondition homePage = new Precondition(Driver);
            Contractors adminContraCreate = new Contractors(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Assert.That(homePage.IsAdminsHeaderDisplayed(), Is.True, "Admin's home page is not displayed.");
            adminContraCreate.ContractorsButton().Click();
            adminContraCreate.ContractorsCreateButton().Click();
            Assert.That(adminContraCreate.IsCreateFromListDisplayed(), Is.True, "Create page is not displayed.");

        }

        [When(@"User enters valid values in create contractors page")]
        public void UserEntersValidValuesInCreateContractorsPageTest()
        {
            Contractors ValidValuesCreate = new Contractors(Driver);
            ValidValuesCreate.CreateContractorsInputUsername().Clear();
            ValidValuesCreate.CreateContractorsInputUsername().SendKeys("Tester." + username);
            ValidValuesCreate.CreateContractorsInputPCCId().Clear();
            ValidValuesCreate.CreateContractorsInputPCCId().SendKeys(PCCId);
            ValidValuesCreate.CreateContractorsValidName().Clear();
            ValidValuesCreate.CreateContractorsValidName().SendKeys(FirstName);
            ValidValuesCreate.CreateContractorsValidLastName().Clear();
            ValidValuesCreate.CreateContractorsValidLastName().SendKeys(LastName);
            ValidValuesCreate.ContractorsSaveButton().Click();
        }
        [Then(@"Contractor is successfully created")]
        public void ContractorIsSuccessfullyCreatedTest()
        {
            Contractors createdContr = new Contractors(Driver);
            Assert.AreEqual("Tester." + username, createdContr.TableContractors().FindElement(By.XPath("//td[2][contains(string(), '" + "Tester." + username + "')]")).Text);
            Assert.AreEqual(FirstName,
             createdContr.TableContractors().FindElement(By.XPath("//td[4][contains(string(), '" + FirstName + "')]")).Text);
            Assert.AreEqual(LastName,
             createdContr.TableContractors().FindElement(By.XPath("//td[5][contains(string(), '" + LastName + "')]")).Text);
            Assert.AreEqual(PCCId,
            createdContr.TableContractors().FindElement(By.XPath("//td[6][contains(string(), '" + PCCId + "')]")).Text);
        }

//Admin clicks on detais link in the table. Details page should be visible.

        [When(@"User clicks on Details about contractor and back to list button")]
        public void DetailsAboutContractorAndBackTest()
        {      
            Contractors createdContrDetails = new Contractors(Driver);
            createdContrDetails.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[2]")).Click();
            Assert.That(createdContrDetails.IsDetailsPageDisplayed(), Is.True, "Details about new contractor are not displayed");
            createdContrDetails.ContractorsDetailsBackButton().Click();
        }

//Admin navigates on edit page and deletes all values and clicks save button. Error messages should be showed under inputs.

        [When(@"User navigates on edit page and deletes values")]
        public void EditContractorsPageDeleteTest()
        {
            Contractors adminContractractorsError6 = new Contractors(Driver);
            adminContractractorsError6.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[1]")).Click();
            Assert.That(adminContractractorsError6.IsEditPageDisplayed(), Is.True, "Edit page for new contractor is not displayed");

            adminContractractorsError6.EditContractorsPccId().Clear();
            adminContractractorsError6.EditContractorsFirstname().Clear();
            adminContractractorsError6.EditContractorsLastname().Clear();
            adminContractractorsError6.EditContractorsSave().Click();
        }
        [Then(@"Error messages are showed 4")]
        public void ErrorMessagesAreShowed4Test()
        {
            Contractors adminContractractorsError7 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage2, adminContractractorsError7.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessage3, adminContractractorsError7.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessage4, adminContractractorsError7.EmptyLastnameField2().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS6, adminContractractorsError7.EmptyPCCIdField1().Text);
                Assert.AreEqual(expectedMessageRS7, adminContractractorsError7.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessageRS8, adminContractractorsError7.EmptyLastnameField2().Text);

            }
        }

//Admin enters invalid values in all fields and negativ number in PCCId field.
//Error messages should be shouwd under inputs.

        [When(@"User enters negativ pcc id and invalid first name and last name")]
        public void UserEntersInvalidPccIdAndFirstAndLastNameTest()
        {
            Contractors adminContractractorsError8 = new Contractors(Driver);
            adminContractractorsError8.EditContractorsPccId().SendKeys("-" + random_num);
            adminContractractorsError8.EditContractorsFirstname().SendKeys(invalid_char);
            adminContractractorsError8.EditContractorsLastname().SendKeys(invalid_char);
            adminContractractorsError8.EditContractorsSave().Click();
        }
        [Then(@"Error messages are showed 5")]
        public void ErrorMessagesAreShowed5Test()
        {
            Contractors adminContractractorsError9 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage6, adminContractractorsError9.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessage7, adminContractractorsError9.EmptyLastnameField2().Text);
                Assert.AreEqual(expectedMessage21, adminContractractorsError9.InvalidPCCIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS13, adminContractractorsError9.EmptyFirstnameField2().Text);
                Assert.AreEqual(expectedMessageRS14, adminContractractorsError9.EmptyLastnameField2().Text);
                Assert.AreEqual(expectedMessageRS10, adminContractractorsError9.InvalidPCCIdField1().Text);
            }
        }

//Admin enters pccid that already exists. Error message should be showed.

        [When(@"User enters pccid that already exists")]
        public void UserEnterPccIdThatAlreadyExistsEditTest()
        {
            Contractors adminContractractorsError10 = new Contractors(Driver);
            adminContractractorsError10.CreateContractorsInputPCCId().Clear();
            adminContractractorsError10.CreateContractorsInputPCCId().SendKeys("34243");
            adminContractractorsError10.EditContractorsFirstname().Clear();
            adminContractractorsError10.EditContractorsFirstname().SendKeys(FirstName2);
            adminContractractorsError10.EditContractorsLastname().Clear();
            adminContractractorsError10.EditContractorsLastname().SendKeys(FirstName2);
            adminContractractorsError10.EditContractorsSave().Click();
        }
        [Then(@"Error message is showed")]
        public void ErrorMessageIsShowedTest()
        {
            Contractors adminContractractorsError11 = new Contractors(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage9, adminContractractorsError11.ExistPccIdField1().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS12, adminContractractorsError11.ExistPccIdField1RS().Text);

            }
        }

//Admin enters valid values in edit form inputs, and clicks Save button. Contractor is changed

        [When(@"Admin change values in contractors edit form and saves them")]
        public void AdminEditContractorTest()
        {
            Contractors EditContractorsLink2 = new Contractors(Driver);
            EditContractorsLink2.EditContractorsPccId().Clear();
            EditContractorsLink2.EditContractorsPccId().SendKeys(PCCId2);
            EditContractorsLink2.EditContractorsFirstname().Clear();
            EditContractorsLink2.EditContractorsFirstname().SendKeys(FirstName2);
            EditContractorsLink2.EditContractorsLastname().Clear();
            EditContractorsLink2.EditContractorsLastname().SendKeys(LastName2);
            EditContractorsLink2.EditContractorsSave().Click();
        }
        [Then(@"Edited Contractor is changed in list")]
        public void EditedContractorIsChangedInListTest()
        {
            Contractors EditContractorsLink3 = new Contractors(Driver);
            Assert.AreEqual("Tester." + username,
               EditContractorsLink3.TableContractors().FindElement(By.XPath("//td[2][contains(string(), '" + "Tester." + username + "')]")).Text);
            Assert.AreEqual(FirstName2,
              EditContractorsLink3.TableContractors().FindElement(By.XPath("//td[4][contains(string(), '" + FirstName2 + "')]")).Text);
            Assert.AreEqual(LastName2,
             EditContractorsLink3.TableContractors().FindElement(By.XPath("//td[5][contains(string(), '" + LastName2 + "')]")).Text);
            Assert.AreEqual(PCCId2,
            EditContractorsLink3.TableContractors().FindElement(By.XPath("//td[6][contains(string(), '" + PCCId2 + "')]")).Text);

        }

//Admin wants to delete changed contractor. When he unchecks active checkbox and clicks on save button.
//Contractor should not be visible in the table.

        [When(@"Admin navigates again in contractors edit page and uncheck active checkbox")]
        public void AdminUncheckActivContractorTest()
        {
            Contractors EditContractorsLink4 = new Contractors(Driver);
            EditContractorsLink4.TableContractors().FindElement(By.XPath("//tr[contains(string(), '" + "Tester." + username + "')]//td[7]//a[1]")).Click();
            EditContractorsLink4.EditContractorsActive().Click();
            EditContractorsLink4.EditContractorsSave().Click();
        }
        [Then(@"Contractor is not visible in table")]
        public void ContractorIsNotVisibleTest()
        {
            Contractors EditContractorsLink5 = new Contractors(Driver);
            Assert.IsFalse(EditContractorsLink5.TableContractors().Text.Contains(PCCId2));

        }

    }
}
