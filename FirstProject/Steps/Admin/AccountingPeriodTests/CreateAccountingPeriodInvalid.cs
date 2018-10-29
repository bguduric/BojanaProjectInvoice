using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.AccountingPeriodTests
{
    class CreateAccountingPeriodInvalid : BaseSteps
    {
        string expectedMessage10 = "Input for year is required.";
        string expectedMessage11 = "Input for claim date is required.";
        string expectedMessage12 = "Input for claim payment date is required.";
        string expectedMessage13 = "Input for year must be between 1990 and 2100.";
        string expectedMessage15 = "Claim date is not valid.";
        string expectedMessage16 = "Claim payment date is not valid.";
        string expectedMessage17 = "Accounting period with specified values already exists.";

        string expectedMessageRS15 = "Unos datuma izdavanja fakture je obavezan.";
        string expectedMessageRS16 = "Unos datuma prometa usluga je obavezan.";
        string expectedMessageRS17 = "Datum izdavanja fakture je neispravan.";
        string expectedMessageRS18 = "Datum prometa usluga je neispravan.";
        string expectedMessageRS19 = "Unos za godinu mora biti između 1990 i 2100.";
        string expectedMessageRS20 = "Unos godine je obavezan.";
        string expectedMessageRS21 = "Izabrani obračunski period period već postoji.";
   
        string month_select = GenerateRandomData.GenerateMonths();
        string month_select2 = GenerateRandomData.GenerateMonths();
        string year = GenerateRandomData.GenerateRandomYear().ToString();
        string year2 = GenerateRandomData.GenerateRandomYear().ToString();
        string invalid_form = GenerateRandomData.GenerateRandomSpecChar(2);

        private Precondition homePage = new Precondition(Driver);
        private AccountingPeriods AdminAccountingPeriods = new AccountingPeriods(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

//TEST

        [Given(@"User logs in as admin and navigate on Accouting period create page 1")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            AdminAccountingPeriods.AccPeriodsButton().Click();
            AdminAccountingPeriods.AccPeriodsCreateButton().Click();
            Assert.That(AdminAccountingPeriods.IsCreateAccPeriodDisplayed(), Is.True, "Create accounting period is not displayed.");
        }

//Admin clear all fields and click on create button. Error messeges under required inputs should be showed.

        [When(@"Admin clears Year input and click create button")]
        public void ClearYearInputAndClickCreateButton()
        {
            AdminAccountingPeriods.AccPeriodsCreateYear().Clear();
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);

        }
        [Then(@"Error messages are showed 6")]
        public void ErrorMessagesAreShowed6()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage10, AdminAccountingPeriods.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessage11, AdminAccountingPeriods.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage12, AdminAccountingPeriods.EmptyCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS20, AdminAccountingPeriods.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessageRS15, AdminAccountingPeriods.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessageRS16, AdminAccountingPeriods.EmptyCreateClaimPayment().Text);

            }
        }

//Years between 1990. and 2100. are valid. If user enters year <1990. or >2100., 
//error message under year input should be showed.

        [When(@"Admin enters year that is less than 1990.")]
        public void UserEntersInvalidCYear()
        {
            AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys("1989");
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);

        }
        [Then(@"Error messages are showed 7")]
        public void ErrorMessagesAreShowed7()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, AdminAccountingPeriods.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, AdminAccountingPeriods.EmptyCreateYear().Text);

            }

        }
        [When(@"Admin enters year that is greater than 2100.")]
        public void AdminEntersYearThatIsGreaterThan2100()
        {
            AdminAccountingPeriods.AccPeriodsCreateYear().Clear();
            AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys("2101");
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);

        }
        [Then(@"Error messages are showed 13")]
        public void ErrorMessagesAreShowed13()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, AdminAccountingPeriods.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, AdminAccountingPeriods.EmptyCreateYear().Text);
            }
        }

//If admin enters some values in claim dates fields, that are not in date format,
//error messages under inputs are showed

        [When(@"Admin enters valid year and invalid special characters in claims inputs")]
        public void UserEntersInvalidClaimDateValues()
        {
            AdminAccountingPeriods.ClearAccPeriodAllFields();
            AdminAccountingPeriods.CreateClaimIssueData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            AdminAccountingPeriods.CreateClaimPaymentData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys(year);
            AdminAccountingPeriods.ClickOnPage().Click();
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);
        }
        [Then(@"Error messages are showed 8")]
        public void ErrorMessagesAreShowed8()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, AdminAccountingPeriods.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, AdminAccountingPeriods.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, AdminAccountingPeriods.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, AdminAccountingPeriods.InvalidCreateClaimPaymentRS().Text);
            }
        }
        [When(@"Admin enters valid year and invalid formats in claims inputs")]
        public void AdminEntersValidYearAndInvalidFormatsInClaimsInputs()
        {
            AdminAccountingPeriods.ClearAccPeriodAllFields();
            AdminAccountingPeriods.CreateClaimIssueData().SendKeys("123/123/123");
            AdminAccountingPeriods.CreateClaimPaymentData().SendKeys("123/123/123");
            AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys(year);
            AdminAccountingPeriods.ClickOnPage().Click();
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);
        }
        [Then(@"Error messages are showed 12")]
        public void ErrorMessagesAreShowed12()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, AdminAccountingPeriods.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, AdminAccountingPeriods.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, AdminAccountingPeriods.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, AdminAccountingPeriods.InvalidCreateClaimPaymentRS().Text);
            }
        }


//If user choose accounting period that already exist, error message should show

        [When(@"User select month and enters year for accounting period that already exists")]
        public void AccountingPeriodAlreadyExists()
        {
            SelectElement monthSelect = new SelectElement(AdminAccountingPeriods.MonthSel());
            monthSelect.SelectByValue("12");
            //AdminAccountingPeriods.MonthSel().SendKeys(month_select);
            AdminAccountingPeriods.ClearAccPeriodAllFields();
            AdminAccountingPeriods.CreateClaimIssueData().SendKeys("1.2.2018");
            AdminAccountingPeriods.CreateClaimPaymentData().SendKeys("2.3.2018.");
            AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys("2100");
            AdminAccountingPeriods.ClickOnPage().Click();
            AdminAccountingPeriods.CreateAccButton().Click();
            Assert.AreEqual("http://intnstest:50080/AccountingPeriods/Create", Driver.Url);
        }
        [Then(@"Error message is showed 2")]
        public void ErrorMessage2()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage17, AdminAccountingPeriods.AlreadyExistsAccPeriod().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS21, AdminAccountingPeriods.AlreadyExistsAccPeriod2RS().Text);

            }
        }

    }
}
