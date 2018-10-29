using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Contractor
{
    class ProfileContractor
    {
        private IWebDriver driver;

        public ProfileContractor(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsContractorPageDisplayed()
        {
            By contractorHomePage = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//a[@class='navbar-brand']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(contractorHomePage)).Displayed;
        }
        public IWebElement ProfileConButton()
        {
            By profileConButton = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[3]//li[3]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profileConButton));
        }
        public bool EditContrPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/users/edit/"));
        }
        //Edit elements
        public IWebElement ContrAddress()
        {
            By contr_address = By.Id("ContractorData_Address");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_address));
        }
        public IWebElement ContrBankName()
        {
            By contr_bank_name = By.Id("ContractorData_BankName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_bank_name));
        }
        public IWebElement ContrAccountNumber()
        {
            By contr_acc_number = By.Id("ContractorData_AccountNumber");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_acc_number));
        }
        public IWebElement ContrAgencyName()
        {
            By contr_agency_name = By.Id("ContractorData_CompanyName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_agency_name));
        }
        public IWebElement RegistryCountryNum()
        {
            By reg_country_num = By.Id("ContractorData_RegNumberForIndustry");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(reg_country_num));
        }
        public IWebElement TaxIdentNum()
        {
            By tax_ident_num = By.Id("ContractorData_TaxIdentificationNum");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(tax_ident_num));
        }
        public IWebElement ContrTelephone()
        {
            By contr_telephone = By.Id("ContractorData_Telephone");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_telephone));
        }
        public IWebElement ContrProfileSaveNum()
        {
            By contr_profile_save = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_profile_save));
        }
        public bool IsCreatePageDisplayed()
        {
            //By is_create__page_displ = By.XPath("//div/h2[text()='Create']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Create"));
        }
        //ERROR MESSAGES
        public IWebElement EmptyAddressField()
        {
            By empty_address = By.Id("ContractorData_Address-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_address));
        }
        public IWebElement EmptyBankNameField()
        {
            By empty_bank_name = By.Id("ContractorData_BankName-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_bank_name));
        }
        public IWebElement EmptyAccNumberContrField()
        {
            By empty_Acc_Numb = By.Id("ContractorData_AccountNumber-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_Acc_Numb));
        }
        public IWebElement EmptyAgencyNameField()
        {
            By empty_agency_name = By.Id("ContractorData_CompanyName-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_agency_name));
        }
        public IWebElement EmptyTelephoneField()
        {
            By empty_telephone = By.Id("ContractorData_Telephone-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_telephone));
        }
        public IWebElement EmptyRegistryNumber()
        {
            By empty_reg_num = By.Id("ContractorData_RegNumberForIndustry-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_reg_num));
        }
        public IWebElement EmptyTaxIdentification()
        {
            By empty_tax_identu = By.Id("ContractorData_TaxIdentificationNum-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(empty_tax_identu));
        }
        public void ClearAllFieldsProfile()
        {
            ContrAddress().Clear();
            ContrBankName().Clear();
            ContrAccountNumber().Clear();
            ContrAgencyName().Clear();
            RegistryCountryNum().Clear();
            TaxIdentNum().Clear();
            ContrTelephone().Clear();

        }
    }
}
