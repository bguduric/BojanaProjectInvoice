using FirstProject.Pages;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Contractor.ClaimsTests
{
    [Binding]
    class CreateAndEditClaims : BaseSteps
    {

        string message15 = "Input for account number to pay is required.";
        string message16 = "Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.";
        string message17 = "Input for amount is not valid.";

        string messageRS13 = "Unos broja tekućeg računa je obavezan.";
        string messageRS14 = "Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.";
        string messageRS15 = "Uneti iznos nije ispravan.";

        string invalid_values = GenerateRandomData.GenerateRandomSpecChar(5);
        string invalid_val = GenerateRandomData.GenerateRandomSpecChar(5);
        string acc_num_claim = GenerateRandomData.GenerateRandomNumber(3) + "-" + GenerateRandomData.GenerateRandomNumber(13) + "-" + GenerateRandomData.GenerateRandomNumber(2);
        string acc_num_claim2 = GenerateRandomData.GenerateRandomNumber(3) + "-" + GenerateRandomData.GenerateRandomNumber(13) + "-" + GenerateRandomData.GenerateRandomNumber(2);
        string number = GenerateRandomData.GenerateRandomNumber(4);
        string uniqua = GenerateRandomData.GenerateRandomNumberNoZero(1) + GenerateRandomData.GenerateRandomNumber(4);
        string monthly_claim = GenerateRandomData.GenerateRandomNumberNoZero(1) + GenerateRandomData.GenerateRandomNumber(4);
        string bicycle = GenerateRandomData.GenerateRandomNumberNoZero(1) + GenerateRandomData.GenerateRandomNumber(4);

        private Precondition homePage = new Precondition(Driver);
        private Claims ContrClaims = new Claims(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

        //User logs in as a contractor and navigate on create claim page

        [Given(@"User logs in as contractor and  deletes values from accounting number to pay input and clicks on create button")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsContractor();
            Assert.That(ContrClaims.IsCreatePageDisplayed(), Is.True, "Home page is not displayed.");
            ContrClaims.ConAccNumberToPay().Clear();
            ContrClaims.CreateClaimButtonContr().Click();
        }
        [When(@"Contractor select accounting period and enter valid values")]
        public void ContractorSelectAccPeriodAndEnterValidValues()
        {
            ContrClaims.RandomContAccountingPeriod();
            ContrClaims.ClearAllFieldsClaims();
            ContrClaims.FillAllClaimsFields(acc_num_claim, monthly_claim, uniqua, bicycle);       
            ContrClaims.CreateClaimButtonContr().Click();
        }
        [Then(@"Contractor is redirected to Claim list and new claim is visible in the table 1")]
        public void ContractorIsRedirectedToClaimListAndNewClaimIsVisibleInTheTable()
        {
            Assert.AreEqual("http://intnstest:50080/Claims/ContractorClaimsIndex", Driver.Url);
            Assert.AreEqual(acc_num_claim, ContrClaims.TableClaims().FindElement(By.XPath("//td[4][contains(string(), '" + acc_num_claim + "')]")).Text);
        }

        [When(@"Contractor clicks on Edit link for new Claim")]
        public void ContractorNavigatesToClaimListAndClicksOnEditLink()
        {
            ContrClaims.TableClaims().FindElement(By.XPath("//tr[contains(string(), '" + acc_num_claim + "')]//td[6]//a[1]")).Click();

        }

//Contractor deletes all values form accounting number to pay input and clicks on save button.
//Error message showes.

        [When(@"Contractor deletes values from accounting number to pay input and clicks on save button")]
        public void ContractorDeletesValuesFromAccNumberToPay1()
        {
            ContrClaims.ConAccNumberToPay().Clear();
            ContrClaims.EditClaimSaveButton().Click();
        }
        [Then(@"Error message under Account number input is showed")]
        public void ErrorMessageUnderAccNumInputIsShowed()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message15, ContrClaims.emptyCreateClaimAccNumberToPay().Text);
            }
            else
            {
                Assert.AreEqual(messageRS13, ContrClaims.emptyCreateClaimAccNumberToPay().Text);
            }
        }

//Contractor enters invalid values in Edit page form
//Error message under input should be showed.

        [When(@"Contractor enters invalid values in Edit page form")]
        public void ContractorEntersInvalidValuesInEditPageForm()
        {
            ContrClaims.ClearAllFieldsClaims();
            ContrClaims.FillAllClaimsFields(invalid_values, "0" + number, "0" + number, "0" + number);
            ContrClaims.EditClaimSaveButton().Click();
        }
        [Then(@"Message about error under Account number input is showed")]
        public void MessageAboutErrorUnderAccNumberInputIsShowed()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message16, ContrClaims.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(message17, ContrClaims.UniqueError().Text);
                Assert.AreEqual(message17, ContrClaims.MonthlyClaimError().Text);
                Assert.AreEqual(message17, ContrClaims.BicycleError().Text);
            }
            else
            {
                Assert.AreEqual(messageRS14, ContrClaims.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(messageRS15, ContrClaims.UniqueError().Text);
                Assert.AreEqual(messageRS15, ContrClaims.MonthlyClaimError().Text);
                Assert.AreEqual(messageRS15, ContrClaims.BicycleError().Text);
            }
        }

        [When(@"Contractor enter valid values and clicks save button")]
        public void ContractorEnterValidValuesAndClicksSaveButton()
        {
            ContrClaims.ClearAllFieldsClaims();
            ContrClaims.FillAllClaimsFields(acc_num_claim2, monthly_claim, uniqua, bicycle);
            ContrClaims.EditClaimSaveButton().Click();
        }
        [Then(@"Contractor is successfully edited and visible in table")]
        public void ContractorIsSuccessfullyEditedAndVisibleInTable()
        {
            Assert.AreEqual("http://intnstest:50080/Claims/ContractorClaimsIndex", Driver.Url);
            Assert.AreEqual(acc_num_claim2, ContrClaims.TableClaims().FindElement(By.XPath("//td[4][contains(string(), '" + acc_num_claim2 + "')]")).Text);
        }

//Contractor navigates on details link and back to the list link

        [When(@"Contractor clicks on Detalis link")]
        public void ContractorClicksOnDetailsLink()
        {
            ContrClaims.TableClaims().FindElement(By.XPath("//tr[contains(string(), '" + acc_num_claim2 + "')]//td[6]//a[2]")).Click();
            Assert.That(ContrClaims.IsDetailsClaimsDisplayed(), Is.True, "Details page is not displayed.");
        }
    }
}
