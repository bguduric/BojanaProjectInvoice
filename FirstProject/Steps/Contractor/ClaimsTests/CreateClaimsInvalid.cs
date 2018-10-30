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

        private Precondition homePage = new Precondition(Driver);
        private Claims ContrClaimsPage= new Claims(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);


        //User logs in as a contractor and navigate on create claim page

        [Given(@"User logs in as contractor")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsContractor();

        }
        [When(@"Contractor deletes values from accounting number to pay input and clicks on create button")]
        public void ContractorDeletesValuesAndCLicksCreateClaim()
        {
            Assert.That(ContrClaimsPage.IsCreatePageDisplayed(), Is.True, "Home page is not displayed.");
            ContrClaimsPage.ConAccNumberToPay().Clear();
            ContrClaimsPage.CreateClaimButtonContr().Click();
        }
        [Then(@"Message under input is showed 1")]
        public void MessageUnderInputIsShowed()
        {
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message13, ContrClaimsPage.emptyCreateClaimAccNumberToPay().Text);
            }
            else
            {
                Assert.AreEqual(messageRS13, ContrClaimsPage.emptyCreateClaimAccNumberToPay().Text);
            }
        }

//Contractor enter invalid values in accounting number to pay input and clicks on create button.
//Error message should be showed.

        [When(@"Contractor enters invalid values in accounting number to pay input and clicks on create button")]
        public void ContractorEntersUnvalidValuesInAccNumberToPay()
        {
            ContrClaimsPage.ClearAllFieldsClaims();
            ContrClaimsPage.FillAllClaimsFields(invalid_val, "0" + number, "0" + number, "0" + number);
            ContrClaimsPage.CreateClaimButtonContr().Click();
        }
        [Then(@"Messages under inputs are showed 2")]
        public void MessageUnderInputIsShowed2()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message14, ContrClaimsPage.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(message17, ContrClaimsPage.UniqueError().Text);
                Assert.AreEqual(message17, ContrClaimsPage.MonthlyClaimError().Text);
                Assert.AreEqual(message17, ContrClaimsPage.BicycleError().Text);
            }
            else
            {
                Assert.AreEqual(messageRS14, ContrClaimsPage.emptyCreateClaimAccNumberToPay().Text);
                Assert.AreEqual(messageRS15, ContrClaimsPage.UniqueError().Text);
                Assert.AreEqual(messageRS15, ContrClaimsPage.MonthlyClaimError().Text);
                Assert.AreEqual(messageRS15, ContrClaimsPage.BicycleError().Text);
            }
        }

    }
}
