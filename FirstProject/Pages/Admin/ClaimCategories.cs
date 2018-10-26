using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class ClaimCategories
    {
        private IWebDriver driver;

        //NAVIGATE ON CLAIM CATEGORIES LIST PAGE

        public ClaimCategories(IWebDriver driver)
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
        public IWebElement ClaimCategoriesButton()
        {
            By claimCatButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[4]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claimCatButton));
        }
        public IWebElement ClaimCategoriesListButton()
        {
            By claimCatList = By.XPath("//div[@class='navbar-collapse collapse']//ul[4]//li[1]//ul[1]//li[1]//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claimCatList));
        }
        public bool IsClaimCatListDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ClaimCategories/Create"));
        }

        //create from list link
        public IWebElement CreateLinkcClaim()
        {
            By createClaimCatLink = By.XPath("//div[@class='container body-content']//p//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createClaimCatLink));
        }
        public bool IsCreateClaimFromListDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/ClaimCategories/Create"));
        }
        public IWebElement BackToClaimLink()
        {
            By backClaimLink = By.XPath("//div[@class='container body-content']//a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(backClaimLink));
        }
        //NAVIGATE ON CLAIM CATEGORIES CREATE PAGE

        public IWebElement CreateClaimButton2()
        {
            By createClaimButton = By.XPath("//div[@class='navbar-collapse collapse']//ul[4]//li//a[@class='dropdown-toggle']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createClaimButton));
        }
        public IWebElement ClaimCategoriesCreateButton()
        {
            By claimCatCreate = By.XPath("//div[@class='navbar-collapse collapse']//ul[4]//li[1]//ul[1]//li[2]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claimCatCreate));
        }
        public IWebElement ClaimCategoryCreateName()
        {
            By claim_category_name = By.Id("Name");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_name));
        }
        public IWebElement ClaimCategoryPositive()
        {
            By claim_category_positive = By.Id("Positive");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_positive));
        }
        public IWebElement ClaimCategoryCreateButton()
        {
            By claim_category_save = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_save));
        }
        //ERROR MESSAGES
        public IWebElement EmptyClaimCategory()
        {
            By emptyClaimCategory = By.Id("Name-error");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyClaimCategory));
        }
        public IWebElement ExistsClaimCategory()
        {
            By existsClaimCategory = By.XPath("//span[text()='Claim category with specified name already exists.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existsClaimCategory));
        }
        public IWebElement ExistsClaimCategoryRS()
        {
            By existsClaimCategoryRs = By.XPath("//span[text()='Tip naknade sa unetim vrednostima već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existsClaimCategoryRs));
        }
        public IWebElement ExistsClaimCategory2RS()
        {
            By existsClaimCategory2Rs = By.XPath("//span[text()='Tip naknade sa izabranim imenom već postoji.']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(existsClaimCategory2Rs));
        }
        //EDIT LINK
        public IWebElement ClaimCategoryEditSaveButton()
        {
            By claim_category_edit_save = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_edit_save));
        }
        public IWebElement ClaimCategoryEditBackLink()
        {
            By claim_category_edit_back_link = By.XPath("//div//a[@href='/ClaimCategories']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_edit_back_link));
        }

        public IWebElement ClaimCategoryDeleteButton()
        {
            By claim_category_delete = By.XPath("//input[@value='Delete']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(claim_category_delete));
        }

        public IWebElement TableClaimCategories()
        {
            By table_claim_categories = By.XPath("//table[@class='table']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(table_claim_categories));
        }
    }
}
