using FirstProject.Pages;
using FirstProject.Pages.Admin;
using FirstProject.Pages.Contractor;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FirstProject.Steps.Admin.AccountingPeriodTests
{
    [Binding]
    class CreateAndEditAccountingPeriod : BaseSteps
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

        string month_select_rs = GenerateRandomData.GenerateMonthsRS();
        string month_select2_rs = GenerateRandomData.GenerateMonthsRS();

        string year = GenerateRandomData.GenerateRandomYear().ToString();
        string year2 = GenerateRandomData.GenerateRandomYear().ToString();
        string invalid_form = GenerateRandomData.GenerateRandomSpecChar(2);

        private AccountingPeriods AccountingPeriodsPage= new AccountingPeriods(Driver);
        private Precondition homePage = new Precondition(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);

        //Login as admin and navigate on create account period page

        [Given(@"User logs in as admin and navigate on Accouting period create page")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            AccountingPeriodsPage.AccPeriodsButton().Click();
            AccountingPeriodsPage.AccPeriodsCreateButton().Click();
            Assert.That(AccountingPeriodsPage.IsCreateAccPeriodDisplayed(), Is.True, "Create accounting period is not displayed.");
        }

//Admin enters valid values in create accounting period fields and clicks create button. 
//New accounting period should be successfully created and admin should be able to see it in the table.

        [When(@"Admin enters valid values in create accounting period page")]
        public void UserEntersValidValuesInCreateAccountingPeriodForm()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.MonthSel().SendKeys(month_select);
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/1/" + year);
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/28/" + year);
                AccountingPeriodsPage.AccPeriodsCreateYear().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys(year);
                //AccountingPeriodsPage.ActiveCheckbox().Click();
                AccountingPeriodsPage.CreateAccButton().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);
                Assert.AreEqual(month_select + " " + year, AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select + " " + year + "')]")).Text);
            }
            else
            {
                AccountingPeriodsPage.MonthSel().SendKeys(month_select_rs);
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys("1." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year + ".");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys("28." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year + ".");
                AccountingPeriodsPage.AccPeriodsCreateYear().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys(year);
                //AccountingPeriodsPage.ActiveCheckbox().Click();
                AccountingPeriodsPage.CreateAccButton().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);
                Assert.AreEqual(month_select_rs + " " + year, AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select_rs + " " + year + "')]")).Text);
            }
        
        }

//Admin deletes all values and clicks on save button. Messages under inputs should be showed.

        [When(@"Admin navigates on Edit link for created accounting period and deletes all values")]
        public void UserDeletesAllValuesAccPerEdit()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select + " " + year + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year, AccountingPeriodsPage.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/1/" + year, AccountingPeriodsPage.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/28/" + year, AccountingPeriodsPage.CreateClaimPaymentData().GetAttribute("value"));
            }
            else
            {
                AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select_rs + " " + year + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year, AccountingPeriodsPage.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual("1." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year + ".", AccountingPeriodsPage.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual("28." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year + ".", AccountingPeriodsPage.CreateClaimPaymentData().GetAttribute("value"));
            }
            AccountingPeriodsPage.ClearAccPeriodAllFields();
            AccountingPeriodsPage.ClickOnPage().Click();
            AccountingPeriodsPage.EditAccPeriodSave().Click();
        }
        [Then(@"Error messeges are showed 9")]
        public void ErrorMessagesAreShowed9()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage10, AccountingPeriodsPage.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessage11, AccountingPeriodsPage.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage12, AccountingPeriodsPage.EmptyCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS20, AccountingPeriodsPage.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessageRS15, AccountingPeriodsPage.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessageRS16, AccountingPeriodsPage.EmptyCreateClaimPayment().Text);
            }
        }

//Admin enters year that is <1990. and >2100. and valid calim data values.
//Error message under year input is showed.

        [When(@"Admin enters year that is less than 1990. in edit year input")]
        public void EditYearInputLessThan1990()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys(month_select + "/1/" + "1989");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys(month_select + "/1/" + "1989");
                AccountingPeriodsPage.ClickOnPage().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys("1989");
                AccountingPeriodsPage.EditAccPeriodSave().Click();
            }
            else
            {
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys("1." + month_select + ".1989.");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys("28." + month_select + ".1989.");
                AccountingPeriodsPage.ClickOnPage().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys("1989");
                AccountingPeriodsPage.EditAccPeriodSave().Click();
            }
        }
        [Then(@"Error message is showed 3")]
        public void ErrorMessageIsShowed3()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                //Assert.AreEqual(expectedMessage13, AccountingPeriodsPage.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, AccountingPeriodsPage.EmptyCreateYear().Text);
            }
        }
        [When(@"Admin enters year that is greater than 2100. in edit year input")]
        public void EditYearInputGreaterThan2100()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys(month_select + "/1/" + ".2101.");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys(month_select + "/28/" + ".2101.");
                AccountingPeriodsPage.ClickOnPage().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys("2101");
                AccountingPeriodsPage.EditAccPeriodSave().Click();
            }
            else
            {
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys("1." + month_select + ".2101.");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys("1." + month_select + ".2101.");
                AccountingPeriodsPage.ClickOnPage().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys("2101");
                AccountingPeriodsPage.EditAccPeriodSave().Click();

            }
        }
        [Then(@"Error message is showed 13")]
        public void ErrorMessageIsShowed13()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, AccountingPeriodsPage.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, AccountingPeriodsPage.EmptyCreateYear().Text);
            }
        }

