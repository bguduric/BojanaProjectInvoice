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
    class CreateAndAssertAccountingPeriod : BaseSteps
    {
        string month_select = GenerateRandomData.GenerateMonths();
        string month_select2 = GenerateRandomData.GenerateMonths();

        string month_select_rs = GenerateRandomData.GenerateMonthsRS();
        string month_select2_rs = GenerateRandomData.GenerateMonthsRS();

        string year = GenerateRandomData.GenerateRandomYear().ToString();
        string year2 = GenerateRandomData.GenerateRandomYear().ToString();
        string invalid_form = GenerateRandomData.GenerateRandomSpecChar(2);

        private Precondition homePage = new Precondition(Driver);
        private AccountingPeriods AdminAccountingPeriods= new AccountingPeriods(Driver);
        private LanguageContractor contrLang = new LanguageContractor(Driver);
        private InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
        private Claims dropdownCreate = new Claims(Driver);

//Login as admin and navigate on create account period page

        [Given(@"User logs in as admin and navigate on Accouting period create page 2")]
        public void GivenUserNavigatesToInvoiceValidatorWebApp()
        {
            Assert.That(homePage.IsSignInDisplayed(), Is.True, "Sign in page is not displayed.");
            homePage.LoginAsAdmin();
            AdminAccountingPeriods.AccPeriodsButton().Click();
            AdminAccountingPeriods.AccPeriodsCreateButton().Click();
            Assert.That(AdminAccountingPeriods.IsCreateAccPeriodDisplayed(), Is.True, "Create accounting period is not displayed.");
        }

//Admin enters valid values in create accounting period fields and clicks create button. 
//New accounting period should be successfully created and admin should be able to see it in the table.

        [When(@"User enters valid values in create accounting period form 2")]
        public void UserEntersValidValuesInCreateAccountingPeriodForm()
        {
                     
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {

                AdminAccountingPeriods.MonthSel().SendKeys(month_select);
                AdminAccountingPeriods.ClearAccPeriodAllFields();
                AdminAccountingPeriods.CreateClaimIssueData().SendKeys(AdminAccountingPeriods.MonthSel().GetAttribute("value") + "/1/" + year);
                AdminAccountingPeriods.CreateClaimPaymentData().SendKeys(AdminAccountingPeriods.MonthSel().GetAttribute("value") + "/28/" + year);
                AdminAccountingPeriods.AccPeriodsCreateYear().Click();
                AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys(year);
                //AdminAccountingPeriods.ActiveCheckbox().Click();
                AdminAccountingPeriods.CreateAccButton().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);

            }
            else
            {
                AdminAccountingPeriods.MonthSel().SendKeys(month_select_rs);
                AdminAccountingPeriods.ClearAccPeriodAllFields();
                AdminAccountingPeriods.CreateClaimIssueData().SendKeys("1."+ AdminAccountingPeriods.MonthSel().GetAttribute("value") + "." + year + ".");
                AdminAccountingPeriods.CreateClaimPaymentData().SendKeys("28." + AdminAccountingPeriods.MonthSel().GetAttribute("value") + "." + year + ".");
                AdminAccountingPeriods.AccPeriodsCreateYear().Click();
                AdminAccountingPeriods.AccPeriodsCreateYear().SendKeys(year);
                //AdminAccountingPeriods.ActiveCheckbox().Click();
                AdminAccountingPeriods.CreateAccButton().Click();
                Assert.AreEqual("http://intnstest:50080/AccountingPeriods", Driver.Url);

            }
        }

        [Then(@"Accounting period is successfully created")]
        public void AccPeriodIsSuccessfullyCreated()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                Assert.AreEqual(month_select + " " + year, AdminAccountingPeriods.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select + " " + year + "')]")).Text);
                selectAccPerInvoice.InvoiceButton().Click();
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select + " " + year);
            }
            else
            {
                Assert.AreEqual(month_select_rs + " " + year, AdminAccountingPeriods.TableAccPeriod().FindElement(By.XPath("//td[1][contains(string(), '" + month_select_rs + " " + year + "')]")).Text);
                InvoiceValidator selectAccPerInvoice = new InvoiceValidator(Driver);
                selectAccPerInvoice.InvoiceButton().Click();
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select_rs + " " + year);
            }
        }

//Admin navigates on Invoice Validator home page and select accounting period that is created

        [When(@"Admin navigates on Invoice Validator home page")]
        public void AdminNavigatesOnInvoiceValidatorHomePage()
        {
            selectAccPerInvoice.InvoiceButton().Click();
        
        }
        [Then(@"Admin should be able to select new accounting period")]
        public void AdminShouldBeAbleToSelectNewAccPeriod()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select + " " + year);
            }
            else
            {
                SelectElement acc_period_created = new SelectElement(selectAccPerInvoice.AccountingPeriodSel());
                acc_period_created.SelectByText(month_select_rs + " " + year);
            }
        }

//Admin logs out, and logs in as a contractor. Contractor select new accounting period from create claims 
//dropdown. If contractor is able to select new period, new accounting period exists.

        [When(@"Admin logs out and logs in as contractor")]
        public void AdminLogsOutAndLogsInAsContractor()
        {
            homePage.LogOutAsAdmin().Click();
            homePage.UsernameInputField().SendKeys("IQService.contractor2");
            homePage.PasswordInputField().SendKeys("87108884-1cac-4b8d-a80e-692425c5f294");
            homePage.SignInButton().Click();
        }
        [Then(@"New accounting period should be in create claim dropdown")]
        public void NewAccPeriodIsInCreateClaimDropdown()
        {
            if (contrLang.LanguageDropDown().Text.Contains("EN"))
            {
                SelectElement acc_per_created = new SelectElement(dropdownCreate.ConAccPeriod());
                acc_per_created.SelectByText(month_select + " " + year);
                dropdownCreate.LogOutButtonContractor().Click();
            }
            else
            {
                SelectElement acc_per_created = new SelectElement(dropdownCreate.ConAccPeriod());
                acc_per_created.SelectByText(month_select_rs + " " + year);
                dropdownCreate.LogOutButtonContractor().Click();
            }
        }

    }
}
