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
        readonly string expectedMessageRS19 = "Unos za godinu mora biti između 1990 i 2100.";
        string expectedMessageRS20 = "Unos godine je obavezan.";
        readonly string expectedMessageRS21 = "Izabrani obračunski period period već postoji.";

        readonly string month_select = GenerateRandomData.GenerateMonths();
        string month_select2 = GenerateRandomData.GenerateMonths();


        string month_select_rs = GenerateRandomData.GenerateMonthsRS();
        string month_select2_rs = GenerateRandomData.GenerateMonthsRS();

        string year = GenerateRandomData.GenerateRandomYear().ToString();
        string year2 = GenerateRandomData.GenerateRandomYear().ToString();
        string invalid_form = GenerateRandomData.GenerateRandomSpecChar(2);

//Login as admin and navigate on create account period page

        [Given(@"User logs in as admin and navigate on Accouting period create page")]
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

//Admin enters valid values in create accounting period fields and clicks create button. 
//New accounting period should be successfully created and admin should be able to see it in the table.

        [When(@"Admin enters valid values in create accounting period page")]
        public void UserEntersValidValuesInCreateAccountingPeriodForm()
        {
            AccountingPeriods validCreateAcc = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                validCreateAcc.MonthSel().SendKeys(month_select);
                validCreateAcc.CreateClaimIssueData().Clear();
                validCreateAcc.CreateClaimIssueData().SendKeys(validCreateAcc.MonthSel().GetAttribute("value") + "/1/" + year);
                validCreateAcc.CreateClaimPaymentData().Clear();
                validCreateAcc.CreateClaimPaymentData().SendKeys(validCreateAcc.MonthSel().GetAttribute("value") + "/28/" + year);
                validCreateAcc.AccPeriodsCreateYear().Click();
                validCreateAcc.AccPeriodsCreateYear().Clear();
                validCreateAcc.AccPeriodsCreateYear().SendKeys(year);
                //validCreateAcc.ActiveCheckbox().Click();
                validCreateAcc.CreateAccButton().Click();
                Assert.AreEqual(month_select + " " + year, validCreateAcc.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select + " " + year + "')]")).Text);
            }
            else
            {
                validCreateAcc.MonthSel().SendKeys(month_select_rs);
                validCreateAcc.CreateClaimIssueData().Clear();
                validCreateAcc.CreateClaimIssueData().SendKeys("1." + validCreateAcc.MonthSel().GetAttribute("value") + "." + year + ".");
                validCreateAcc.CreateClaimPaymentData().Clear();
                validCreateAcc.CreateClaimPaymentData().SendKeys("28." + validCreateAcc.MonthSel().GetAttribute("value") + "." + year + ".");
                validCreateAcc.AccPeriodsCreateYear().Click();
                validCreateAcc.AccPeriodsCreateYear().Clear();
                validCreateAcc.AccPeriodsCreateYear().SendKeys(year);
                //validCreateAcc.ActiveCheckbox().Click();
                validCreateAcc.CreateAccButton().Click();
                Assert.AreEqual(month_select_rs + " " + year, validCreateAcc.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select_rs + " " + year + "')]")).Text);
            }
        }

//Admin deletes all values and clicks on save button. Messages under inputs should be showed.

        [When(@"Admin navigates on Edit link for created accounting period and deletes all values")]
        public void UserDeletesAllValuesAccPerEdit()
        {
            AccountingPeriods EditInvalidAccPeriod2 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                EditInvalidAccPeriod2.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select + " " + year + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year, EditInvalidAccPeriod2.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual(EditInvalidAccPeriod2.MonthSel().GetAttribute("value") + "/1/" + year, EditInvalidAccPeriod2.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual(EditInvalidAccPeriod2.MonthSel().GetAttribute("value") + "/28/" + year, EditInvalidAccPeriod2.CreateClaimPaymentData().GetAttribute("value"));
            }
            else
            {
                EditInvalidAccPeriod2.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select_rs + " " + year + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year, EditInvalidAccPeriod2.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual("1." + EditInvalidAccPeriod2.MonthSel().GetAttribute("value") + "." + year + ".", EditInvalidAccPeriod2.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual("28." + EditInvalidAccPeriod2.MonthSel().GetAttribute("value") + "." + year + ".", EditInvalidAccPeriod2.CreateClaimPaymentData().GetAttribute("value"));
            }
            EditInvalidAccPeriod2.AccPeriodsCreateYear().Clear();
            EditInvalidAccPeriod2.CreateClaimIssueData().Clear();
            EditInvalidAccPeriod2.CreateClaimPaymentData().Clear();
            EditInvalidAccPeriod2.ClickOnPage().Click();
            EditInvalidAccPeriod2.EditAccPeriodSave().Click();
        }
        [Then(@"Error messeges are showed 9")]
        public void ErrorMessagesAreShowed9()
        {
            AccountingPeriods EditInvalidAccPeriod3 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage10, EditInvalidAccPeriod3.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessage11, EditInvalidAccPeriod3.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage12, EditInvalidAccPeriod3.EmptyCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS20, EditInvalidAccPeriod3.EmptyCreateYear().Text);
                Assert.AreEqual(expectedMessageRS15, EditInvalidAccPeriod3.EmptyCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessageRS16, EditInvalidAccPeriod3.EmptyCreateClaimPayment().Text);
            }
        }

