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


//User logs in as a contractor and navigate on create claim page

        [Given(@"User logs in as contractor and  deletes values from accounting number to pay input and clicks on create button")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);
            Claims contrHomePage = new Claims(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Assert.That(contrHomePage.IsCreatePageDisplayed(), Is.True, "Home page is not displayed.");
            contrHomePage.ConAccNumberToPay().Clear();
            contrHomePage.CreateClaimButtonContr().Click();
        }
        [When(@"Contractor select accounting period and enter valid values")]
        public void ContractorSelectAccPeriodAndEnterValidValues()
        {
            Claims createClaim1 = new Claims(Driver);
            createClaim1.RandomContAccountingPeriod();
            createClaim1.ConAccNumberToPay().Clear();
            createClaim1.ConAccNumberToPay().SendKeys(acc_num_claim);
            createClaim1.MonthlyClaimContr().Clear();
            createClaim1.MonthlyClaimContr().SendKeys(monthly_claim);
            createClaim1.UniquaContr().Clear();
            createClaim1.UniquaContr().SendKeys(uniqua);
            createClaim1.BicycleContr().Clear();
            createClaim1.BicycleContr().SendKeys(bicycle);

            createClaim1.CreateClaimButtonContr().Click();
        }
        [Then(@"Contractor is redirected to Claim list and new claim is visible in the table 1")]
        public void ContractorIsRedirectedToClaimListAndNewClaimIsVisibleInTheTable()
        {
            Claims createClaim2 = new Claims(Driver);
            Assert.That(createClaim2.IsListOfClaimsDisplayed(), Is.True, "List with claims is not displayed.");
            Assert.AreEqual(acc_num_claim, createClaim2.TableClaims().FindElement(By.XPath("//td[4][contains(string(), '" + acc_num_claim + "')]")).Text);
        }

        [When(@"Contractor clicks on Edit link for new Claim")]
        public void ContractorNavigatesToClaimListAndClicksOnEditLink()
        {
            Claims nav_to_list = new Claims(Driver);
            nav_to_list.TableClaims().FindElement(By.XPath("//tr[contains(string(), '" + acc_num_claim + "')]//td[6]//a[1]")).Click();

        }

//Contractor deletes all values form accounting number to pay input and clicks on save button.
//Error message showes.

        [When(@"Contractor deletes values from accounting number to pay input and clicks on save button")]
        public void ContractorDeletesValuesFromAccNumberToPay1()
        {
            Claims InvalidClaimEdit = new Claims(Driver);
            InvalidClaimEdit.ConAccNumberToPay().Clear();
            InvalidClaimEdit.EditClaimSaveButton().Click();
        }
        [Then(@"Error message under Account number input is showed")]
        public void ErrorMessageUnderAccNumInputIsShowed()
        {
            Claims InvalidClaimEdit = new Claims(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message15, InvalidClaimEdit.emptyCreateClaimAccNumberToPay().Text);
            }
            else
            {
                Assert.AreEqual(messageRS13, InvalidClaimEdit.emptyCreateClaimAccNumberToPay().Text);
            }
        }

//Contractor enters invalid values in Edit page form
//Error message under input should be showed.

        [When(@"Contractor enters invalid values in Edit page form")]
        public void ContractorEntersInvalidValuesInEditPageForm()
        {
            Claims InvalidClaimEdit1 = new Claims(Driver);
            InvalidClaimEdit1.ConAccNumberToPay().SendKeys(invalid_values);
            InvalidClaimEdit1.MonthlyClaimContr().Clear();
            InvalidClaimEdit1.MonthlyClaimContr().SendKeys("0" + number);
            InvalidClaimEdit1.BicycleContr().Clear();
            InvalidClaimEdit1.BicycleContr().SendKeys("0" + number);
            InvalidClaimEdit1.UniquaContr().Clear();
            InvalidClaimEdit1.UniquaContr().SendKeys("0" + number);
            InvalidClaimEdit1.EditClaimSaveButton().Click();
        }
        [Then(@"Message about error under Account number input is showed")]
        public void MessageAboutErrorUnderAccNumberInputIsShowed()
        {
            Claims InvalidClaimEdit2 = new Claims(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message16, InvalidClaimEdit2.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(message17, InvalidClaimEdit2.UniqueError().Text);
                Assert.AreEqual(message17, InvalidClaimEdit2.MonthlyClaimError().Text);
                Assert.AreEqual(message17, InvalidClaimEdit2.BicycleError().Text);
            }
            else
            {
                Assert.AreEqual(messageRS14, InvalidClaimEdit2.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(messageRS15, InvalidClaimEdit2.UniqueError().Text);
                Assert.AreEqual(messageRS15, InvalidClaimEdit2.MonthlyClaimError().Text);
                Assert.AreEqual(messageRS15, InvalidClaimEdit2.BicycleError().Text);
            }
        }

        [When(@"Contractor enter valid values and clicks save button")]
        public void ContractorEnterValidValuesAndClicksSaveButton()
        {
            Claims claimValidEdit1 = new Claims(Driver);
            claimValidEdit1.ConAccNumberToPay().Clear();
            claimValidEdit1.ConAccNumberToPay().SendKeys(acc_num_claim2);
            claimValidEdit1.MonthlyClaimContr().Clear();
            claimValidEdit1.MonthlyClaimContr().SendKeys(monthly_claim);
            claimValidEdit1.UniquaContr().Clear();
            claimValidEdit1.UniquaContr().SendKeys(uniqua);
            claimValidEdit1.BicycleContr().Clear();
            claimValidEdit1.BicycleContr().SendKeys(bicycle);
            claimValidEdit1.EditClaimSaveButton().Click();
        }
        [Then(@"Contractor is successfully edited and visible in table")]
        public void ContractorIsSuccessfullyEditedAndVisibleInTable()
        {
            Claims claimValidEdit1 = new Claims(Driver);
            Assert.AreEqual(acc_num_claim2, claimValidEdit1.TableClaims().FindElement(By.XPath("//td[4][contains(string(), '" + acc_num_claim2 + "')]")).Text);
        }

//Contractor navigates on details link and back to the list link

        [When(@"Contractor clicks on Detalis link")]
        public void ContractorClicksOnDetailsLink()
        {
            Claims claimValidEdit1 = new Claims(Driver);
            claimValidEdit1.TableClaims().FindElement(By.XPath("//tr[contains(string(), '" + acc_num_claim2 + "')]//td[6]//a[2]")).Click();
            Assert.That(claimValidEdit1.IsDetailsClaimsDisplayed(), Is.True, "Details page is not displayed.");
        }
    }
}
