using FirstProject.Pages;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Contractor.ClaimsTests
{
    [Binding]
    class CreateClaimsInvalid : BaseSteps
    {
        
        string message13 = "Input for account number to pay is required.";
        string message14 = "Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.";
        string message17 = "Input for amount is not valid.";

        string messageRS13 = "Unos broja tekućeg računa je obavezan.";
        string messageRS14 = "Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.";
        string messageRS15 = "Uneti iznos nije ispravan.";
        


        string invalid_values = GenerateRandomData.GenerateRandomSpecChar(5);
        string invalid_val = GenerateRandomData.GenerateRandomSpecChar(5);
        string number = GenerateRandomData.GenerateRandomNumber(4);
       

//User logs in as a contractor and navigate on create claim page

        [Given(@"User logs in as contractor")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
       
        }
        [When(@"Contractor deletes values from accounting number to pay input and clicks on create button")]
        public void ContractorDeletesValuesAndCLicksCreateClaim()
        {
            Claims contrHomePage = new Claims(Driver);
            Assert.That(contrHomePage.IsCreatePageDisplayed(), Is.True, "Home page is not displayed.");
            contrHomePage.ConAccNumberToPay().Clear();
            contrHomePage.CreateClaimButtonContr().Click();
        }
        [Then(@"Message under input is showed 1")]
        public void MessageUnderInputIsShowed()
        {
            Claims InvalidClaimCreate1 = new Claims(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message13, InvalidClaimCreate1.emptyCreateClaimAccNumberToPay().Text);
            }
            else
            {
                Assert.AreEqual(messageRS13, InvalidClaimCreate1.emptyCreateClaimAccNumberToPay().Text);
            }
        }

//Contractor enter invalid values in accounting number to pay input and clicks on create button.
//Error message should be showed.

        [When(@"Contractor enters invalid values in accounting number to pay input and clicks on create button")]
        public void ContractorEntersUnvalidValuesInAccNumberToPay()
        {
            Claims InvalidClaimCreate2 = new Claims(Driver);
            InvalidClaimCreate2.ConAccNumberToPay().SendKeys(invalid_val);
            InvalidClaimCreate2.MonthlyClaimContr().Clear();
            InvalidClaimCreate2.MonthlyClaimContr().SendKeys("0" + number);
            InvalidClaimCreate2.BicycleContr().Clear();
            InvalidClaimCreate2.BicycleContr().SendKeys("0" + number);
            InvalidClaimCreate2.UniquaContr().Clear();
            InvalidClaimCreate2.UniquaContr().SendKeys("0" + number);
            InvalidClaimCreate2.CreateClaimButtonContr().Click();
        }
        [Then(@"Messages under inputs are showed 2")]
        public void MessageUnderInputIsShowed2()
        {
            Claims InvalidClaimCreate3 = new Claims(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message14, InvalidClaimCreate3.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(message17, InvalidClaimCreate3.UniqueError().Text);
                Assert.AreEqual(message17, InvalidClaimCreate3.MonthlyClaimError().Text);
                Assert.AreEqual(message17, InvalidClaimCreate3.BicycleError().Text);
            }
            else
            {
                Assert.AreEqual(messageRS14, InvalidClaimCreate3.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(messageRS15, InvalidClaimCreate3.UniqueError().Text);
                Assert.AreEqual(messageRS15, InvalidClaimCreate3.MonthlyClaimError().Text);
                Assert.AreEqual(messageRS15, InvalidClaimCreate3.BicycleError().Text);
            }
        }

    }
}