//Admin enters some values in claim dates fields, that are not in date format.
//Error messages under inputs should be showed.

        [When(@"User change claim date values to invalid")]
        public void UserChangeClaimDateValuesToInvalid()
        {
            AccountingPeriodsPage.ClearAccPeriodAllFields();
            AccountingPeriodsPage.CreateClaimIssueData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            AccountingPeriodsPage.CreateClaimPaymentData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            AccountingPeriodsPage.ClickOnPage().Click();
            AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys(year);
            AccountingPeriodsPage.EditAccPeriodSave().Click();
        }
        [Then(@"Error messages showed 9")]
        public void ErrorMessagesShowed9()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, AccountingPeriodsPage.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, AccountingPeriodsPage.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, AccountingPeriodsPage.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, AccountingPeriodsPage.InvalidCreateClaimPaymentRS().Text);
            }
        }

//Admin select month and year, but accounting period for that month and year already exist.
//Error message is showed.

        [When(@"User select month and enters year for accounting period that already exists 2")]
        public void SelectMonthAndEntersYearForAccPeriodThatExists2()
        {
            SelectElement monthSelect = new SelectElement(AccountingPeriodsPage.MonthSel());
            monthSelect.SelectByValue("12");
            AccountingPeriodsPage.ClearAccPeriodAllFields();
            AccountingPeriodsPage.CreateClaimIssueData().SendKeys("1.2.2018");
            AccountingPeriodsPage.CreateClaimPaymentData().SendKeys("2.3.2018.");
            AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys("2100");
            AccountingPeriodsPage.ClickOnPage().Click();
            AccountingPeriodsPage.EditAccPeriodSave().Click();
        }
        [Then(@"Error message is showed 4")]
        public void ErrorMessageIsShowed4()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage17, AccountingPeriodsPage.AlreadyExistsAccPeriod2().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS21, AccountingPeriodsPage.AlreadyExistsAccPeriodRS().Text);
            }
        }
        [When(@"Admin change month, year and claim dates")]
        public void AdminChangeMonthYearAndClaimDates()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.MonthSel().SendKeys(month_select2);
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/1/" + year2);
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/28/" + year2);
                AccountingPeriodsPage.AccPeriodsCreateYear().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys(year2);
                //AccountingPeriodsPage.ActiveCheckbox().Click();
                AccountingPeriodsPage.EditAccPeriodSave().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);
            }
            else
            {
                AccountingPeriodsPage.MonthSel().SendKeys(month_select2_rs);
                AccountingPeriodsPage.ClearAccPeriodAllFields();
                AccountingPeriodsPage.CreateClaimIssueData().SendKeys("1." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year2 + ".");
                AccountingPeriodsPage.CreateClaimPaymentData().SendKeys("28." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year2 + ".");
                AccountingPeriodsPage.AccPeriodsCreateYear().Click();
                AccountingPeriodsPage.AccPeriodsCreateYear().SendKeys(year2);
                //AccountingPeriodsPage.ActiveCheckbox().Click();
                AccountingPeriodsPage.EditAccPeriodSave().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);
            }
        }
        [Then(@"Accounting period is changed")]
        public void AccPeriodIsChanged()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select2 + " " + year2 + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year2, AccountingPeriodsPage.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/1/" + year2, AccountingPeriodsPage.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual(AccountingPeriodsPage.MonthSel().GetAttribute("value") + "/28/" + year2, AccountingPeriodsPage.CreateClaimPaymentData().GetAttribute("value"));
            }
            else
            {
                AccountingPeriodsPage.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select2_rs + " " + year2 + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year2, AccountingPeriodsPage.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual("1." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year2 + ".", AccountingPeriodsPage.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual("28." + AccountingPeriodsPage.MonthSel().GetAttribute("value") + "." + year2 +".", AccountingPeriodsPage.CreateClaimPaymentData().GetAttribute("value"));
            }
        }
    }
}
