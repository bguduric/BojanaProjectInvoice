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
        readonly string messageRS6 = "Naziv agencije mora biti alfanumerički.";
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

//User logs in as contractor and navigate on profile page.

        [Given(@"User logs in as contractor and navigates on profile page")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            ProfileContractor contrHomePage = new ProfileContractor(Driver);
            Assert.That(contrHomePage.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
            ProfileContractor contrProfileEdit = new ProfileContractor(Driver);
            contrProfileEdit.ProfileConButton().Click();
            Assert.That(contrProfileEdit.EditContrPage(), Is.True, "Edit contractor page is not displayed.");
        }

//Contractor deletes all values and clicks on save button.
//Error messages under required inputs should be showed.

        [When(@"Contractor deletes all values from the fields")]
        public void ContractorDeletesAllValuesFromTheFileds()
        {
            ProfileContractor contrProfileInvalidEdit = new ProfileContractor(Driver);
            contrProfileInvalidEdit.ContrAddress().Clear();
            contrProfileInvalidEdit.ContrBankName().Clear();
            contrProfileInvalidEdit.ContrAccountNumber().Clear();
            contrProfileInvalidEdit.ContrAgencyName().Clear();
            contrProfileInvalidEdit.RegistryCountryNum().Clear();
            contrProfileInvalidEdit.TaxIdentNum().Clear();
            contrProfileInvalidEdit.ContrTelephone().Clear();
            contrProfileInvalidEdit.ContrProfileSaveNum().Click();
        }
        [Then(@"Error messages are showed under Inputs")]
        public void ErrorMessagesAreShowedUnderInputs()
        {
            ProfileContractor contrProfileInvalidEdit2 = new ProfileContractor(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message1, contrProfileInvalidEdit2.EmptyAddressField().Text);
                Assert.AreEqual(message2, contrProfileInvalidEdit2.EmptyBankNameField().Text);
                Assert.AreEqual(message3, contrProfileInvalidEdit2.EmptyAccNumberContrField().Text);
                Assert.AreEqual(message4, contrProfileInvalidEdit2.EmptyAgencyNameField().Text);
                Assert.AreEqual(message5, contrProfileInvalidEdit2.EmptyTelephoneField().Text);
            }
            else {
                Assert.AreEqual(messageRS1, contrProfileInvalidEdit2.EmptyAddressField().Text);
                Assert.AreEqual(messageRS2, contrProfileInvalidEdit2.EmptyBankNameField().Text);
                Assert.AreEqual(messageRS3, contrProfileInvalidEdit2.EmptyAccNumberContrField().Text);
                Assert.AreEqual(messageRS4, contrProfileInvalidEdit2.EmptyAgencyNameField().Text);
                Assert.AreEqual(messageRS5, contrProfileInvalidEdit2.EmptyTelephoneField().Text);
            }
        }

//Contractor enters invalid values in all fileds.
//Error messages under all inputs should be showed.

        [When(@"Contractor enters Invalid Values in input fields")]
        public void ContractorEntersInvalidValuesInInputFields()
        {
            ProfileContractor contrProfileInvalidEdit3 = new ProfileContractor(Driver);
            contrProfileInvalidEdit3.ContrAddress().SendKeys(special_char);
            contrProfileInvalidEdit3.ContrBankName().SendKeys(special_char);
            contrProfileInvalidEdit3.ContrAccountNumber().SendKeys(special_char);
            contrProfileInvalidEdit3.ContrAgencyName().SendKeys(special_char);
            contrProfileInvalidEdit3.RegistryCountryNum().SendKeys(special_char);
            contrProfileInvalidEdit3.TaxIdentNum().SendKeys(invalid_alph);
            contrProfileInvalidEdit3.ContrTelephone().SendKeys(special_char);
            contrProfileInvalidEdit3.ContrProfileSaveNum().Click();
        }
        [Then(@"Error messages are showed under Inputs 2")]
        public void ErrorMessagesAreShowedUnderInputs2()
        {
            ProfileContractor contrProfileInvalidEdit4 = new ProfileContractor(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(message6, contrProfileInvalidEdit4.EmptyAddressField().Text);
                Assert.AreEqual(message7, contrProfileInvalidEdit4.EmptyBankNameField().Text);
                Assert.AreEqual(message8, contrProfileInvalidEdit4.EmptyAccNumberContrField().Text);
                Assert.AreEqual(message9, contrProfileInvalidEdit4.EmptyAgencyNameField().Text);
                Assert.AreEqual(message10, contrProfileInvalidEdit4.EmptyRegistryNumber().Text);
                Assert.AreEqual(message11, contrProfileInvalidEdit4.EmptyTaxIdentification().Text);
                Assert.AreEqual(message12, contrProfileInvalidEdit4.EmptyTelephoneField().Text);
            }
            else
            {
                Assert.AreEqual(message6, contrProfileInvalidEdit4.EmptyAddressField().Text);
                Assert.AreEqual(messageRS7, contrProfileInvalidEdit4.EmptyBankNameField().Text);
                Assert.AreEqual(messageRS8, contrProfileInvalidEdit4.EmptyAccNumberContrField().Text);
                Assert.AreEqual(messageRS9, contrProfileInvalidEdit4.EmptyAgencyNameField().Text);
                Assert.AreEqual(messageRS10, contrProfileInvalidEdit4.EmptyRegistryNumber().Text);
                Assert.AreEqual(messageRS11, contrProfileInvalidEdit4.EmptyTaxIdentification().Text);
                Assert.AreEqual(messageRS12, contrProfileInvalidEdit4.EmptyTelephoneField().Text);
            }
        }