//Admin enters year that is <1990. and >2100. and valid calim data values.
//Error message under year input is showed.

        [When(@"Admin enters year that is less than 1990. in edit year input")]
        public void EditYearInputLessThan1990()
        {
            AccountingPeriods EditInvalidAccPeriod4 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                EditInvalidAccPeriod4.CreateClaimIssueData().SendKeys(month_select + "/1/" + "1989");
                EditInvalidAccPeriod4.CreateClaimPaymentData().SendKeys(month_select + "/1/" + "1989");
                EditInvalidAccPeriod4.ClickOnPage().Click();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().SendKeys("1989");
                EditInvalidAccPeriod4.EditAccPeriodSave().Click();
            }
            else
            {
                EditInvalidAccPeriod4.CreateClaimIssueData().SendKeys("1." + month_select + ".1989.");
                EditInvalidAccPeriod4.CreateClaimPaymentData().SendKeys("28." + month_select + ".1989.");
                EditInvalidAccPeriod4.ClickOnPage().Click();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().SendKeys("1989");
                EditInvalidAccPeriod4.EditAccPeriodSave().Click();
            }
        }
        [Then(@"Error message is showed 3")]
        public void ErrorMessageIsShowed3()
        {
            AccountingPeriods EditInvalidAccPeriod5 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, EditInvalidAccPeriod5.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, EditInvalidAccPeriod5.EmptyCreateYear().Text);
            }
        }
        [When(@"Admin enters year that is greater than 2100. in edit year input")]
        public void EditYearInputGreaterThan2100()
        {
            AccountingPeriods EditInvalidAccPeriod4 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                EditInvalidAccPeriod4.CreateClaimIssueData().Clear();
                EditInvalidAccPeriod4.CreateClaimIssueData().SendKeys(month_select + "/1/" + ".2101.");
                EditInvalidAccPeriod4.CreateClaimPaymentData().Clear();
                EditInvalidAccPeriod4.CreateClaimPaymentData().SendKeys(month_select + "/28/" + ".2101.");
                EditInvalidAccPeriod4.ClickOnPage().Click();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().Clear();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().SendKeys("2101");
                EditInvalidAccPeriod4.EditAccPeriodSave().Click();
            }
            else
            {
                EditInvalidAccPeriod4.CreateClaimIssueData().Clear();
                EditInvalidAccPeriod4.CreateClaimIssueData().SendKeys("1." + month_select + ".2101.");
                EditInvalidAccPeriod4.CreateClaimPaymentData().Clear();
                EditInvalidAccPeriod4.CreateClaimPaymentData().SendKeys("1." + month_select + ".2101.");
                EditInvalidAccPeriod4.ClickOnPage().Click();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().Clear();
                EditInvalidAccPeriod4.AccPeriodsCreateYear().SendKeys("2101");
                EditInvalidAccPeriod4.EditAccPeriodSave().Click();

            }
        }
        [Then(@"Error message is showed 13")]
        public void ErrorMessageIsShowed13()
        {
            AccountingPeriods EditInvalidAccPeriod5 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage13, EditInvalidAccPeriod5.EmptyCreateYear().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS19, EditInvalidAccPeriod5.EmptyCreateYear().Text);
            }
        }

//Admin enters some values in claim dates fields, that are not in date format.
//Error messages under inputs should be showed.

        [When(@"User change claim date values to invalid")]
        public void UserChangeClaimDateValuesToInvalid()
        {
            AccountingPeriods EditInvalidAccPeriod5 = new AccountingPeriods(Driver);
            EditInvalidAccPeriod5.CreateClaimIssueData().Clear();
            EditInvalidAccPeriod5.CreateClaimIssueData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            EditInvalidAccPeriod5.CreateClaimPaymentData().Clear();
            EditInvalidAccPeriod5.CreateClaimPaymentData().SendKeys(invalid_form + '.' + invalid_form + '.' + invalid_form + invalid_form);
            EditInvalidAccPeriod5.ClickOnPage().Click();
            EditInvalidAccPeriod5.AccPeriodsCreateYear().Clear();
            EditInvalidAccPeriod5.AccPeriodsCreateYear().SendKeys(year);
            EditInvalidAccPeriod5.EditAccPeriodSave().Click();
        }
        [Then(@"Error messages showed 9")]
        public void ErrorMessagesShowed9()
        {
            AccountingPeriods EditInvalidAccPeriod6 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage15, EditInvalidAccPeriod6.InvalidCreateClaimIssue().Text);
                Assert.AreEqual(expectedMessage16, EditInvalidAccPeriod6.InvalidCreateClaimPayment().Text);
            }
            else
            {
                Assert.AreEqual(expectedMessageRS17, EditInvalidAccPeriod6.InvalidCreateClaimIssueRS().Text);
                Assert.AreEqual(expectedMessageRS18, EditInvalidAccPeriod6.InvalidCreateClaimPaymentRS().Text);
            }
        }

