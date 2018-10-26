using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages.Admin
{
    class InvoiceValidator
    {
        private IWebDriver driver;

        public InvoiceValidator(IWebDriver driver)
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
        public IWebElement InvoiceButton()
        {
            By invoiceButton = By.XPath("//a[@class='navbar-brand']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(invoiceButton));
        }
        public IWebElement AccountingPeriodSel()
        {
            By acc_period_sel = By.Id("AccountingPeriodId");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(acc_period_sel));
        }
        public int CountAccountingPeriod()
        {
            SelectElement selectAccPeriod = new SelectElement(AccountingPeriodSel());
            IList<IWebElement> elementCount = selectAccPeriod.Options;
            int count = elementCount.Count;
            return count;
        }
        public void RandomAccountingPeriod()
        {
            Random rndAccPeriod = new Random();

            SelectElement accPeriodSelect = new SelectElement(AccountingPeriodSel());
            accPeriodSelect.SelectByIndex(rndAccPeriod.Next(0, CountAccountingPeriod()));
        }
        public IWebElement CheckRequest()
        {
            By CheckButton = By.XPath("//input[@type='submit']");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CheckButton));
        }
        public bool CheckFileDownloaded()
        {
            bool exist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains("_claims_report"))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
    }
}