//Edit contractors profile with valid values

        [Given(@"User logs in as contractor and navigates on profile page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp2()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");
            Precondition homePage = new Precondition(Driver);
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            ProfileContractor contrHomePage = new ProfileContractor(Driver);
            Assert.That(contrHomePage.IsContractorPageDisplayed(), Is.True, "My account page is not displayed.");
            ProfileContractor contrProfileEdit = new ProfileContractor(Driver);
            contrProfileEdit.ProfileConButton().Click();
            Assert.That(contrProfileEdit.EditContrPage(), Is.True, "Edit contractor page is not displayed.");
        }

        [When(@"Contractor enters new valid values and clicks the save button")]
        public void ContractorEntersNewValidValues()
        {
            ProfileContractor contrProfileEdit2 = new ProfileContractor(Driver);
            contrProfileEdit2.ContrAddress().Clear();
            contrProfileEdit2.ContrAddress().SendKeys(new_address);
            contrProfileEdit2.ContrBankName().Clear();
            contrProfileEdit2.ContrBankName().SendKeys(new_bankname);
            contrProfileEdit2.ContrAccountNumber().Clear();
            contrProfileEdit2.ContrAccountNumber().SendKeys(new_number);
            contrProfileEdit2.ContrAgencyName().Clear();
            contrProfileEdit2.ContrAgencyName().SendKeys(new_agency_name);
            contrProfileEdit2.RegistryCountryNum().Clear();
            contrProfileEdit2.RegistryCountryNum().SendKeys(new_registry_country);
            contrProfileEdit2.TaxIdentNum().Clear();
            contrProfileEdit2.TaxIdentNum().SendKeys(new_tax_ident_num);
            contrProfileEdit2.ContrTelephone().Clear();
            contrProfileEdit2.ContrTelephone().SendKeys(new_telephone);
            contrProfileEdit2.ContrProfileSaveNum().Click();
        }
        [Then(@"Contractor is redirected on create claim page")]
        public void ContractorIsRedirectedOnCreateClaimPage()
        {
            ProfileContractor contrProfileEdit3 = new ProfileContractor(Driver);
            Assert.That(contrProfileEdit3.IsCreatePageDisplayed(), Is.True, "Edit contractor page is not displayed.");
            Claims contrClaimsCreate = new Claims(Driver);
            contrClaimsCreate.ConAccNumberToPay().Equals(new_number);
        }
        [When(@"Contractor navigate again on Profile page")]
        public void ContractorNavigateAgainOnprofilePage()
        {
            ProfileContractor contrProfileEdit4 = new ProfileContractor(Driver);
            contrProfileEdit4.ProfileConButton().Click();
        }
        [Then(@"New values are in input fields")]
        public void NewValuesAreInInputFields()
        {
            ProfileContractor contrProfileEdit5 = new ProfileContractor(Driver);
            Assert.AreEqual(new_address, contrProfileEdit5.ContrAddress().GetAttribute("value"));
            Assert.AreEqual(new_bankname, contrProfileEdit5.ContrBankName().GetAttribute("value"));
            Assert.AreEqual(new_number, contrProfileEdit5.ContrAccountNumber().GetAttribute("value"));
            Assert.AreEqual(new_agency_name, contrProfileEdit5.ContrAgencyName().GetAttribute("value"));
            Assert.AreEqual(new_registry_country, contrProfileEdit5.RegistryCountryNum().GetAttribute("value"));
            Assert.AreEqual(new_tax_ident_num, contrProfileEdit5.TaxIdentNum().GetAttribute("value"));
            Assert.AreEqual(new_telephone, contrProfileEdit5.ContrTelephone().GetAttribute("value"));

        }

    }
}