//Admin select month and year, but accounting period for that month and year already exist.
//Error message is showed.

        [When(@"User select month and enters year for accounting period that already exists 2")]
        public void SelectMonthAndEntersYearForAccPeriodThatExists2()
        {
            AccountingPeriods EditInvalidAccPeriod6 = new AccountingPeriods(Driver);
            SelectElement monthSelect = new SelectElement(EditInvalidAccPeriod6.MonthSel());
            monthSelect.SelectByValue("12");
            EditInvalidAccPeriod6.CreateClaimIssueData().Clear();
            EditInvalidAccPeriod6.CreateClaimIssueData().SendKeys("1.2.2018");
            EditInvalidAccPeriod6.CreateClaimPaymentData().Clear();
            EditInvalidAccPeriod6.CreateClaimPaymentData().SendKeys("2.3.2018.");
            EditInvalidAccPeriod6.AccPeriodsCreateYear().Clear();
            EditInvalidAccPeriod6.AccPeriodsCreateYear().SendKeys("2100");
            EditInvalidAccPeriod6.ClickOnPage().Click();
            EditInvalidAccPeriod6.EditAccPeriodSave().Click();
        }
        [Then(@"Error message is showed 4")]
        public void ErrorMessageIsShowed4()
        {
            AccountingPeriods EditInvalidAccPeriod7 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(expectedMessage17, EditInvalidAccPeriod7.AlreadyExistsAccPeriod2().Text);
            }
            else
            {
                //Assert.AreEqual(expectedMessageRS21, EditInvalidAccPeriod7.AlreadyExistsAccPeriodRS().Text);
            }
        }
        [When(@"Admin change month, year and claim dates")]
        public void AdminChangeMonthYearAndClaimDates()
        {
            AccountingPeriods EditAccPriodValid1 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                EditAccPriodValid1.MonthSel().SendKeys(month_select2);
                EditAccPriodValid1.CreateClaimIssueData().Clear();
                EditAccPriodValid1.CreateClaimIssueData().SendKeys(EditAccPriodValid1.MonthSel().GetAttribute("value") + "/1/" + year2);
                EditAccPriodValid1.CreateClaimPaymentData().Clear();
                EditAccPriodValid1.CreateClaimPaymentData().SendKeys(EditAccPriodValid1.MonthSel().GetAttribute("value") + "/28/" + year2);
                EditAccPriodValid1.AccPeriodsCreateYear().Click();
                EditAccPriodValid1.AccPeriodsCreateYear().Clear();
                EditAccPriodValid1.AccPeriodsCreateYear().SendKeys(year2);
                //EditAccPriodValid1.ActiveCheckbox().Click();
                EditAccPriodValid1.EditAccPeriodSave().Click();
            }
            else
            {
                EditAccPriodValid1.MonthSel().SendKeys(month_select2_rs);
                EditAccPriodValid1.CreateClaimIssueData().Clear();
                EditAccPriodValid1.CreateClaimIssueData().SendKeys("1." + EditAccPriodValid1.MonthSel().GetAttribute("value") + "." + year2 + ".");
                EditAccPriodValid1.CreateClaimPaymentData().Clear();
                EditAccPriodValid1.CreateClaimPaymentData().SendKeys("28." + EditAccPriodValid1.MonthSel().GetAttribute("value") + "." + year2 + ".");
                EditAccPriodValid1.AccPeriodsCreateYear().Click();
                EditAccPriodValid1.AccPeriodsCreateYear().Clear();
                EditAccPriodValid1.AccPeriodsCreateYear().SendKeys(year2);
                //EditAccPriodValid1.ActiveCheckbox().Click();
                EditAccPriodValid1.EditAccPeriodSave().Click();

            }

        }
        [Then(@"Accounting period is changed")]
        public void AccPeriodIsChanged()
        {
            AccountingPeriods EditAccPriodValid2 = new AccountingPeriods(Driver);
            LanguageContractor contrLang = new LanguageContractor(Driver);
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                EditAccPriodValid2.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select2 + " " + year2 + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year2, EditAccPriodValid2.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual(EditAccPriodValid2.MonthSel().GetAttribute("value") + "/1/" + year2, EditAccPriodValid2.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual(EditAccPriodValid2.MonthSel().GetAttribute("value") + "/28/" + year2, EditAccPriodValid2.CreateClaimPaymentData().GetAttribute("value"));
            }
            else
            {
                EditAccPriodValid2.TableAccPeriod().FindElement(By.XPath("//tr[contains(string(), '" + month_select2_rs + " " + year2 + "')]//td[5]//a[1]")).Click();
                Assert.AreEqual(year2, EditAccPriodValid2.AccPeriodsCreateYear().GetAttribute("value"));
                Assert.AreEqual("1." + EditAccPriodValid2.MonthSel().GetAttribute("value") + "." + year2 + ".", EditAccPriodValid2.CreateClaimIssueData().GetAttribute("value"));
                Assert.AreEqual("28." + EditAccPriodValid2.MonthSel().GetAttribute("value") + "." + year2 +".", EditAccPriodValid2.CreateClaimPaymentData().GetAttribute("value"));

            }
        }
    }
}
