using FirstProject.Pages;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Contractor
{
    [Binding]
    class EditProfileOfContractor : BaseSteps
    {
//Contractor wants to edit his profile but he enters invalid values.
//He should not be able to change profile inputs.

        string message1 = "Input for address is required.";
        string message2 = "Input for bank name is required.";
        string message3 = "Input for account number is required.";
        string message4 = "Input for agency name is required.";
        string message5 = "Input for number of telephone is required.";
        string message6 = "Address name must be alphanumeric.";
        string message7 = "Bank name must be alphanumeric.";
        string message8 = "Invalid format. Please enter a valid format: xxx-xxxxxxxxxxxxx-xx.";
        string message9 = "Agency name must be alphanumeric.";
        string message10 = "Registry number for country number format is invalid.";
        string message11 = "Tax identification number format is invalid.";
        string message12 = "Telephone number format is invalid.";

        string messageRS1 = "Unos adrese je obavezan.";
        string messageRS2 = "Unos naziva banke je obavezan.";
        string messageRS3 = "Unos broja računa je obavezan.";
        string messageRS4 = "Unos naziva agencije je obavezan.";
        string messageRS5 = "Unos broja telefona je obavezan.";
        string messageRS6 = "Naziv agencije mora biti alfanumerički.";
        string messageRS7 = "Naziv banke mora biti alfanumerički.";
        string messageRS8 = "Neispravan format. Unesite broj u formatu: xxx-xxxxxxxxxxxxx-xx.";
        string messageRS9 = "Naziv agencije mora biti alfanumerički.";
        string messageRS10 = "Format matičnog broja je nevažeći.";
        string messageRS11 = "Format poreskog identifikacionog broja je nevažeći.";
        string messageRS12 = "Broj telefona je nevažeći.";

        string special_char = GenerateRandomData.GenerateRandomSpecChar(5);
        string invalid_alph = GenerateRandomData.GenerateRandomSpecChar(7);
        string new_address = GenerateRandomData.GenerateRandomAlpha(6) + " " + GenerateRandomData.GenerateRandomAlpha(5);
        string new_bankname = GenerateRandomData.GenerateRandomAlpha(10);
        string new_number = GenerateRandomData.GenerateRandomNumber(3) + "-" + GenerateRandomData.GenerateRandomNumber(13) + "-" + GenerateRandomData.GenerateRandomNumber(2);
        string new_agency_name = GenerateRandomData.GenerateRandomAlpha(6);
        string new_registry_country = GenerateRandomData.GenerateRandomNumber(5);
        string new_tax_ident_num = GenerateRandomData.GenerateRandomNumber(5);
        string new_telephone = GenerateRandomData.GenerateRandomNumber(9);

        private Precondition homePage = new Precondition(Driver);
        private ProfileContractor contractorProfile= new ProfileContractor(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);
        private Claims contrClaimsCreate = new Claims(Driver);


        [Given(@"User logs in as contractor and navigates on profile page")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsContractor();
            Assert.That(contractorProfile.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
            contractorProfile.ProfileConButton().Click();
            Assert.That(contractorProfile.EditContrPage(), Is.True, "Edit contractor page is not displayed.");
        }

//Contractor deletes all values and clicks on save button.
//Error messages under required inputs should be showed.

        [When(@"Contractor deletes all values from the fields")]
        public void ContractorDeletesAllValuesFromTheFileds()
        {
            contractorProfile.ClearAllFieldsProfile();       
            contractorProfile.ContrProfileSaveNum().Click();
        }
        [Then(@"Error messages are showed under Inputs")]
        public void ErrorMessagesAreShowedUnderInputs()
        {
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message1, contractorProfile.EmptyAddressField().Text);
                Assert.AreEqual(message2, contractorProfile.EmptyBankNameField().Text);
                Assert.AreEqual(message3, contractorProfile.EmptyAccNumberContrField().Text);
                Assert.AreEqual(message4, contractorProfile.EmptyAgencyNameField().Text);
                Assert.AreEqual(message5, contractorProfile.EmptyTelephoneField().Text);
            }
            else {
                Assert.AreEqual(messageRS1, contractorProfile.EmptyAddressField().Text);
                Assert.AreEqual(messageRS2, contractorProfile.EmptyBankNameField().Text);
                Assert.AreEqual(messageRS3, contractorProfile.EmptyAccNumberContrField().Text);
                Assert.AreEqual(messageRS4, contractorProfile.EmptyAgencyNameField().Text);
                Assert.AreEqual(messageRS5, contractorProfile.EmptyTelephoneField().Text);
            }
        }

//Contractor enters invalid values in all fileds.
//Error messages under all inputs should be showed.

        [When(@"Contractor enters Invalid Values in input fields")]
        public void ContractorEntersInvalidValuesInInputFields()
        {
            contractorProfile.ContrAddress().SendKeys(special_char);
            contractorProfile.ContrBankName().SendKeys(special_char);
            contractorProfile.ContrAccountNumber().SendKeys(special_char);
            contractorProfile.ContrAgencyName().SendKeys(special_char);
            contractorProfile.RegistryCountryNum().SendKeys(special_char);
            contractorProfile.TaxIdentNum().SendKeys(invalid_alph);
            contractorProfile.ContrTelephone().SendKeys(special_char);
            contractorProfile.ContrProfileSaveNum().Click();
        }
        [Then(@"Error messages are showed under Inputs 2")]
        public void ErrorMessagesAreShowedUnderInputs2()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message6, contractorProfile.EmptyAddressField().Text);
                Assert.AreEqual(message7, contractorProfile.EmptyBankNameField().Text);
                Assert.AreEqual(message8, contractorProfile.EmptyAccNumberContrField().Text);
                Assert.AreEqual(message9, contractorProfile.EmptyAgencyNameField().Text);
                Assert.AreEqual(message10, contractorProfile.EmptyRegistryNumber().Text);
                Assert.AreEqual(message11, contractorProfile.EmptyTaxIdentification().Text);
                Assert.AreEqual(message12, contractorProfile.EmptyTelephoneField().Text);
            }
            else
            {
                Assert.AreEqual(message6, contractorProfile.EmptyAddressField().Text);
                Assert.AreEqual(messageRS7, contractorProfile.EmptyBankNameField().Text);
                Assert.AreEqual(messageRS8, contractorProfile.EmptyAccNumberContrField().Text);
                Assert.AreEqual(messageRS9, contractorProfile.EmptyAgencyNameField().Text);
                Assert.AreEqual(messageRS10, contractorProfile.EmptyRegistryNumber().Text);
                Assert.AreEqual(messageRS11, contractorProfile.EmptyTaxIdentification().Text);
                Assert.AreEqual(messageRS12, contractorProfile.EmptyTelephoneField().Text);
            }
        }

