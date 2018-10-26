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


        [Given(@"User logs in as admin and navigate on Accouting period create page 1")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Driver.Navigate().GoToUrl("http://intnstest:50080");

            Precondition homePage = new Precondition(Driver);
            AccountingPeriods AdminhomePage = new AccountingPeriods(Driver);

            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.UsernameInputField().SendKeys("IQService.admin2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
            AdminhomePage.AccPeriodsButton().Click();
            AdminhomePage.AccPeriodsCreateButton().Click();
            Assert.That(AdminhomePage.IsCreateAccFromListDisplayed(), Is.True, "Create accounting period is not displayed.");
        }

//Admin clear all fields and click on create button. Error messeges under required inputs should be showed.

        [When(@"Admin clears Year input and click create button")]
        public void ClearYearInputAndClickCreateButton()
        {
            AccountingPeriods CreateInvalidAccPeriod2 = new AccountingPeriods(Driver);
            CreateInvalidAccPeriod2.AccPeriodsCreateYear().Clear();
            CreateInvalidAccPeriod2.CreateAccButton().Click();
        }
        [Then(@"Error messages are showed 6")]
        public void ErrorMessagesAreShowed6()
        {
            AccountingPeriods CreateInvalidAccPeriod3 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage10, CreateInvalidAccPeriod3.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessage11, CreateInvalidAccPeriod3.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage12, CreateInvalidAccPeriod3.EmptyCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS20, CreateInvalidAccPeriod3.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessageRS15, CreateInvalidAccPeriod3.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessageRS16, CreateInvalidAccPeriod3.EmptyCreateClaimPayment().Text);

            }
        }

//Years between 1990. and 2100. are valid. If user enters year <1990. or >2100., 
//error message under year input should be showed.

        [When(@"Admin enters year that is less than 1990.")]
        public void UserEntersInvalidCYear()
        {
            AccountingPeriods CreateInvalidAccPeriod4 = new AccountingPeriods(Driver);
            CreateInvalidAccPeriod4.AccPeriodsCreateYear().SendKeys("1989");
            CreateInvalidAccPeriod4.CreateAccButton().Click();
        }
        [Then(@"Error messages are showed 7")]
        public void ErrorMessagesAreShowed7()
        {
            AccountingPeriods CreateInvalidAccPeriod5 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, CreateInvalidAccPeriod5.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, CreateInvalidAccPeriod5.EmptyCreateYear().Text);

            }

        }
        [When(@"Admin enters year that is greater than 2100.")]
        public void AdminEntersYearThatIsGreaterThan2100()
        {
            AccountingPeriods CreateInvalidAccPeriod5 = new AccountingPeriods(Driver);
            CreateInvalidAccPeriod5.AccPeriodsCreateYear().Clear();
            CreateInvalidAccPeriod5.AccPeriodsCreateYear().SendKeys("2101");
        }
        [Then(@"Error messages are showed 13")]
        public void ErrorMessagesAreShowed13()
        {
            AccountingPeriods CreateInvalidAccPeriod5 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, CreateInvalidAccPeriod5.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, CreateInvalidAccPeriod5.EmptyCreateYear().Text);

            }
        }

//If admin enters some values in claim dates fields, that are not in date format,
//error messages under inputs are showed

        [When(@"Admin enters valid year and invalid special characters in claims inputs")]
        public void UserEntersInvalidClaimDateValues()
        {
            AccountingPeriods CreateInvalidAccPeriod6 = new AccountingPeriods(Driver);
            CreateInvalidAccPeriod6.CreateClaimIssueData().Clear();
            CreateInvalidAccPeriod6.CreateClaimIssueData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            CreateInvalidAccPeriod6.CreateClaimPaymentData().Clear();
            CreateInvalidAccPeriod6.CreateClaimPaymentData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            CreateInvalidAccPeriod6.AccPeriodsCreateYear().Clear();
            CreateInvalidAccPeriod6.AccPeriodsCreateYear().SendKeys(year);
            CreateInvalidAccPeriod6.ClickOnPage().Click();
            CreateInvalidAccPeriod6.CreateAccButton().Click();
        }
        [Then(@"Error messages are showed 8")]
        public void ErrorMessagesAreShowed8()
        {
            AccountingPeriods CreateInvalidAccPeriod7 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, CreateInvalidAccPeriod7.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, CreateInvalidAccPeriod7.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, CreateInvalidAccPeriod7.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, CreateInvalidAccPeriod7.InvalidCreateClaimPaymentRS().Text);
            }
        }
        [When(@"Admin enters valid year and invalid formats in claims inputs")]
        public void AdminEntersValidYearAndInvalidFormatsInClaimsInputs()
        {
            AccountingPeriods CreateInvalidAccPeriod7 = new AccountingPeriods(Driver);
            CreateInvalidAccPeriod7.CreateClaimIssueData().Clear();
            CreateInvalidAccPeriod7.CreateClaimIssueData().SendKeys("123/123/123");
            CreateInvalidAccPeriod7.CreateClaimPaymentData().Clear();
            CreateInvalidAccPeriod7.CreateClaimPaymentData().SendKeys("123/123/123");
            CreateInvalidAccPeriod7.AccPeriodsCreateYear().Clear();
            CreateInvalidAccPeriod7.AccPeriodsCreateYear().SendKeys(year);
            CreateInvalidAccPeriod7.ClickOnPage().Click();
            CreateInvalidAccPeriod7.CreateAccButton().Click();
        }
        [Then(@"Error messages are showed 12")]
        public void ErrorMessagesAreShowed12()
        {
            AccountingPeriods CreateInvalidAccPeriod7 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, CreateInvalidAccPeriod7.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, CreateInvalidAccPeriod7.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, CreateInvalidAccPeriod7.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, CreateInvalidAccPeriod7.InvalidCreateClaimPaymentRS().Text);
            }
        }


//If user choose accounting period that already exist, error message should show

        [When(@"User select month and enters year for accounting period that already exists")]
        public void AccountingPeriodAlreadyExists()
        {
            AccountingPeriods CreateInvalidAccPeriod8 = new AccountingPeriods(Driver);
            SelectElement monthSelect = new SelectElement(CreateInvalidAccPeriod8.MonthSel());
            monthSelect.SelectByValue("12");
            //CreateInvalidAccPeriod8.MonthSel().SendKeys(month_select);
            CreateInvalidAccPeriod8.CreateClaimIssueData().Clear();
            CreateInvalidAccPeriod8.CreateClaimIssueData().SendKeys("1.2.2018");
            CreateInvalidAccPeriod8.CreateClaimPaymentData().Clear();
            CreateInvalidAccPeriod8.CreateClaimPaymentData().SendKeys("2.3.2018.");
            CreateInvalidAccPeriod8.AccPeriodsCreateYear().Clear();
            CreateInvalidAccPeriod8.AccPeriodsCreateYear().SendKeys("2100");
            CreateInvalidAccPeriod8.ClickOnPage().Click();
            CreateInvalidAccPeriod8.CreateAccButton().Click();
        }
        [Then(@"Error message is showed 2")]
        public void ErrorMessage2()
        {
            AccountingPeriods CreateInvalidAccPeriod9 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage17, CreateInvalidAccPeriod9.AlreadyExistsAccPeriod().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS21, CreateInvalidAccPeriod9.AlreadyExistsAccPeriod2RS().Text);

            }
        }

    }
}
