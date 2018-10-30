using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Contractor
{
    class Claims
    {
        private IWebDriver driver;

        public Claims(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }

        public bool IsContractorPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Create"));
        }
        public bool IsCreatePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Create"));
        }
        public IWebElement ContrClaimsButton()
        {
            By contr_claims_button = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[2]//li[1]//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_claims_button));
        }
        public IWebElement ContrClaimsListButton()
        {
            By contr_claims_list_button = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[2]//li[1]//ul//li[1]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_claims_list_button));
        }
        public IWebElement ContrClaimsCreateButton()
        {
            By contr_claims_create_button = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[2]//li[1]//ul//li[2]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contr_claims_create_button));
        }
        //Create elements
        public IWebElement ConAccPeriod()
        {
            By con_acc_period = By.Id("AccountingPeriodId");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(con_acc_period));
        }
        public int CountContractorsAccountingPeriod()
        {
            SelectElement selectAccPeriod = new SelectElement(ConAccPeriod());
            IList<IWebElement> elementCount = selectAccPeriod.Options;
            int count = elementCount.Count;
            return count;
        }
        public void RandomContAccountingPeriod()
        {
            Random rndAccPeriod = new Random();

            SelectElement accPeriodSelect = new SelectElement(ConAccPeriod());
            accPeriodSelect.SelectByIndex(rndAccPeriod.Next(0, CountContractorsAccountingPeriod()));
        }

        public IWebElement ConAccNumberToPay()
        {
            By con_acc_period = By.Id("AccountNumberToPay");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(con_acc_period));
        }
        public IWebElement MonthlyClaimContr()
        {
            By monthly_claim_contr = By.Id("5");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(monthly_claim_contr));
        }
        public IWebElement BicycleContr()
        {
            By bicycle_contr = By.Id("11");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bicycle_contr));
        }
        public IWebElement UniquaContr()
        {
            By uniqua_contr = By.Id("8");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(uniqua_contr));
        }
        public IWebElement TotalContr()
        {
            By total_contr = By.Id("Total");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(total_contr));
        }
        public IWebElement CreateClaimButtonContr()
        {
            By create_claim_b = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(create_claim_b));
        }
        public IWebElement BackToListClaimLink()
        {
            By back_claim_list = By.XPath("//div[@class='container body-content']//div//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(back_claim_list));
        }
        public bool IsListOfClaimsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims"));
        }
        public IWebElement CreateClaimListLink()
        {
            By create_list_link = By.XPath("//div//p//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(create_list_link));
        }

        //ERROR MESSAGES 

        public IWebElement emptyCreateClaimAccNumberToPay()
        {
            By create_claim_empty = By.Id("AccountNumberToPay-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(create_claim_empty));
        }
        public IWebElement UniqueError()
        {
            By unique_error = By.Id("8-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(unique_error));
        }
        public IWebElement MonthlyClaimError()
        {
            By monthly_claim_error = By.Id("5-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(monthly_claim_error));
        }
        public IWebElement BicycleError()
        {
            By bicycle_error = By.Id("11-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bicycle_error));
        }

        //Edit page and List

        public IWebElement EditClaimLink()
        {
            By edit_claim_link = By.XPath("//tr[2]//td[6]//a[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(edit_claim_link));
        }
        public bool IsEditClaimsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Edit/"));
        }
        public IWebElement EditClaimSaveButton()
        {
            By edit_claim_save = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(edit_claim_save));
        }
        public IWebElement EditClaimBackLink()
        {
            By edit_claim_link = By.XPath("//div//a[text()='Back to list']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(edit_claim_link));
        }
        public IWebElement DetailsClaimLink()
        {
            By details_claim_link = By.XPath("//tr[2]//td[6]//a[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(details_claim_link));
        }
        public bool IsDetailsClaimsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Details"));
        }
        //LOGOUT 
        public IWebElement LogOutButtonContractor()
        {
            By log_out_button_contr = By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']//div//div//ul[3]//li[4]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(log_out_button_contr));
        }
        public IWebElement TableClaims()
        {
            By table_claims = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(table_claims));
        }
        public IWebElement HomeForm()
        {
            By home_form = By.XPath("//div[@class='form-group']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(home_form));
        }
        public void ClearAllFieldsClaims()
        {
            ConAccNumberToPay().Clear();
            MonthlyClaimContr().Clear();
            BicycleContr().Clear();
            UniquaContr().Clear();
        }
        public void FillAllClaimsFields(string acc_num_claim, string uniqua, string monthly_claim,
         string bicycle)
        {
            ConAccNumberToPay().SendKeys(acc_num_claim);
            MonthlyClaimContr().SendKeys(uniqua);
            BicycleContr().SendKeys(monthly_claim);
            UniquaContr().SendKeys(bicycle);         
        }
    }
}
