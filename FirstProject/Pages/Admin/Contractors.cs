using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class Contractors
    {
        private IWebDriver driver;

        //NAVIGATE ON CONTRACTORS LIST PAGE
        public Contractors(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsAdminPageDisplayed()
        {
            By adminHomePage = By.XPath("//div[@class='form-horizontal']//h4[text()='Generate report for accounting period:']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(adminHomePage)).Displayed;
        }
        public IWebElement ContractorsButton()
        {
            By contractorButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[2]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorButton));
        }
        public IWebElement ContractorsListButton()
        {
            By contractorsList = By.XPath("//div[@class='navbar-collapse collapse']//ul[2]//li[1]//ul//li[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorsList));
        }
        public bool IsContractorsListDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas"));
        }
        //create list link

        public IWebElement CreateLink()
        {
            By createContractorLink = By.XPath("//div[@class='container body-content']//p//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createContractorLink));
        }
        public bool IsCreateFromListDisplayed()
        {
            By createFromList = By.XPath("//form[@action='/ContractorDatas/Create']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(createFromList)).Displayed;
        }
        public IWebElement BackToContractorsLink()
        {
            By backContractorLink = By.XPath("//div[@class='container body-content']//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(backContractorLink));
        }

        //NAVIGATE ON CONTRACTORS CREATE PAGE

        public IWebElement ContractorsButton2()
        {
            By contractorButton2 = By.XPath("//div[@class='navbar-collapse collapse']//ul[2]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorButton2));
        }
        public IWebElement ContractorsCreateButton()
        {
            By contractorsCreate = By.XPath("//div[@class='navbar-collapse collapse']//ul[2]//li[1]//ul//li[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorsCreate));
        }
        //error messages
        public IWebElement EmptyUsernameField1()
        {
            By emptyUsername = By.Id("Username-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyUsername));
        }
        public IWebElement EmptyPCCIdField1()
        {
            By emptyPcc1 = By.Id("PCCID-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyPcc1));
        }
        public IWebElement EmptyFirstnameField1()
        {
            By emptyFirstname1 = By.Id("Firstname-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyFirstname1));
        }
        public IWebElement EmptyFirstnameField2()
        {
            By emptyFirstname2 = By.Id("User_Name-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyFirstname2));
        }
        public IWebElement EmptyLastnameField1()
        {
            By emptyLastname1 = By.Id("Surname-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyLastname1));
        }
        public IWebElement EmptyLastnameField2()
        {
            By emptyLastname2 = By.Id("User_Surname-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyLastname2));
        }
        public IWebElement InvalidUsernameField1()
        {
            By invalidUsername1 = By.Id("Username-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidUsername1));
        }
        public IWebElement InvalidPCCIdField1()
        {
            By invalidPcc1 = By.Id("PCCID-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidPcc1));
        }
        public IWebElement ExistUsernameField1()
        {
            By existUsername1 = By.XPath("//span[text()='Username already exsits.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existUsername1));
        }
        public IWebElement ExistPccIdField1()
        {
            By existpccId1 = By.XPath("//span[text()='PCC id already exsits.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existpccId1));
        }
        public IWebElement ExistUsernameField1RS()
        {
            By existUsername1rs = By.XPath("//span[text()='Korisničko ime već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existUsername1rs));
        }
        public IWebElement ExistPccIdField1RS()
        {
            By existpccId1rs = By.XPath("//span[text()='PCC ID već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existpccId1rs));
        }

        //Create contractor page elements

        public IWebElement CreateContractorsInputUsername()
        {
            By validContractorsUsername = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(validContractorsUsername));

        }
        public IWebElement CreateContractorsInputPCCId()
        {
            By validContractorsPccid = By.Id("PCCID");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(validContractorsPccid));
        }
        public IWebElement CreateContractorsValidName()
        {
            By validContractorsName = By.Id("Firstname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(validContractorsName));
        }
        public IWebElement CreateContractorsValidLastName()
        {
            By validContractorsLastName = By.Id("Surname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(validContractorsLastName));
        }

        public IWebElement ContractorsSaveButton()
        {
            By contractorsSave = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorsSave));
        }

        //DETAILS ABOUT NEW CONTRACTOR
        public IWebElement ContractorsDetailsButton()
        {
            By contractorsDetails = By.XPath("//tr[td[contains(., 'Tester.')]]//a[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorsDetails));
        }
        public bool IsDetailsPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas/Details"));
        }

        public IWebElement ContractorsDetailsBackButton()
        {
            By contractorsDetailsBack = By.XPath("//div[@class='container body-content']//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contractorsDetailsBack));
        }
        //EDIT CONTRACTOR 
        public bool IsEditPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ContractorDatas/Edit"));
        }
        public IWebElement EditContractorsPccId()
        {
            By editContractorPccid = By.Id("PCCID");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorPccid));
        }
        public IWebElement EditContractorsFirstname()
        {
            By editContractorFirstname = By.Id("User_Name");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorFirstname));
        }
        public IWebElement EditContractorsLastname()
        {
            By editContractorLastname = By.Id("User_Surname");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorLastname));
        }
        public IWebElement EditContractorsActive()
        {
            By editContractorActive = By.Id("User_Active");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorActive));
        }
        public IWebElement EditContractorsSave()
        {
            By editContractorSave = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorSave));
        }
        public IWebElement EditContractorsBackLink()
        {
            By editContractorBack = By.XPath("//div//a[text()='Back to list']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editContractorBack));
        }

        public IWebElement TableContractors()
        {
            By table_contractors = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(table_contractors));
        }
 
        public void ClearAllFieldsEdit()
        {
            EditContractorsPccId().Clear();
            EditContractorsFirstname().Clear();
            EditContractorsLastname().Clear();
        }
    }
}
