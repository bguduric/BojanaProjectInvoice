using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class AccountingPeriods
    {
        private readonly IWebDriver driver;

//NAVIGATE TO ACCOUNTING PERIODS LIST PAGE

        public AccountingPeriods(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsAdminPageDisplayed()
        {
            By adminHomePage = By.XPath("//div[@class='form-horizontal']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(adminHomePage)).Displayed;
        }
        public IWebElement AccPeriodsButton()
        {
            By accPerButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[3]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accPerButton));
        }
        public IWebElement AccPeriodsListButton()
        {
            By accPerList = By.XPath("//div[@class='navbar-collapse collapse']//ul[3]//li[1]//ul[1]//li[1]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accPerList));
        }

        //create list link
        public IWebElement CreateLinkAcc()
        {
            By createAccPerLink = By.XPath("//div[@class='container body-content']//p//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createAccPerLink));
        }
        public bool IsCreateAccPeriodDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/AccountingPeriods/Create"));
        }
        public bool IsAccountingPeriodListPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/AccountingPeriods"));
        }
        public IWebElement BackToAcconutingLink()
        {
            By backContractorLink = By.XPath("//div[@class='container body-content']//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(backContractorLink));
        }
        //CREATE OPTION
        public IWebElement AccPeriodsButton2()
        {
            By accPerButton2 = By.XPath("//div[@class='navbar-collapse collapse']//ul[3]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accPerButton2));
        }
        public IWebElement AccPeriodsCreateButton()
        {
            By accPeriodCreate = By.XPath("//div[@class='navbar-collapse collapse']//ul[3]//li[1]//ul[1]//li[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accPeriodCreate));
        }
        public IWebElement MonthSel()
        {
            By month_sel = By.Id("Month");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(month_sel));
        }
        public int CountMonths()
        {
            SelectElement selectAccPeriod = new SelectElement(MonthSel());
            IList<IWebElement> elementCount = selectAccPeriod.Options;
            int count = elementCount.Count;
            return count;
        }
        public void RandomMonth()
        {
            Random rndAccPeriod = new Random();

            SelectElement accPeriodSelect = new SelectElement(MonthSel());
            accPeriodSelect.SelectByIndex(rndAccPeriod.Next(0, CountMonths()));
        }
        public IWebElement AccPeriodsCreateYear()
        {
            By accPeriodCreateYear = By.Id("Year");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(accPeriodCreateYear));
        }
 
        public IWebElement CreateClaimIssueData()
        {
            By create_issue_data = By.Id("ClaimDate");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(create_issue_data));
        }
        public IWebElement CreateClaimPaymentData()
        {
            By create_payment_data = By.Id("ClaimPaymentDate");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(create_payment_data));
        }
        public IWebElement ActiveCheckbox()
        {
            By checkbox_active = By.Id("Active");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(checkbox_active));
        }
        public IWebElement CreateAccButton()
        {
            By create_acc_button = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(create_acc_button));
        }
        public IWebElement ClickOnPage()
        {
            By page_click = By.XPath("//div[@class='form-horizontal']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page_click));
        }

        //Accounting period is created
        public IWebElement TableAccPeriod()
        {
            By accPeriodTable = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(accPeriodTable));
        }

        //NOT VALID MESSAGES
        public IWebElement EmptyCreateYear()
        {
            By emptyCreateYear = By.Id("Year-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyCreateYear));
        }

        public IWebElement EmptyCreateClaimIssue()
        {
            By emptyCreateClaimIssue = By.Id("ClaimDate-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyCreateClaimIssue));
        }
        public IWebElement EmptyCreateClaimPayment()
        {
            By emptyCreateClaimPayment = By.Id("ClaimPaymentDate-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyCreateClaimPayment));
        }
        public IWebElement InvalidCreateClaimIssue()
        {
            By invalidCreateClaimIssue = By.XPath("//span[text()='Claim date is not valid.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidCreateClaimIssue));
        }
        public IWebElement InvalidCreateClaimPayment()
        {
            By invalidCreateClaimPayment = By.XPath("//span[text()='Claim payment date is not valid.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidCreateClaimPayment));
        }
        public IWebElement AlreadyExistsAccPeriod()
        {
            By already_exist_acc_period = By.XPath("//span[text()='Specified accounting period already exists.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(already_exist_acc_period));
        }
        public IWebElement AlreadyExistsAccPeriod2()
        {
            By already_exist_acc_period2 = By.XPath("//span[text()='Accounting period with specified values already exists.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(already_exist_acc_period2));
        }
        //RS MESSAGES
        public IWebElement InvalidCreateClaimIssueRS()
        {
            By invalidCreateClaimIssueRs = By.XPath("//span[text()='Datum izdavanja fakture je neispravan.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidCreateClaimIssueRs));
        }
        public IWebElement InvalidCreateClaimPaymentRS()
        {
            By invalidCreateClaimPaymentRs = By.XPath("//span[text()='Datum prometa usluga je neispravan.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(invalidCreateClaimPaymentRs));
        }
        public IWebElement AlreadyExistsAccPeriod2RS()
        {
            By already_exist_acc_period2RS = By.XPath("//span[text()='Izabrani obračunski period period već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(already_exist_acc_period2RS));
        }
        public IWebElement AlreadyExistsAccPeriodRS()
        {
            By already_exist_acc_periodRS = By.XPath("//span[text()='Obračunski period sa unetim vrednostima već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(already_exist_acc_periodRS));
        }
        //EDIT BUTTONS     
        public IWebElement EditAccPeriodSave()
        {
            By edit_acc_per_save = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(edit_acc_per_save));
        }
        public IWebElement ActiveAccPer()
        {
            By active_Acc_per = By.Id("Active");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(active_Acc_per));
        }
        public bool IsEditAccPeriodVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/AccountingPeriod/Edit"));

        }
        public void ClearAccPeriodAllFields()
        {
            CreateClaimIssueData().Clear();
            CreateClaimPaymentData().Clear();
            AccPeriodsCreateYear().Clear();

        }
    }
}