//Edit contractors profile with valid values

        [Given(@"User logs in as contractor and navigates on profile page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp2()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            Assert.That(contractorProfile.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
            contractorProfile.ProfileConButton().Click();
            Assert.That(contractorProfile.EditContrPage(), Is.True, "Edit contractor page is not displayed.");
        }

        [When(@"Contractor enters new valid values and clicks the save button")]
        public void ContractorEntersNewValidValues()
        {
            contractorProfile.ClearAllFieldsProfile();
            contractorProfile.ContrAddress().SendKeys(new_address);
            contractorProfile.ContrBankName().SendKeys(new_bankname);
            contractorProfile.ContrAccountNumber().SendKeys(new_number);
            contractorProfile.ContrAgencyName().SendKeys(new_agency_name);
            contractorProfile.RegistryCountryNum().SendKeys(new_registry_country);
            contractorProfile.TaxIdentNum().SendKeys(new_tax_ident_num);
            contractorProfile.ContrTelephone().SendKeys(new_telephone);
            contractorProfile.ContrProfileSaveNum().Click();
        }
        [Then(@"Contractor is redirected on create claim page")]
        public void ContractorIsRedirectedOnCreateClaimPage()
        {
            Assert.That(contractorProfile.IsCreatePageDisplayed(), Is.True, "Edit contractor page is not displayed.");
            contrClaimsCreate.ConAccNumberToPay().Equals(new_number);
        }
        [When(@"Contractor navigate again on Profile page")]
        public void ContractorNavigateAgainOnprofilePage()
        {
            contractorProfile.ProfileConButton().Click();
        }
        [Then(@"New values are in input fields")]
        public void NewValuesAreInInputFields()
        {
            Assert.AreEqual(new_address, contractorProfile.ContrAddress().GetAttribute("value"));
            Assert.AreEqual(new_bankname, contractorProfile.ContrBankName().GetAttribute("value"));
            Assert.AreEqual(new_number, contractorProfile.ContrAccountNumber().GetAttribute("value"));
            Assert.AreEqual(new_agency_name, contractorProfile.ContrAgencyName().GetAttribute("value"));
            Assert.AreEqual(new_registry_country, contractorProfile.RegistryCountryNum().GetAttribute("value"));
            Assert.AreEqual(new_tax_ident_num, contractorProfile.TaxIdentNum().GetAttribute("value"));
            Assert.AreEqual(new_telephone, contractorProfile.ContrTelephone().GetAttribute("value"));

        }

    }
}
