using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class ContractorClaims
    {
        private IWebDriver driver;

        //NAVIGATE ON CONTRACTOR CLAIMS LIST
        public ContractorClaims(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='navbar navbar-inverse navbar-fixed-top']")));
        }
        public bool IsAdminPageDisplayed()
        {
            By adminHomePage = By.XPath("//div[@class='form-horizontal']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(adminHomePage)).Displayed;
        }
        public IWebElement ContractorClaimsButton()
        {
            By contrClaimsButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[5]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contrClaimsButton));
        }
        public IWebElement ContractorClaimsListButton()
        {
            By contrClaimsList = By.XPath("//div[@class='navbar-collapse collapse']//ul[5]//li[1]//ul[1]//li[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(contrClaimsList));
        }
        public bool IsContractorClaimsListDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims"));
        }
        //Filter And Search switch button
        public IWebElement FilterSearchButton()
        {
            By filterSearchButton = By.Id("search-filter-btn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(filterSearchButton));
        }
        public bool IsSearchFormDisplayed()
        {
            By searchForm = By.Id("searchDiv");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(searchForm)).Displayed;
        }

        public bool IsFilterFormDisplayed()
        {
            By filterForm = By.XPath("//div[@class='panel panel-default filter-panel']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(filterForm)).Displayed;
        }
        //public IWebElement AccPeriodsFromDropdown()
        //{
        //    By dropdownAccFrom = By.XPath("//select[@id='SelectedAccountingPeriodFrom']");
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        //    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dropdownAccFrom));

        //}
        //SEARCH
        public IWebElement SearchCriteria()
        {
            By search_criteria = By.Id("queryFor");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(search_criteria));
        }
        public IWebElement SearchInput()
        {
            By searchInput = By.Id("searchQueryInput");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchInput));
        }


        public IWebElement SearchSubmitButton()
        {
            By searchButton = By.XPath("//tr//td[4]//button[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchButton));
        }
        public IWebElement FilterSubmitButton()
        {
            By filterButton = By.XPath("//tr//td[6]//button[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(filterButton));
        }
        public IWebElement DetailsLinkFilterOrSearch()
        {
            By details_link_searched = By.XPath("//table//tr[1]//td[7]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(details_link_searched));
        }
     
        public bool IsDetailsPageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/Claims/Details"));
        }
        //public IWebElement DetailsBackLinkFilterOrSearch()
        //{
        //    By details_back_link_searched = By.XPath("//div//div//a[@href='/Claims']");
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        //    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(details_back_link_searched));
        //}
        public IWebElement UsernameFilterInput()
        {
            By username_filter_input = By.Id("Username");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(username_filter_input));
        }
        public IWebElement FilteredClaimIsDisplayed()
        {
            By filtered_claim = By.XPath("//table[@class='table']//tr[1]//td[1]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(filtered_claim));
        }
        public IWebElement AccountingPeriodFrom()
        {
            By acc_per_from = By.Id("AccountingPeriodFrom");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(acc_per_from));
        }
        public IWebElement AccountingPeriodTo()
        {
            By acc_per_to = By.Id("AccountingPeriodTo");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(acc_per_to));
        }
        public IWebElement TotalFrom()
        {
            By total_from = By.Id("TotalFrom");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(total_from));
        }
        public IWebElement TotalTo()
        {
            By total_to = By.Id("TotalTo");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(total_to));
        }
        public IWebElement TableContractorClaims()
        {
            By table_contr_claims = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(table_contr_claims));
        }
    
    }
}
